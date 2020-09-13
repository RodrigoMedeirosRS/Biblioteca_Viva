using BibliotecaViva.DTO.Model;
using BibliotecaViva.DAL.Interfaces;

namespace BibliotecaViva.DAL
{
    public class VideoDAL : IVideoDAL
    {
        private ISQLiteDataContext DataContext { get; set; }

        public VideoDAL(ISQLiteDataContext dataContext)
        {
            DataContext = dataContext;
        }
        public void Cadastrar(Video video)
        {
            DataContext.ObterDataContext().InsertOrReplace(video);
        }
        public Video Consultar(int? documentoId)
        {
            return DataContext.ObterDataContext().Table<Video>().FirstOrDefault(imagem => imagem.Documento == documentoId);
        }
    }
}
