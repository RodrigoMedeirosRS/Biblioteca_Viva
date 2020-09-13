using BibliotecaViva.DTO.Model;
using BibliotecaViva.DAL.Interfaces;

namespace BibliotecaViva.DAL
{
    public class TextoDAL : ITextoDAL
    {
        private ISQLiteDataContext DataContext { get; set; }

        public TextoDAL(ISQLiteDataContext dataContext)
        {
            DataContext = dataContext;
        }
        public void Cadastrar(Texto texto)
        {
            DataContext.ObterDataContext().InsertOrReplace(texto);
        }
        public Texto Consultar(int? documentoId)
        {
            return DataContext.ObterDataContext().Table<Texto>().FirstOrDefault(imagem => imagem.Documento == documentoId);
        }
    }
}
