namespace BibliotecaViva.DAL.Interfaces
{
    public interface IBaseDAL
    {
        ISQLiteDataContext DataContext { set; }
    }
}