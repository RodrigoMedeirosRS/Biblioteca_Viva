using System;
using System.Linq;
using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Model;

namespace BibliotecaViva.DAL.Interfaces
{
    public class DocumentoDAL : IDocumentoDAL
    {
        private ISQLiteDataContext DataContext { get; set; }
        private IIdiomaDAL Idioma { get; set; }

        public DocumentoDAL(ISQLiteDataContext dataContext, IIdiomaDAL idioma)
        {
            DataContext = dataContext;
            Idioma = idioma;
        }

        public void Cadastrar(DocumentoDTO documentoDTO)
        {
            var idioma = Idioma.Consultar(documentoDTO.Idioma).Id;
            var documento = Mapeadores.Mapeador.MapearCabecalhoDocumento(documentoDTO, idioma, VerificarJaRegistrado(documentoDTO, idioma));
            DataContext.ObterDataContext().InsertOrReplace(documento);
        }

        private int? VerificarJaRegistrado(DocumentoDTO documentoDTO, int idioma)
        {
            var documentoCadastrado = Consultar(documentoDTO, idioma);
            return documentoCadastrado != null ? documentoCadastrado.Id : null;
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
