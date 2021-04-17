using System;
using System.Linq;
using System.Collections.Generic;
using BibliotecaViva.DTO;
using BibliotecaViva.DAO;
using BibliotecaViva.DAL.Interfaces;

namespace BibliotecaViva.DAL
{
    public class RegistroDAL : BaseDAL, IRegistroDAL
    {
        private IDescricaoDAL DescricaoDAL { get ;set; }
        private IApelidoDAL ApelidoDAL { get ;set; }
        private IIdiomaDAL IdiomaDAL { get ;set; }
        private ITipoDAL TipoDAL { get ;set; }
        private ILocalizacaoGeograficaDAL LocalizacaoGeograficaDAL { get; set; }

        public RegistroDAL(ISQLiteDataContext dataContext, IDescricaoDAL descricaoDAL, IIdiomaDAL idiomaDAL, IApelidoDAL apelidoDAL,ITipoDAL tipoDAL, ILocalizacaoGeograficaDAL localizacaoGeograficaDAL) : base(dataContext)
        {
            DescricaoDAL = descricaoDAL;
            ApelidoDAL = apelidoDAL;
            IdiomaDAL = idiomaDAL;
            TipoDAL = tipoDAL;
            LocalizacaoGeograficaDAL = localizacaoGeograficaDAL;
        }

        public List<RegistroDTO> Consultar(RegistroDTO registroDTO)
        {
            return (from registro in DataContext.ObterDataContext().Table<Registro>()
                join
                    idioma in DataContext.ObterDataContext().Table<Idioma>()
                    on registro.Idioma equals idioma.Id
                join
                    tipo in DataContext.ObterDataContext().Table<Tipo>()
                    on registro.Tipo equals tipo.Codigo
                join
                    descricao in DataContext.ObterDataContext().Table<Descricao>()
                    on registro.Codigo equals descricao.Registro into descricaoLeftJoin from descricaoLeft in descricaoLeftJoin.DefaultIfEmpty()
                join
                    registroApelido in DataContext.ObterDataContext().Table<RegistroApelido>()
                    on registro.Codigo equals registroApelido.Registro into registroApelidoLeftJoin from registroApelidoLeft in registroApelidoLeftJoin.DefaultIfEmpty()
                join
                   apelido in DataContext.ObterDataContext().Table<Apelido>()
                   on new RegistroApelido(){ 
                       Apelido = registroApelidoLeft != null ? registroApelidoLeft.Apelido : 0
                    }.Apelido equals apelido.Codigo into apelidoLeftJoin from apelidoLeft in apelidoLeftJoin.DefaultIfEmpty()

                where registro.Nome == registroDTO.Nome && registro.Idioma == registro.Idioma
                
                select new RegistroDTO()
                {
                    Codigo = registro.Codigo,
                    Nome = registro.Nome,
                    Apelido = apelidoLeft != null ? apelidoLeft.Nome : string.Empty,
                    Idioma = idioma.Nome,
                    Tipo = tipo.Nome,
                    Conteudo = registro.Conteudo,
                    Descricao = descricaoLeft != null ? descricaoLeft.Conteudo : string.Empty,
                    DataInsercao = registro.DataInsercao
                }).ToList(); 
        }
        
        public void Cadastrar(RegistroDTO registroDTO)
        {
            DataContext.ObterDataContext().InsertOrReplace(MapearRegistro(registroDTO)); 
            CadastrarDadosOpcionais(registroDTO);
        }

        private Registro MapearRegistro(RegistroDTO registroDTO)
        {
            var idioma = IdiomaDAL.ObterIdioma(new IdiomaDTO(){ Nome = registroDTO.Nome });
            var tipo = TipoDAL.ObterTipo(new TipoDTO(){ Nome = registroDTO.Tipo });

            return new Registro()
            {
                Codigo = registroDTO.Codigo,
                Idioma = (int)idioma.Codigo,
                Tipo = (int)tipo.Codigo,
                Nome = registroDTO.Nome,
                Conteudo = registroDTO.Conteudo,
                DataInsercao = DateTime.Now
            };
        }

        private void CadastrarDadosOpcionais(RegistroDTO registroDTO)
        {
            registroDTO = PopularCodigo(registroDTO);
            CadastrarDescricao(registroDTO);
            CadastrarApelido(registroDTO);
        }

        private RegistroDTO PopularCodigo(RegistroDTO registroDTO)
        {
            if (registroDTO.Codigo == null)
                registroDTO.Codigo = Consultar(registroDTO).FirstOrDefault().Codigo;
            return registroDTO;
        }

        private void CadastrarDescricao(RegistroDTO registroDTO)
        {
            if (string.IsNullOrEmpty(registroDTO.Descricao))
                DescricaoDAL.Remover(registroDTO.Codigo);
            else
                DescricaoDAL.Cadastrar(new DescricaoDTO()
                {
                    Registro = registroDTO.Codigo,
                    Conteudo = registroDTO.Descricao
                });
        }

        private void CadastrarApelido(RegistroDTO registroDTO)
        {
            if (string.IsNullOrEmpty(registroDTO.Apelido))
                ApelidoDAL.RemoverVinculo(registroDTO.Codigo);
            else
            {
                var apelidoDTO = new ApelidoDTO()
                { 
                    Nome = registroDTO.Apelido 
                };
                
                ApelidoDAL.Cadastrar(apelidoDTO);
                ApelidoDAL.VincularRegistro(apelidoDTO, registroDTO);
            }     
        }

        private void CadastrarLocalizacaoGeografica(RegistroDTO registroDTO)
        {
            if (registroDTO.Latitude == null || registroDTO.Longitude == null)
                LocalizacaoGeograficaDAL.RemoverVinculoRegistro(registroDTO.Codigo);
            else
            {
                var localizacaoGeograficaDTO = new LocalizacaoGeograficaDTO()
                { 
                    Latitude = (double)registroDTO.Latitude,
                    Longitude = (double)registroDTO.Longitude,
                };
                
                LocalizacaoGeograficaDAL.Cadastrar(localizacaoGeograficaDTO);
                LocalizacaoGeograficaDAL.Vincular(localizacaoGeograficaDTO, registroDTO);
            }     
        }
    }
}