using System;
using System.Linq;
using System.Collections.Generic;
using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Model;
using BibliotecaViva.DAL.Interfaces;

namespace BibliotecaViva.DAL
{
    public class SignificadoDAL : ISignificadoDAL
    {
        private ISQLiteDataContext DataContext { get; set; }
        public SignificadoDAL(ISQLiteDataContext dataContext)
        {
            DataContext = dataContext;
        }
        public void Cadastrar(ConceitoDTO conceitoDTO,IdiomaDTO idiomaDTO, SignificadoDTO significadoDTO)
        {
            DataContext.ObterDataContext().InsertOrReplace(VerificaConceitoExistente(conceitoDTO, idiomaDTO, significadoDTO));
        }
        public List<SignificadoDTO> Consultar(IdiomaDTO idiomaDTO, ConceitoDTO conceitoDTO)
        {
            if (string.IsNullOrEmpty(conceitoDTO.Nome))
                throw new Exception("Erro, inserir um conceito.");
            if (string.IsNullOrEmpty(idiomaDTO.Nome))
                return (from conceito in DataContext.ObterDataContext().Table<Conceito>()
                    join
                        significado in DataContext.ObterDataContext().Table<Significado>()
                        on conceito.Id equals significado.Conceito
                    join
                        idioma in DataContext.ObterDataContext().Table<Idioma>()
                        on significado.Idioma equals idioma.Id
                    where conceito.Nome == conceitoDTO.Nome select new SignificadoDTO(significado.Id)
                    {
                        Conceito = significado.Conceito,
                        Idioma = significado.Idioma,
                        Link = significado.Link,
                        Descricao = significado.Descricao
                    }).ToList();
            return (from conceito in DataContext.ObterDataContext().Table<Conceito>()
                join
                    significado in DataContext.ObterDataContext().Table<Significado>()
                    on conceito.Id equals significado.Conceito
                join
                    idioma in DataContext.ObterDataContext().Table<Idioma>()
                    on significado.Idioma equals idioma.Id
                where conceito.Nome == conceitoDTO.Nome && idioma.Nome == idiomaDTO.Nome
                select new SignificadoDTO(significado.Id)
                {
                    Conceito = significado.Conceito,
                    Idioma = significado.Idioma,
                    Link = significado.Link,
                    Descricao = significado.Descricao
                }).ToList();
        }

        private SignificadoDTO VerificaConceitoExistente(ConceitoDTO conceitoDTO, IdiomaDTO idiomaDTO, SignificadoDTO significadoDTO)
        {
            var conceito = Consultar(idiomaDTO, conceitoDTO).FirstOrDefault() ?? new SignificadoDTO()
            {
                Conceito = conceitoDTO.Id,
                Idioma = idiomaDTO.Id,
                Link = significadoDTO.Link,
                Descricao = significadoDTO.Descricao
            };
            return conceito;
        }
    }
}