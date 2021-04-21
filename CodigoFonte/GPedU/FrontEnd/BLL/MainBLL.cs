using Godot;
using DTO;
using SAL;
using BLL.Utils;
using BLL.Interface;
using System.Collections.Generic;


namespace BLL
{
	public class MainBLL : IMainBLL
	{
		public List<IdiomaDTO> Idiomas { get; set; }
		public TipoSAL ServiceTipoSAL { get; set; }
		
		public MainBLL(Result nodoPai)
		{
			ServiceTipoSAL = new TipoSAL(nodoPai);
		}

		public void RequisitarDadosBasicos()
		{
			ServiceTipoSAL.ConsultarIdioma();
		}

		public void PopularDropDownIdioma(OptionButton idiomaDropDown)
		{
			idiomaDropDown.AddItem("", 0);

			foreach(var idioma in Idiomas)
				idiomaDropDown.AddItem(idioma.Nome, (int)idioma.Codigo);

			idiomaDropDown.Select(0);
		}

		public void ControlarJanela(Node2D windowController, Vector2 mouseMovement, float delta)
		{
			Zoom(windowController, delta);
			Drag(windowController, mouseMovement, delta);
		}

		public void Zoom(Node2D windowController, float delta)
		{
			if (InputEventBLL.GetKey(InputAction.ScrollDown, KeyStatus.Released))
				windowController.Scale += new Vector2(0.3f * delta, 0.3f * delta);
			if (InputEventBLL.GetKey(InputAction.ScrollUp, KeyStatus.Released))
				windowController.Scale -= new Vector2(0.3f * delta, 0.3f * delta);
		}
		public void Drag(Node2D windowController, Vector2 mouseMovement, float delta)
		{
			if (InputEventBLL.GetKey(InputAction.LeftClick, KeyStatus.Hold))
			{
				windowController.MoveLocalX(mouseMovement.x);
				windowController.MoveLocalY(mouseMovement.y);
			}
		}
	}
}
