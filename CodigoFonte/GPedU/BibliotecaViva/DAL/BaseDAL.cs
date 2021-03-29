using AutoMapper;
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

        public S Mapear<E, S>(E entrada)
        {
            var autoMapper = new MapperConfiguration(cfg => cfg.CreateMap<E, S>()).CreateMapper();
            return autoMapper.Map<S>(entrada);
        }
    }
}