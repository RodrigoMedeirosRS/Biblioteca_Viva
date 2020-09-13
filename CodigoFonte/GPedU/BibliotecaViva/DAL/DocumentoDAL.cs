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
            var documento = Consultar(documentoDTO, idioma);
            var tipoRelacao = TipoRelacao.Consultar("Autor");
            var autor = Pessoa.Consultar(new PessoaDTO()
            {
                Nome = documentoDTO.NomeAutor,
                Sobrenome = documentoDTO.SobreNomeAutor
            }) ?? throw new Exception("Autor não encontrado!");
            var autorAnterior = ConsultarRelacaoPessoaDocumento(autor.GetId(), documento.Id, tipoRelacao.Id);

            if (autorAnterior.Count > 0)
                DataContext.ObterDataContext().Delete(autorAnterior.First());

            DataContext.ObterDataContext().Insert(new PessoaDocumento()
            {
                Pessoa = (int)autor.GetId(),
                Documento = (int)documento.Id,
                TipoDeRelacao = tipoRelacao.Id
            });
        }

        private List<PessoaDocumento> ConsultarRelacaoPessoaDocumento(int? idPessoa, int? idDocumento, int idTipoRelacao)
        {
            return DataContext.ObterDataContext().Table<PessoaDocumento>().Where(pessoaDocumento => pessoaDocumento.Pessoa == idPessoa && pessoaDocumento.Documento == idDocumento && pessoaDocumento.TipoDeRelacao == idTipoRelacao).ToList();
        }

        public Documento Consultar(DocumentoDTO documentoDTO)
        {
            var idioma = Idioma.Consultar(documentoDTO.Idioma);
            return DataContext.ObterDataContext().Table<Documento>().FirstOrDefault(documentoDB => documentoDB.Nome == documentoDTO.Nome && documentoDB.Idioma == idioma.Id);
        }

        public Documento Consultar(DocumentoDTO documentoDTO, int idioma)
        {
            return DataContext.ObterDataContext().Table<Documento>().FirstOrDefault(documentoDB => documentoDB.Nome == documentoDTO.Nome && documentoDB.Idioma == idioma);
        }
    }
}
