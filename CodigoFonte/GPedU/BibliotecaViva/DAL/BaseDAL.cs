using BibliotecaViva.DAL.Interfaces;

namespace BibliotecaViva.DAL 
{
    public abstract class BaseDAL : IBaseDAL
    {
        public ISQLiteDataContext DataContext { protected get; set; }

        public BaseDAL(ISQLiteDataContext dataContext)
        {
            DataContext = dataContext;
        }
    }
}