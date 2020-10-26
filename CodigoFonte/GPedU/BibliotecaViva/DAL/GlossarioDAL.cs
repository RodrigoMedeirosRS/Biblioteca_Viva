using System.Linq;
using System.Collections.Generic;
using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Model;
using BibliotecaViva.DAL.Interfaces;

namespace BibliotecaViva.DAL
{
    public class GlossarioDAL : IGlossarioDAL
    {
        private ISQLiteDataContext DataContext { get; set; }
        
        public GlossarioDAL(ISQLiteDataContext dataContext)
        {
            DataContext = dataContext;
        }

        public void Cadastrar(GlossarioDTO glossario)
        {
            DataContext.ObterDataContext().InsertOrReplace(VerificaLinhaDoTempoExistente(glossario));
        }

        public List<GlossarioDTO> Consultar(GlossarioDTO glossarioDTO)
        {
            var glossarios = ObterGlossario(glossarioDTO);
            var retorno = new List<GlossarioDTO>();
            foreach (var glossario in glossarios)
            {
                retorno.Add(new GlossarioDTO()
                {
                    Nome = glossario.Nome,
                    Descricao = glossario.Descricao
                });
            }
            return retorno;
        }

        private Glossario VerificaLinhaDoTempoExistente(GlossarioDTO glossarioDTO)
        {
            return ObterGlossario(glossarioDTO).FirstOrDefault() ?? new Glossario()
            {
                Nome = glossarioDTO.Nome,
                Descricao = glossarioDTO.Descricao
            };
        }

        private List<Glossario> ObterGlossario(GlossarioDTO glossario)
        {
            if (string.IsNullOrEmpty(glossario.Nome))
                return DataContext.ObterDataContext().Table<Glossario>().ToList();
            return DataContext.ObterDataContext().Table<Glossario>().Where(glossarioDB => glossarioDB.Nome == glossario.Nome).ToList();
        }
    }
}