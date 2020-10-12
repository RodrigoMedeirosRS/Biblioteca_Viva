using System.CodeDom.Compiler;
using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Model;

using BibliotecaViva.DAL.Interfaces;

namespace BibliotecaViva.DAL
{
    public class LinhaDoTempoDAL: ILinhaDoTempoDAL
    {
        private ISQLiteDataContext DataContext { get; set; }
        private IPessoaDAL PessoaDAL { get; set; }
        private IDocumentoDAL DocumentoDAL { get; set; }
        private IIdiomaDAL IdiomaDAL { get; set; }
        public LinhaDoTempoDAL(ISQLiteDataContext dataContext, IPessoaDAL pessoaDAL, IDocumentoDAL documentoDAL, IIdiomaDAL idiomaDAL)
        {
            DataContext = dataContext;
            PessoaDAL = pessoaDAL;
            DocumentoDAL = documentoDAL;
            IdiomaDAL = idiomaDAL;
        }

        public void Cadastrar(LinhaDoTempoDTO linhaDoTempoDTO)
        {
            linhaDoTempoDTO.SetId(VerificaLinhaDoTempoExistente(linhaDoTempoDTO));
            DataContext.ObterDataContext().InsertOrReplace(linhaDoTempoDTO);
        }
        public LinhaDoTempoDTO Consultar(LinhaDoTempoDTO linhaDoTempoDTO)
        {
            var linhaDoTempo = ObterLinhaDoTempo(linhaDoTempoDTO);
            return new LinhaDoTempoDTO()
            {
                Nome = linhaDoTempo.Nome,
                Descricao = linhaDoTempo.Descricao,
                Pessoas = ObterPessoasNaLinhaDoTempo(linhaDoTempo),
                Documentos = ObterDocumentosNaLinhaDoTempo(linhaDoTempo)
            };

        }
        public void VincularPessoa(LinhaDoTempoDTO linhaDoTempoDTO,PessoaDTO pessoaDTO)
        {
            var linhaDoTempoPessoa = new LinhaDoTempoPessoa()
            {
                Pessoa = (int)PessoaDAL.Consultar(pessoaDTO.Nome, pessoaDTO.Sobrenome).Id,
                LinhaDoTempo = ObterLinhaDoTempo(linhaDoTempoDTO).Id
            };         

            DataContext.ObterDataContext().InsertOrReplace(linhaDoTempoPessoa);
        }
        public void VincularDocumento(LinhaDoTempoDTO linhaDoTempoDTO, DocumentoDTO documentoDTO)
        {
            var linhaDoTempoDocumento = new LinhaDoTempoDocumento()
            {
                Documento = (int)DocumentoDAL.Consultar(documentoDTO, IdiomaDAL.Consultar(documentoDTO.Idioma).Id).Id,
                LinhaDoTempo = ObterLinhaDoTempo(linhaDoTempoDTO).Id
            };         

            DataContext.ObterDataContext().InsertOrReplace(linhaDoTempoDocumento);
        }
        public void VincularEvento(LinhaDoTempoDTO linhaDoTempoDTO, EventoDTO eventoDTO)
        {
        }  

        private LinhaDoTempo ObterLinhaDoTempo(LinhaDoTempoDTO linhaDoTempoDTO)
        {
            return DataContext.ObterDataContext().Table<LinhaDoTempo>().FirstOrDefault(linhaDoTempo => linhaDoTempo.Nome == linhaDoTempoDTO.Nome);
        }

        private List<CabecalhoDTO> ObterDocumentosNaLinhaDoTempo(LinhaDoTempo linhaDoTempo)
        {
            return(from linhaDoTempoDB in DataContext.ObterDataContext().Table<LinhaDoTempo>()
                join
                    relacao in DataContext.ObterDataContext().Table<LinhaDoTempoDocumento>()
                    on linhaDoTempoDB.Id equals relacao.LinhaDoTempo
                join
                    documento in DataContext.ObterDataContext().Table<Documento>()
                    on relacao.Documento equals documento.Id
                join
                    idioma in DataContext.ObterDataContext().Table<Idioma>()
                    on documento.Idioma equals idioma.Id
                where linhaDoTempo.Nome == linhaDoTempoDB.Nome
                select new  CabecalhoDTO
                {
                    Nome = documento.Nome,
                    Idioma = idioma.Nome,
                    DataRegistro = documento.DataRegistro
                }).ToList();
        }

        private List<PessoaDTO> ObterPessoasNaLinhaDoTempo(LinhaDoTempo linhaDoTempo)
        {
            return (from linhaDoTempoDB in DataContext.ObterDataContext().Table<LinhaDoTempo>()
                join
                    relacao in DataContext.ObterDataContext().Table<LinhaDoTempoPessoa>()
                    on linhaDoTempoDB.Id equals relacao.LinhaDoTempo
                join
                    pessoa in DataContext.ObterDataContext().Table<Pessoa>()
                    on relacao.Pessoa equals pessoa.Id
                join
                    genero in DataContext.ObterDataContext().Table<Genero>()
                    on pessoa.Genero equals genero.Id
                join
                    apelido in DataContext.ObterDataContext().Table<Apelido>()
                    on pessoa.Id equals apelido.Pessoa into leftJoin from apelidoLeft in leftJoin.DefaultIfEmpty()
                join
                    nomeSocial in DataContext.ObterDataContext().Table<NomeSocial>()
                    on pessoa.Id equals nomeSocial.Pessoa into leftJoin2 from nomeSocialLeft in leftJoin2.DefaultIfEmpty()
                where linhaDoTempoDB.Nome == linhaDoTempo.Nome
                select new PessoaDTO
                {
                    Nome = pessoa.Nome,
                    Sobrenome = pessoa.Sobrenome,
                    Genero = genero.Nome,
                    Apelido = apelidoLeft != null ? apelidoLeft.Nome : "",
                    NomeSocial = nomeSocialLeft != null ? nomeSocialLeft.Nome : ""
                }
            ).ToList();
        } 

        private int? VerificaLinhaDoTempoExistente(LinhaDoTempoDTO linhaDoTempo)
        {
            var linhaDoTempoDB = ObterLinhaDoTempo(linhaDoTempo);
            if (linhaDoTempoDB == null)
                return null;
            
            return linhaDoTempoDB.Id;
        }
    }
}