using Godot;
using BLL.Utils;
using BLL.Interface;

namespace BLL
{
    public class MainBLL : IMainBLL
    {
        public void PopularDropDownIdioma(OptionButton idiomaDropDown)
        {
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