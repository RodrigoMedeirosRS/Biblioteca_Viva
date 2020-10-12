using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Model;
using BibliotecaViva.DAL.Interfaces;

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

        public void Cadastrar(DocumentoDTO documentoDTO)
        {
            var idioma = Idioma.Consultar(documentoDTO.Idioma).Id;
            var documento = Mapeadores.Mapeador.MapearCabecalhoDocumento(documentoDTO, idioma, VerificarJaRegistrado(documentoDTO, idioma));
            DataContext.ObterDataContext().InsertOrReplace(documento);
            VincularAutoria(documentoDTO, idioma);
            VincularMencao(documento, documentoDTO);

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
            var autorAnterior = BuscarPessoasVinculadas(documentoDTO, idioma, "Autor", BuscarPessoaAutor(documentoDTO).GetId());
            DataContext.ObterDataContext().Delete(autorAnterior.First());
            DataContext.ObterDataContext().InsertOrReplace(autorAnterior.First());
        }

        private void VincularMencao(Documento documento, DocumentoDTO documentoDTO)
        {
            var mencoes = BuscarPessoasVinculadas(documento.Id,"Mencao").ToList();
            foreach (var mencao in mencoes)
            {
                DataContext.ObterDataContext().Delete(mencao);
            }
            foreach (var mencao in BuscarPessoasMencionada(documentoDTO))
            {
                DataContext.ObterDataContext().InsertOrReplace(new PessoaDocumento()
                {
                    Pessoa = mencao.Id,
                    Documento = documento.Id,
                    TipoDeRelacao = TipoRelacao.Consultar("Mencao").Id
                });
            }            
        }

        private DocumentoDTO ObterMencao(Documento documento, DocumentoDTO documentoDTO)
        {
            documentoDTO.NomeMencao = new List<string>();
            documentoDTO.SobrenomeMencao = new List<string>();
            foreach (var mencao in BuscarPessoasVinculadas(documento.Id, "Mencao"))
            {
                documentoDTO.NomeMencao.Add(mencao.Nome);
                documentoDTO.SobrenomeMencao.Add(mencao.Sobrenome);
            }
            return documentoDTO;
        }

        private PessoaDTO BuscarPessoaAutor(DocumentoDTO documentoDTO)
        {
            return Pessoa.Consultar(new PessoaDTO()
            {
                Nome = documentoDTO.NomeAutor,
                Sobrenome = documentoDTO.SobreNomeAutor
            }) ?? throw new Exception("Autor não encontrado!");
        }

        private List<Pessoa> BuscarPessoasMencionada(DocumentoDTO documentoDTO)
        {
            var retorno = new List<Pessoa>();
            for (int i = 0; i < documentoDTO.NomeMencao.Count; i ++)
            {
                retorno.Add(Pessoa.Consultar(documentoDTO.NomeMencao[i], documentoDTO.SobrenomeMencao[i]));
            }
            return retorno;
        }

        private List<Pessoa> BuscarPessoasVinculadas(int? documentoId, string tipoVinculo)
        {
            var relacao = TipoRelacao.Consultar(tipoVinculo);
            var mencoes = DataContext.ObterDataContext().Table<PessoaDocumento>().Where(mencao => mencao.Documento == documentoId && mencao.TipoDeRelacao == relacao.Id);
            var retorno = new List<Pessoa>();
            foreach (var mencao in mencoes)
            {
                retorno.Add(Pessoa.Consultar(mencao.Pessoa));
            }
            return retorno;
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
            documentoDTO = PopularRetorno(documentoDTO, idioma, documento, autor);
            return documentoDTO;
        }

        private DocumentoDTO PopularRetorno(DocumentoDTO documentoDTO, Idioma idioma, Documento documento, Pessoa autor)
        {
            documentoDTO.Nome = documento.Nome;
            documentoDTO.DataRegistro = documento.DataRegistro;
            documentoDTO.DataDigitalizacao = documento.DataDigitalizacao;
            documentoDTO.Idioma = idioma.Nome;
            documentoDTO.NomeAutor = autor.Nome;
            documentoDTO.SobreNomeAutor = autor.Sobrenome;
            documentoDTO = ObterMencao(documento, documentoDTO);

            switch (documentoDTO.GetType().Name)
            {
                case ("AudioDTO"):
                    {
                        (documentoDTO as AudioDTO).Base64 = Audio.Consultar(documento.Id).Base64;
                        break;
                    }
                case ("ImagemDTO"):
                    {
                        (documentoDTO as ImagemDTO).Base64 = Imagem.Consultar(documento.Id).Base64;
                        break;
                    }
                case ("TextoDTO"):
                    {
                        (documentoDTO as TextoDTO).Texto = Texto.Consultar(documento.Id).Corpo;
                        break;
                    }
                case ("VideoDTO"):
                    {
                        (documentoDTO as VideoDTO).Url = Video.Consultar(documento.Id).Url;
                        break;
                    }
                default:
                    throw new Exception("Documento Inválido");
            }

            return documentoDTO;
        }

        public Documento Consultar(DocumentoDTO documentoDTO, int idioma)
        {
            return DataContext.ObterDataContext().Table<Documento>().FirstOrDefault(documentoDB => documentoDB.Nome == documentoDTO.Nome && documentoDB.Idioma == idioma);
        }
    }
}
