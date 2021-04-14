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

        public RegistroDAL(ISQLiteDataContext dataContext) : base(dataContext)
        {
            
        }

        public List<RegistroDTO> Consultar(RegistroDTO registroDTO)
        {
            throw new NotImplementedException();
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
    }
}