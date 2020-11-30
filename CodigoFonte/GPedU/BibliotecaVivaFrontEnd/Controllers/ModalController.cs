using Godot;
using System;

public class ModalController : Node2D
{
	private bool Maximizado { get; set; }
	private Vector2 PosicaoOriginal { get; set; }
	private Vector2 PosicaoCentral { get; set; }
	private Tween Move { get; set; }
	private AnimationPlayer Animation { get; set; }
	public override void _Ready()
	{
		Maximizado = false;
		PosicaoCentral = new Vector2(184, -254);
		Move = GetNode<Tween>("./Tween");
		Animation = GetNode<AnimationPlayer>("./AnimationPlayer");
	}

	public override void _Process(float delta)
	{
		GD.Print(this.Position);
	}

	

	private void _on_Text_button_down()
	{
		Maximizado = Maximizado ? Minimizar() : Maximizar();
	}

	private bool Maximizar()
	{
		PosicaoOriginal = this.Position;
		Mover(PosicaoCentral);
		Animation.Play("Maximizado", 0.5f);
		return true;
	}

	private bool Minimizar()
	{
		Mover(PosicaoOriginal);
		Animation.Play("Normal", 0.5f);
		return false;
	}

	private void Mover(Vector2 finalPosition)
	{
		Move.InterpolateProperty(this, "position", this.Position, finalPosition, 0.5f, 
			Tween.TransitionType.Linear, Tween.EaseType.InOut, 0);
		Move.Start();
	}
}



