using System.Linq;
using System.Collections.Generic;
using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Model;
using BibliotecaViva.DAL.Interfaces;


namespace BibliotecaViva.DAL
{
    public class ConceitoDAL : IConceitoDAL
    {
        private ISQLiteDataContext DataContext { get; set; }
        
        public ConceitoDAL(ISQLiteDataContext dataContext)
        {
            DataContext = dataContext;
        }

        public void Cadastrar(ConceitoDTO conceito)
        {
            DataContext.ObterDataContext().InsertOrReplace(VerificaConceitoExistente(conceito));
        }
        public  List<ConceitoDTO> Consultar(ConceitoDTO conceitoDTO)
        {
            var conceitos = ObterConceito(conceitoDTO);
            var retorno = new List<ConceitoDTO>();
            foreach (var glossario in conceitos)
            {
                retorno.Add(new ConceitoDTO()
                {
                    Nome = glossario.Nome
                });
            }
            return retorno;
        }

        private Conceito VerificaConceitoExistente(ConceitoDTO conceitoDTO)
        {
            return ObterConceito(conceitoDTO).FirstOrDefault() ?? new Conceito()
            {
                Nome = conceitoDTO.Nome
            };
        }

        private List<Conceito> ObterConceito(ConceitoDTO conceitoDTO)
        {
            if (string.IsNullOrEmpty(conceitoDTO.Nome))
                return DataContext.ObterDataContext().Table<Conceito>().ToList();
            return DataContext.ObterDataContext().Table<Conceito>().Where(conceito => conceito.Nome == conceitoDTO.Nome).ToList();
        }
    }
}