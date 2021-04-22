using SAL;
using DTO;
using Godot;
using BLL.Interface;
using System.Collections.Generic;

namespace BLL
{
    public class DropdownIdiomasBLL : IDropdownIdiomasBLL
    {
        public OptionButton DropDown { get; set; }
		
		public DropdownIdiomasBLL(OptionButton dropdown)
		{
            DropDown = dropdown;
		}

        public void ObterIdiomas()
	    {
            var request = new HTTPRequest();
            DropDown.AddChild(request);
            StaticSAL.CriarRequest("ConsultarIdiomaResult", "/Api/Tipo/ConsultarIdiomas", "Idioma", DropDown, request);
	    }

        public void PopularDropDownIdioma(List<IdiomaDTO> idiomas)
		{
			DropDown.AddItem("", 0);

			foreach(var idioma in idiomas)
				DropDown.AddItem(idioma.Nome, (int)idioma.Codigo);

			DropDown.Select(0);
		}
    }
}