using System;
using MoreLinq;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using BibliotecaViva.DTO;
using BibliotecaViva.DAO;
using BibliotecaViva.DTO.Dominio;
using BibliotecaViva.DAL.Interfaces;

namespace BibliotecaViva.DAL
{
    public class SonarDAL : BaseDAL, ISonarDAL
    {
        private IPessoaDAL PessoaDAL { get; set; }
        private IRegistroDAL RegistroDAL { get; set; }
        public SonarDAL(ISQLiteDataContext dataContext) : base(dataContext)
        {
        }
        public SonarRetorno Consultar(SonarConsulta sonar)
        {
            return new SonarRetorno()
            {
                Pessoas = PopularPessoas(BuscarPessoas(sonar)),
                Registros = PopularRegistros(BuscarRegistros(sonar))
            };
        }
        public List<LocalizacaoGeograficaDTO> Rastrear(int codRegistro)
        {
            var resultado = RastrearPessoa(codRegistro);
            resultado.AddRange(RastrearRegistro(codRegistro));
            return resultado;
        }

        private List<LocalizacaoGeograficaDTO> RastrearPessoa(int codRegistro)
        {
            return (from pessoaLocalizao in DataContext.ObterDataContext().Table<PessoaLocalizao>()
                join
                    localizacaoGeografica in DataContext.ObterDataContext().Table<LocalizacaoGeografica>()
                    on pessoaLocalizao.LocalizacaoGeografica equals localizacaoGeografica.Codigo
                where pessoaLocalizao.Pessoa == codRegistro
                select new LocalizacaoGeograficaDTO()
                {
                    Latitude = localizacaoGeografica.Latitude,
                    Longitude = localizacaoGeografica.Longitude
                }).DistinctBy(localizacao => localizacao.Codigo).ToList();
        }
        private List<LocalizacaoGeograficaDTO> RastrearRegistro(int codRegistro)
        {
            return (from registroLocalizacao in DataContext.ObterDataContext().Table<RegistroLocalizacao>()
                join
                    localizacaoGeografica in DataContext.ObterDataContext().Table<LocalizacaoGeografica>()
                    on registroLocalizacao.LocalizacaoGeografica equals localizacaoGeografica.Codigo
                where registroLocalizacao.Registro == codRegistro
                select new LocalizacaoGeograficaDTO()
                {
                    Latitude = localizacaoGeografica.Latitude,
                    Longitude = localizacaoGeografica.Longitude
                }).DistinctBy(localizacao => localizacao.Codigo).ToList();
        }

        private List<PessoaDTO> PopularPessoas(List<PessoaDTO> pessoas)
        {
            var retorno = new List<PessoaDTO>();
            
            foreach(var pessoa in pessoas)
                retorno.AddRange(PessoaDAL.Consultar(pessoa));

            return retorno.DistinctBy(pessoa => pessoa.Codigo).ToList();
        }

        private List<PessoaDTO> BuscarPessoas(SonarConsulta sonar)
        {
            return(from pessoaLocalizacao in DataContext.ObterDataContext().Table<PessoaLocalizao>()
                join
                    pessoa in DataContext.ObterDataContext().Table<Pessoa>()
                    on pessoaLocalizacao.Pessoa equals pessoa.Codigo
                join
                    localizacaoGeografica in DataContext.ObterDataContext().Table<LocalizacaoGeografica>()
                    on pessoaLocalizacao.LocalizacaoGeografica equals localizacaoGeografica.Codigo
                where localizacaoGeografica.Latitude >= sonar.CoordenadaInicio[0] && 
                    localizacaoGeografica.Latitude <= sonar.CoordenadaFim[0] &&
                    localizacaoGeografica.Longitude >= sonar.CoordenadaInicio[1] &&
                    localizacaoGeografica.Longitude <= sonar.CoordenadaFim[1]
                select new PessoaDTO()
                {
                    Codigo = pessoa.Codigo,
                    Nome = pessoa.Nome,
                    Sobrenome = pessoa.Sobrenome
                }).ToList();
        }

        private List<RegistroDTO> PopularRegistros(List<RegistroDTO> registros)
        {
            var retorno = new List<RegistroDTO>();
            
            foreach(var registro in registros)
                retorno.AddRange(RegistroDAL.Consultar(registro));

            return retorno.DistinctBy(registro => registro.Codigo).ToList();
        }

        private List<RegistroDTO> BuscarRegistros(SonarConsulta sonar)
        {
            return(from registroLocalizacao in DataContext.ObterDataContext().Table<RegistroLocalizacao>()
                join
                    registro in DataContext.ObterDataContext().Table<Registro>()
                    on registroLocalizacao.Registro equals registro.Codigo
                join
                    localizacaoGeografica in DataContext.ObterDataContext().Table<LocalizacaoGeografica>()
                    on registroLocalizacao.LocalizacaoGeografica equals localizacaoGeografica.Codigo
                join
                    idioma in DataContext.ObterDataContext().Table<Idioma>()
                    on registro.Idioma equals idioma.Codigo
                where localizacaoGeografica.Latitude >= sonar.CoordenadaInicio[0] && 
                    localizacaoGeografica.Latitude <= sonar.CoordenadaFim[0] &&
                    localizacaoGeografica.Longitude >= sonar.CoordenadaInicio[1] &&
                    localizacaoGeografica.Longitude <= sonar.CoordenadaFim[1]
                select new RegistroDTO()
                {
                    Codigo = registro.Codigo,
                    Nome = registro.Nome,
                    Idioma = idioma.Nome
                }).ToList();
        }

        
    }
}