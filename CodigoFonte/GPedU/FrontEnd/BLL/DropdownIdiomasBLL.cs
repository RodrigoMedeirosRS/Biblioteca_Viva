using SAL;
using DTO;
using Godot;
using BLL.Interface;
using System.Collections.Generic;

namespace BLL
{
    public class DropdownIdiomasBLL : IDropdownIdiomasBLL
    {
        protected HTTPRequest Request { get; set; }
        public OptionButton DropDown { get; set; }
		
		public DropdownIdiomasBLL(OptionButton dropdown)
		{
            DropDown = dropdown;
            Request = new HTTPRequest();
            DropDown.AddChild(Request);
		}

        public void ObterIdiomas()
	    {
            StaticSAL.CriarRequest("ConsultarIdiomaResult", "/Api/Tipo/ConsultarIdiomas", "Idioma", DropDown, Request);
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