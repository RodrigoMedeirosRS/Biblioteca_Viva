using DTO;
using System.Collections.Generic;

namespace BLL.Interface
{
    public interface IDropdownIdiomasBLL
    {
        void ObterIdiomas();
        void PopularDropDownIdioma(List<IdiomaDTO> idiomas);
    }
}