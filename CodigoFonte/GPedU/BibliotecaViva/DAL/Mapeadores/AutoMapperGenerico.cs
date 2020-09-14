using AutoMapper;

namespace BibliotecaViva.DAL.Utils
{
    public static class AutoMapperGenerico
    {
        public static S Mapear<E, S>(E entrada)
        {
            var autoMapper = new MapperConfiguration(cfg => cfg.CreateMap<E, S>()).CreateMapper();
            return autoMapper.Map<S>(entrada);
        }
    }
}