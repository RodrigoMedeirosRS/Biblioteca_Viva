using AutoMapper;

namespace BibliotecaViva.Models.DTO.Dominio.Utils
{
    public class AutoMapperGenerico
    {
        public S Mapear<E, S>(E entrada)
        {
            var autoMapper = new MapperConfiguration(cfg => cfg.CreateMap<E, S>()).CreateMapper();
            return autoMapper.Map<S>(entrada);
        }
    }
}