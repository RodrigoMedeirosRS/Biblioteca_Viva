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

        public DocumentoDAL(ISQLiteDataContext dataContext, IIdiomaDAL idioma, IPessoaDAL pessoa, ITipoRelacaoDAL tipoRelacao)
        {
            DataContext = dataContext;
            Idioma = idioma;
            Pessoa = pessoa;
            TipoRelacao = tipoRelacao;
        }

        public void Cadastrar(DocumentoDTO documentoDTO)
        {
            var idioma = Idioma.Consultar(documentoDTO.Idioma).Id;
            var documento = Mapeadores.Mapeador.MapearCabecalhoDocumento(documentoDTO, idioma, VerificarJaRegistrado(documentoDTO, idioma));
            DataContext.ObterDataContext().InsertOrReplace(documento);
            VincularAutoria(documentoDTO, idioma);
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
            var documento = DataContext.ObterDataContext().Table<Documento>().FirstOrDefault(documentoDB => documentoDB.Nome == documentoDTO.Nome && documentoDB.Idioma == idioma.Id);
            var autor = Pessoa.Consultar(BuscarPessoasVinculadas(documentoDTO, idioma.Id, "Autor", null).First().Pessoa);

            switch (documentoDTO.GetType().Name)
            {
                case ("AudioDTO"):
                    return new AudioDTO(documento, idioma.Nome, autor);
                case ("ImagemDTO"):
                    return new ImagemDTO(documento, idioma.Nome, autor);
                case ("TextoDTO"):
                    return new TextoDTO(documento, idioma.Nome, autor);
                case ("VideoDTO"):
                    return new VideoDTO(documento, idioma.Nome, autor);
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
