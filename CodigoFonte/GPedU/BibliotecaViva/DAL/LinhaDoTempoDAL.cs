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
            DataContext.ObterDataContext().InsertOrReplace(VerificaLinhaDoTempoExistente(linhaDoTempoDTO));
        }
        public List<LinhaDoTempoDTO> Consultar(LinhaDoTempoDTO linhaDoTempoDTO)
        {
            var linhasDoTempo = ObterLinhaDoTempo(linhaDoTempoDTO);
            var retorno = new List<LinhaDoTempoDTO>();
            foreach (var linhaDoTempo in linhasDoTempo)
            {
                retorno.Add(new LinhaDoTempoDTO()
                {
                    Nome = linhaDoTempo.Nome,
                    Descricao = linhaDoTempo.Descricao,
                    Pessoas = ObterPessoasNaLinhaDoTempo(linhaDoTempo),
                    Documentos = ObterDocumentosNaLinhaDoTempo(linhaDoTempo)
                });
            }
            return retorno;
        }
        public void VincularPessoa(LinhaDoTempoDTO linhaDoTempoDTO,PessoaDTO pessoaDTO)
        {
            var linhaDoTempoPessoa = new LinhaDoTempoPessoa()
            {
                Pessoa = (int)PessoaDAL.Consultar(pessoaDTO.Nome, pessoaDTO.Sobrenome).Id,
                LinhaDoTempo = ObterLinhaDoTempo(linhaDoTempoDTO).FirstOrDefault().Id
            };
            //var Pessoa = PessoaDAL.Consultar(pessoaDTO.Nome, pessoaDTO.Sobrenome);
           //var LinhaDoTempo = ObterLinhaDoTempo(linhaDoTempoDTO).FirstOrDefault();         

            DataContext.ObterDataContext().InsertOrReplace(linhaDoTempoPessoa);
        }
        public void VincularDocumento(LinhaDoTempoDTO linhaDoTempoDTO, DocumentoDTO documentoDTO)
        {
            var linhaDoTempoDocumento = new LinhaDoTempoDocumento()
            {
                Documento = (int)DocumentoDAL.Consultar(documentoDTO).FirstOrDefault().Id,
                LinhaDoTempo = ObterLinhaDoTempo(linhaDoTempoDTO).FirstOrDefault().Id
            };         

            DataContext.ObterDataContext().InsertOrReplace(linhaDoTempoDocumento);
        }
        public void VincularEvento(LinhaDoTempoDTO linhaDoTempoDTO, EventoDTO eventoDTO)
        {
        }  

        private List<LinhaDoTempo> ObterLinhaDoTempo(LinhaDoTempoDTO linhaDoTempoDTO)
        {
            if (string.IsNullOrEmpty(linhaDoTempoDTO.Nome))
                return DataContext.ObterDataContext().Table<LinhaDoTempo>().ToList();
            return DataContext.ObterDataContext().Table<LinhaDoTempo>().Where(linhaDoTempo => linhaDoTempo.Nome == linhaDoTempoDTO.Nome).ToList();
        }

        private List<DocumentoDTO> ObterDocumentosNaLinhaDoTempo(LinhaDoTempo linhaDoTempo)
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
                select new  DocumentoDTO
                {
                    Nome = documento.Nome,
                    Idioma = idioma.Nome,
                    DataRegistro = documento.DataRegistro,
                    DataDigitalizacao = documento.DataDigitalizacao
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

        private LinhaDoTempo VerificaLinhaDoTempoExistente(LinhaDoTempoDTO linhaDoTempoDTO)
        {
            return ObterLinhaDoTempo(linhaDoTempoDTO).FirstOrDefault() ?? new LinhaDoTempo()
                {
                    Nome = linhaDoTempoDTO.Nome,
                    Descricao = linhaDoTempoDTO.Descricao
                };
        }
    }
}