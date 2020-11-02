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
        private ISignificadoDAL SignificadoDAL { get; set; }
        private ISQLiteDataContext DataContext { get; set; }
        
        public ConceitoDAL(ISQLiteDataContext dataContext, ISignificadoDAL significadoDAL)
        {
            DataContext = dataContext;
            SignificadoDAL = significadoDAL;
        }

        public void Cadastrar(ConceitoDTO conceitoDTO, GlossarioDTO glossarioDTO)
        {
            DataContext.ObterDataContext().InsertOrReplace(VerificaConceitoExistente(conceitoDTO, glossarioDTO));
        }

        public List<ConceitoDTO> Consultar(ConceitoDTO conceitoDTO)
        {
            if (string.IsNullOrEmpty(conceitoDTO.Nome) && string.IsNullOrEmpty(conceitoDTO.Glossario))
                throw new Exception("Erro, favor preencher nome ou glossario");
            
            var result = !string.IsNullOrEmpty(conceitoDTO.Glossario) ?
                (from conceito in DataContext.ObterDataContext().Table<Conceito>()
                    join
                        glossario in DataContext.ObterDataContext().Table<Glossario>()
                        on conceito.Glossario equals glossario.Id
                    where glossario.Nome == conceitoDTO.Glossario select new ConceitoDTO()
                    {
                        Id = conceito.Id,
                        Nome = conceito.Nome,
                        Glossario = glossario.Nome,
                        GlossarioId = conceito.Glossario
                    }).ToList() :
                (from conceito in DataContext.ObterDataContext().Table<Conceito>()
                    join
                        glossario in DataContext.ObterDataContext().Table<Glossario>()
                        on conceito.Glossario equals glossario.Id
                    where conceito.Nome == conceitoDTO.Nome select new ConceitoDTO()
                    {
                        Id = conceito.Id,
                        Nome = conceito.Nome,
                        Glossario = glossario.Nome,
                        GlossarioId = conceito.Glossario
                    }).ToList();
            
            foreach(var conceito in result)
                conceito.Significados = SignificadoDAL.Consultar(new IdiomaDTO(), conceito);

            return result;
        }


        private Conceito VerificaConceitoExistente(ConceitoDTO conceitoDTO, GlossarioDTO glossarioDTO)
        {
            var conceito = Consultar(conceitoDTO).FirstOrDefault();
            return conceito == null ? new Conceito()
                {
                    Nome = conceitoDTO.Nome,
                    Glossario = glossarioDTO.Id
                } : new Conceito()
                {
                    Id = conceito.Id,
                    Nome = conceito.Nome,
                    Glossario = conceito.GlossarioId
                };
        }
    }
}