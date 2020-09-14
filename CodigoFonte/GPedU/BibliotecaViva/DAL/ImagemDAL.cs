using BibliotecaViva.DTO.Model;
using BibliotecaViva.DAL.Interfaces;

namespace BibliotecaViva.DAL
{
    public class ImagemDAL : IImagemDAL
    {
        private ISQLiteDataContext DataContext { get; set; }

        public ImagemDAL(ISQLiteDataContext dataContext)
        {
            DataContext = dataContext;
        }
        public void Cadastrar(Imagem imagem)
        {
            DataContext.ObterDataContext().InsertOrReplace(imagem);
        }
        public Imagem Consultar(int? documentoId)
        {
            return DataContext.ObterDataContext().Table<Imagem>().FirstOrDefault(imagem => imagem.Documento == documentoId);
        }
    }
}
