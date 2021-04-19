namespace BibliotecaViva.DAL.Interfaces
{
    public interface IBaseDAL
    {
        ISQLiteDataContext DataContext { set; }
        S Mapear<E, S>(E entrada);
    }
}