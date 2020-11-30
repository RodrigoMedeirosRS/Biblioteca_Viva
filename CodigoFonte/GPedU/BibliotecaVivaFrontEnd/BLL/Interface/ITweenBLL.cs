using Godot;
namespace BibliotecaViva.BLL.Interface
{
    public interface ITweenBLL
    {
        Node2D TargetNode { get; }
        Tween TargetTween { get; }
        void Mover2D(Vector2 originalPosition, Vector2 finalPosition);
    }
}