using BibliotecaViva.DTO.Model;
using BibliotecaViva.DAL.Interfaces;

namespace BibliotecaViva.DAL
{
    public class AudioDAL : IAudioDAL
    {
        private ISQLiteDataContext DataContext { get; set; }

        public AudioDAL(ISQLiteDataContext dataContext)
        {
            DataContext = dataContext;
        }
        public void Cadastrar(Audio audio)
        {
            DataContext.ObterDataContext().InsertOrReplace(audio);
        }
        public Audio Consultar(int? documentoId)
        {
            return DataContext.ObterDataContext().Table<Audio>().FirstOrDefault(imagem => imagem.Documento == documentoId);
        }
    }
}
