using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Model;

namespace BibliotecaViva.DAL.Interfaces
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

        public void Cadastrar(DocumentoDTO documentoDTO)
        {
            var idioma = Idioma.Consultar(documentoDTO.Idioma).Id;
            var documento = Mapeadores.Mapeador.MapearCabecalhoDocumento(documentoDTO, idioma, VerificarJaRegistrado(documentoDTO, idioma));
            DataContext.ObterDataContext().InsertOrReplace(documento);
            VincularAutoria(documentoDTO, idioma);

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

        private int? VerificarJaRegistrado(DocumentoDTO documentoDTO, int idioma)
        {
            var documentoCadastrado = Consultar(documentoDTO, idioma);
            return documentoCadastrado != null ? documentoCadastrado.Id : null;
        }

        private void VincularAutoria(DocumentoDTO documentoDTO, int idioma)
        {
            var autorAnterior = BuscarPessoasVinculadas(documentoDTO, idioma, "Autor", BuscarPessoa(documentoDTO).GetId());
            DataContext.ObterDataContext().Delete(autorAnterior.First());
            DataContext.ObterDataContext().InsertOrReplace(autorAnterior.First());
        }

        private PessoaDTO BuscarPessoa(DocumentoDTO documentoDTO)
        {
            return Pessoa.Consultar(new PessoaDTO()
            {
                Nome = documentoDTO.NomeAutor,
                Sobrenome = documentoDTO.SobreNomeAutor
            }) ?? throw new Exception("Autor não encontrado!");
        }

        private List<PessoaDocumento> BuscarPessoasVinculadas(DocumentoDTO documentoDTO, int idioma, string tipoVinculo, int? pessoa)
        {
            var pessoaRelacionada = new PessoaDocumento()
            {
                Pessoa = pessoa,
                Documento = Consultar(documentoDTO, idioma).Id,
                TipoDeRelacao = TipoRelacao.Consultar(tipoVinculo).Id
            };
            var pessoaRelacionadas = ConsultarRelacaoPessoaDocumento(pessoaRelacionada).ToList();
            return pessoaRelacionadas.Count > 0 ? pessoaRelacionadas : new List<PessoaDocumento>(){ pessoaRelacionada };
        }

        private List<PessoaDocumento> ConsultarRelacaoPessoaDocumento(PessoaDocumento pessoa)
        {
            return pessoa.Pessoa != null ?
                DataContext.ObterDataContext().Table<PessoaDocumento>().Where(pessoaDocumento => pessoaDocumento.Documento == pessoa.Documento && pessoaDocumento.TipoDeRelacao == pessoa.TipoDeRelacao && pessoaDocumento.Pessoa == pessoa.Pessoa).ToList() :
                DataContext.ObterDataContext().Table<PessoaDocumento>().Where(pessoaDocumento => pessoaDocumento.Documento == pessoa.Documento && pessoaDocumento.TipoDeRelacao == pessoa.TipoDeRelacao).ToList();
        }

        public DocumentoDTO Consultar(DocumentoDTO documentoDTO)
        {
            var idioma = Idioma.Consultar(documentoDTO.Idioma);
            var documento = DataContext.ObterDataContext().Table<Documento>().FirstOrDefault(documentoDB => documentoDB.Nome == documentoDTO.Nome && documentoDB.Idioma == idioma.Id) ?? throw new Exception("Documento não encontrado");
            var autor = Pessoa.Consultar(BuscarPessoasVinculadas(documentoDTO, idioma.Id, "Autor", null).First().Pessoa);

            switch (documentoDTO.GetType().Name)
            {
                case ("AudioDTO"):
                    {
                        var audio = Audio.Consultar(documento.Id) ?? throw new Exception("Arquivo de audio não encontrado");
                        return new AudioDTO(documento, idioma.Nome, autor, audio.Base64);
                    }
                case ("ImagemDTO"):
                    {
                        var imagem = Imagem.Consultar(documento.Id) ?? throw new Exception("Arquivo de imagem não encontrada");
                        return new ImagemDTO(documento, idioma.Nome, autor, imagem.Base64);
                    }
                case ("TextoDTO"):
                    {
                        var texto = Texto.Consultar(documento.Id) ?? throw new Exception("Arquivo de texto não encontrado");
                        return new TextoDTO(documento, idioma.Nome, autor, texto.Corpo);
                    }
                case ("VideoDTO"):
                    {
                        var video = Video.Consultar(documento.Id) ?? throw new Exception("Arquivo de video não encontrado");
                        return new VideoDTO(documento, idioma.Nome, autor, video.Url);
                    }
                default:
                    throw new Exception("Documento Inválido");
            }       
        }

        public Documento Consultar(DocumentoDTO documentoDTO, int idioma)
        {
            return DataContext.ObterDataContext().Table<Documento>().FirstOrDefault(documentoDB => documentoDB.Nome == documentoDTO.Nome && documentoDB.Idioma == idioma);
        }
    }
}
