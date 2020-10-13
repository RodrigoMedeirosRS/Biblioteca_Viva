using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Model;
using BibliotecaViva.DAL.Interfaces;
using BibliotecaViva.DAL.Utils;

namespace BibliotecaViva.DAL
{
    public class DocumentoDAL : IDocumentoDAL
    {
        private ISQLiteDataContext DataContext { get; set; }
        private IIdiomaDAL Idioma { get; set; }
        private IPessoaDAL Pessoa { get; set; }
        private ITipoRelacaoDAL TipoRelacao { get; set; }
        private IAudioDAL Audio { get; set; }
        private IVideoDAL Video { get; set; }
        private IImagemDAL Imagem { get; set; }
        private ITextoDAL Texto { get; set; }

        public DocumentoDAL(ISQLiteDataContext dataContext, IIdiomaDAL idioma, IPessoaDAL pessoa, ITipoRelacaoDAL tipoRelacao, IAudioDAL audio, IVideoDAL video, IImagemDAL imagem, ITextoDAL texto)
        {
            DataContext = dataContext;
            Idioma = idioma;
            Pessoa = pessoa;
            Texto = texto;
            Imagem = imagem;
            Audio = audio;
            Video = video;
            TipoRelacao = tipoRelacao;
        }
        public List<DocumentoDTO> Consultar(DocumentoDTO documentoDTO)
        {
            var documentos = (documentoDTO.Nome == null || documentoDTO.Idioma == null) ? 
            ObterDocumentoPorData(documentoDTO) : ObterDocumentoPorNome(documentoDTO); 
            
            foreach (var documento in documentos)
                documento.PessoaVinculadas = BuscarPessoasVinculadas(documento.Id);
            
            return documentos;
        }
        private List<PessoaVinculadaDTO> BuscarPessoasVinculadas(int? documentoId)
        {
            return (from pessoa in DataContext.ObterDataContext().Table<Pessoa>()
                join
                    pessoaDocumento in DataContext.ObterDataContext().Table<PessoaDocumento>()
                    on pessoa.Id equals pessoaDocumento.Pessoa
                join
                    documento in DataContext.ObterDataContext().Table<Documento>()
                    on pessoaDocumento.Documento equals documento.Id
                join
                    tipoRelacao in DataContext.ObterDataContext().Table<TipoDeRelacao>()
                    on pessoaDocumento.TipoDeRelacao equals tipoRelacao.Id
                join
                    genero in DataContext.ObterDataContext().Table<Genero>()
                    on pessoa.Genero equals genero.Id
                join
                    apelido in DataContext.ObterDataContext().Table<Apelido>()
                    on pessoa.Id equals apelido.Pessoa into leftJoin from apelidoLeft in leftJoin.DefaultIfEmpty()
                join
                    nomeSocial in DataContext.ObterDataContext().Table<NomeSocial>()
                    on pessoa.Id equals nomeSocial.Pessoa into leftJoin2 from nomeSocialLeft in leftJoin2.DefaultIfEmpty()
                where documento.Id == documentoId
                select new PessoaVinculadaDTO(pessoa.Id)
                {
                    Nome = pessoa.Nome,
                    Sobrenome = pessoa.Sobrenome,
                    Genero = genero.Nome,
                    Apelido = apelidoLeft != null ? apelidoLeft.Nome : "",
                    NomeSocial = nomeSocialLeft != null ? nomeSocialLeft.Nome : "",
                    TipoVinculo = tipoRelacao.Nome
                }).ToList();
        }
        private List<DocumentoDTO> ObterDocumentoPorData(DocumentoDTO documentoDTO)
        {
            return (from documento in DataContext.ObterDataContext().Table<Documento>()
                join
                    idioma in DataContext.ObterDataContext().Table<Idioma>()
                    on documento.Idioma equals idioma.Id
                where documentoDTO.DataDigitalizacao.Date == documentoDTO.DataDigitalizacao.Date
                select new DocumentoDTO(documento.Id)
                {
                    Nome = documento.Nome,
                    Idioma = idioma.Nome,
                    DataRegistro = documento.DataRegistro,
                    DataDigitalizacao = documento.DataDigitalizacao
                }).ToList();
        }
        private List<DocumentoDTO> ObterDocumentoPorNome(DocumentoDTO documentoDTO)
        {
            return (from documento in DataContext.ObterDataContext().Table<Documento>()
                join
                    idioma in DataContext.ObterDataContext().Table<Idioma>()
                    on documento.Idioma equals idioma.Id
                where documentoDTO.Nome == documento.Nome && idioma.Nome == documentoDTO.Idioma
                select new DocumentoDTO(documento.Id)
                {
                    Nome = documento.Nome,
                    Idioma = idioma.Nome,
                    DataRegistro = documento.DataRegistro,
                    DataDigitalizacao = documento.DataDigitalizacao
                }).ToList();
        }
        public void Cadastrar(DocumentoDTO documentoDTO)
        {
            var documento = VerificarJaRegistrado(documentoDTO);
            RemoverVinculoAnterior(documento);

            DataContext.ObterDataContext().InsertOrReplace(documento);
            documentoDTO.AtualizarId(ObterDocumentoPorNome(documentoDTO).FirstOrDefault().Id);
            VincularPessoas(documentoDTO);
            
            switch (documentoDTO.GetType().Name)
            {
                case ("AudioDTO"):
                    {
                        Audio.Cadastrar(new Audio()
                        {
                            Documento = documento.Id,
                            Base64 = (documentoDTO as AudioDTO).Base64
                        });
                        break;
                    }
                case ("ImagemDTO"):
                    {
                        Imagem.Cadastrar(new Imagem()
                        {
                            Documento = documento.Id,
                            Base64 = (documentoDTO as ImagemDTO).Base64
                        });
                        break;
                    }
                case ("TextoDTO"):
                    {
                        Texto.Cadastrar(new Texto()
                        {
                            Documento = documento.Id,
                            Corpo = (documentoDTO as TextoDTO).Texto
                        });
                        break;
                    }
                case ("VideoDTO"):
                    {
                        Video.Cadastrar(new Video()
                        {
                            Documento = documento.Id,
                            Url = (documentoDTO as VideoDTO).Url
                        });
                        break;
                    }
                default:
                    throw new Exception("Documento Inválido");
            }
        }
        private Documento VerificarJaRegistrado(DocumentoDTO documentoDTO)
        {
            var documentoDB = ObterDocumentoPorNome(documentoDTO).FirstOrDefault();

            return new Documento()
            {
                Id = documentoDB != null ? documentoDB.Id : null,
                Idioma = Idioma.Consultar(documentoDTO.Idioma).Id,
                Nome = documentoDTO.Nome,
                DataDigitalizacao = documentoDTO.DataDigitalizacao,
                DataRegistro = documentoDTO.DataRegistro
            };
        }
        private void VincularPessoas(DocumentoDTO documento)
        {
            foreach(var pessoa in documento.PessoaVinculadas)
                DataContext.ObterDataContext().Insert(new PessoaDocumento()
                {
                    Pessoa = Pessoa.Consultar(pessoa).Id,
                    Documento = documento.Id,
                    TipoDeRelacao = TipoRelacao.Consultar(pessoa.TipoVinculo).Id
                });
        }
        private void RemoverVinculoAnterior(Documento documento)
        {
            if (documento != null)
            {
                var vinculosAnteriores = DataContext.ObterDataContext().Table<PessoaDocumento>().Where(vinculo => vinculo.Documento == documento.Id);
                foreach(var vinculo in vinculosAnteriores)
                    DataContext.ObterDataContext().Delete(vinculosAnteriores);
            }
        }
    }
}
