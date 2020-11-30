using Godot;
using BibliotecaViva.BLL.Interface;

namespace BibliotecaViva.BLL
{
    public class TweenBLL : ITweenBLL
    {
        public Node2D TargetNode { get; }
        public Tween TargetTween { get; }

        public TweenBLL(Node2D targetNode, Tween targetTween)
        {
            TargetNode = targetNode;
            TargetTween = targetTween;
        }
        public void Mover2D(Vector2 originalPosition, Vector2 finalPosition)
        {
            TargetTween.InterpolateProperty(TargetNode, "position", originalPosition, finalPosition, 0.5f, 
			Tween.TransitionType.Linear, Tween.EaseType.InOut, 0);
		    TargetTween.Start();
        }
    }
}