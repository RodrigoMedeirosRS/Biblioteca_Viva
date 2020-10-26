using System;
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

        public void Cadastrar(ConceitoDTO conceitoDTO, GlossarioDTO glossarioDTO)
        {
            DataContext.ObterDataContext().InsertOrReplace(VerificaConceitoExistente(conceitoDTO, glossarioDTO));
        }

        public List<ConceitoDTO> Consultar(ConceitoDTO conceitoDTO)
        {
            if (string.IsNullOrEmpty(conceitoDTO.Nome) && string.IsNullOrEmpty(conceitoDTO.Glossario))
                throw new Exception("Erro, favor preencher nome ou glossario");
            if (!string.IsNullOrEmpty(conceitoDTO.Glossario))
                return (from conceito in DataContext.ObterDataContext().Table<Conceito>()
                        join
                            glossario in DataContext.ObterDataContext().Table<Glossario>()
                            on conceito.Glossario equals glossario.Id
                        where glossario.Nome == conceitoDTO.Glossario select new ConceitoDTO(conceito.Id)
                        {
                            Nome = conceito.Nome,
                            Glossario = glossario.Nome,
                            GlossarioId = conceito.Glossario
                        }).ToList();
            return (from conceito in DataContext.ObterDataContext().Table<Conceito>()
                        join
                            glossario in DataContext.ObterDataContext().Table<Glossario>()
                            on conceito.Glossario equals glossario.Id
                        where conceito.Nome == conceitoDTO.Nome select new ConceitoDTO(conceito.Id)
                        {
                            Nome = conceito.Nome,
                            Glossario = glossario.Nome,
                            GlossarioId = conceito.Glossario
                        }).ToList();
        }

        private ConceitoDTO VerificaConceitoExistente(ConceitoDTO conceitoDTO, GlossarioDTO glossarioDTO)
        {
            var conceito = Consultar(conceitoDTO).FirstOrDefault() ?? new ConceitoDTO()
            {
                Nome = conceitoDTO.Nome,
                Glossario = glossarioDTO.Nome,
                GlossarioId = glossarioDTO.Id
            };
            return conceito;
        }
    }
}