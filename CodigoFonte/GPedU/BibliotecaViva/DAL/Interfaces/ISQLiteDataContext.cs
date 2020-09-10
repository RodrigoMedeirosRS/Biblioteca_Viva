using System.Data.SQLite.Tools;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface ISQLiteDataContext
    {
        SQLiteConnection ObterDataContext();
    }
}
