using System.Linq;
using System.Collections.Generic;
using BibliotecaViva.DTO;
using BibliotecaViva.DAO;
using BibliotecaViva.DAL.Interfaces;

namespace BibliotecaViva.DAL
{
    public class TipoRelecaoDAL : BaseDAL, ITipoRelacaoDAL
    {
        public TipoRelecaoDAL(ISQLiteDataContext dataContext) : base(dataContext)
        {
        }
        public void Cadastrar(TipoRelacaoDTO tipoRelacaoDTO)
        {
            DataContext.ObterDataContext().InsertOrReplace(new TipoRelacao()
            {
                Codigo = ValidarJaCadastrado(tipoRelacaoDTO),
                Nome = tipoRelacaoDTO.Nome
            });
        }
        public TipoRelacaoDTO Consultar(TipoRelacaoDTO tipoRelacaoDTO)
        {
            var resultado = new TipoRelacao();

            if (string.IsNullOrEmpty(tipoRelacaoDTO.Nome))
                resultado = DataContext.ObterDataContext().Table<TipoRelacao>().FirstOrDefault(tipo => tipo.Codigo == tipoRelacaoDTO.Codigo);
            else
                resultado = DataContext.ObterDataContext().Table<TipoRelacao>().FirstOrDefault(tipo => tipo.Nome == tipoRelacaoDTO.Nome);
            
            return Mapear<TipoRelacao, TipoRelacaoDTO>(resultado);
        }

        public List<TipoRelacaoDTO> Listar()
        {
            return (from tipo in DataContext.ObterDataContext().Table<TipoRelacao>() select new TipoRelacaoDTO()
            {
                Codigo = tipo.Codigo,
                Nome = tipo.Nome
            }).ToList(); 
        }

        private int? ValidarJaCadastrado(TipoRelacaoDTO tipoRelacaoDTO)
        {
            var resultado = DataContext.ObterDataContext().Table<TipoRelacao>().FirstOrDefault(tipoRelacao => tipoRelacao.Nome == tipoRelacaoDTO.Nome);
            return resultado != null ? resultado.Codigo : null;
        } 
    }
}