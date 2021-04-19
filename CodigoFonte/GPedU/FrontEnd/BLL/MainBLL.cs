using Godot;
using DTO;
using SAL;
using SAL.Interface;
using BLL.Utils;
using BLL.Interface;
using System.Collections.Generic;


namespace BLL
{
    public class MainBLL : IMainBLL
    {
        private IMainSAL SAL { get; set; }
        private List<IdiomaDTO> Idiomas { get; set; }
        public MainBLL()
        {
            SAL = new MainSAL();
            Idiomas = new List<IdiomaDTO>();
        }

        public void PopularDropDownIdioma(OptionButton idiomaDropDown)
        {
            var idioma = SAL.ObterIdiomas();
            GD.Print(idioma);
            
            idiomaDropDown.AddItem("", 0);
            idiomaDropDown.AddItem("Português Brasil", 1);
            idiomaDropDown.AddItem("Português Portugal", 2);

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