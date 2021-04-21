using Godot;
using System;

public class WindowController : Node2D
{
	private enum Animations { Maximized, Minimized, Normal}
	private Animations LastAnimation { get; set; }
	private AnimationPlayer Window { get; set; }

	public WindowController()
	{
		LastAnimation = Animations.Normal;
	}
	public override void _Ready()
	{
		Window = GetNode<AnimationPlayer>("./AnimationPlayer");
	}

	private void _on_Header_button_up()
	{
		if (LastAnimation == Animations.Normal || LastAnimation == Animations.Minimized)
		{
			Window.Play(Animations.Maximized.ToString());
			LastAnimation = Animations.Maximized;
		}
		else
		{
			Window.Play(Animations.Minimized.ToString());
			LastAnimation = Animations.Minimized;
		}

	}
}
