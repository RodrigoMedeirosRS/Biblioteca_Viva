using System;
using BibliotecaViva.DTO.Model;
using BibliotecaViva.DAL.Interfaces;

namespace BibliotecaViva.DAL
{
    public class TipoRelacaoDAL : ITipoRelacaoDAL
    {
        private ISQLiteDataContext DataContext { get; set; }
        public TipoRelacaoDAL(ISQLiteDataContext dataContext)
        {
            DataContext = dataContext;
        }
        public TipoDeRelacao Consultar(string nomeRelacao)
        {
            return DataContext.ObterDataContext().Table<TipoDeRelacao>().FirstOrDefault(relacao => relacao.Nome == nomeRelacao) ?? throw new Exception("Idioma não cadastrado!");
        }
    }
}
