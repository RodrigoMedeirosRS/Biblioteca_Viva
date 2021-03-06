using Godot;
using DTO;
using System.Collections.Generic;

namespace BLL.Interface
{
    public interface IMainBLL
    {
        void ControlarJanela(Node2D windowController, Vector2 mouseMovement, float delta);
        void Zoom(Node2D windowController, float delta);
        void Drag(Node2D windowController, Vector2 mouseMovement, float delta);
    }
}