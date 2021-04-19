using BLL;
using BLL.Utils;
using BLL.Interface;

using Godot;
using System;

public class MainController : Node2D
{
	private IMainBLL BLL { get; set; }
	private OptionButton IdiomaDropDown { get; set; }
	private Node2D WindowsControler { get; set; } 
	private Vector2 MouseMovement { get; set; }
	private Vector2 MouseLastMovement { get; set; }

	public MainController()
	{
		BLL = new MainBLL();
		MouseMovement = new Vector2(0,0);
		MouseLastMovement = new Vector2(0,0);
	}

	public override void _Ready()
	{
		PopularNodes();
		BLL.PopularDropDownIdioma(IdiomaDropDown);
	}

	private void PopularNodes()
	{
		IdiomaDropDown = GetNode<OptionButton>("./Controles/Idioma");
		WindowsControler = GetNode<Node2D>("./Windows");
	}

  	public override void _Process(float delta)
	{
		VerificarMouseParado(MouseMovement);
		BLL.ControlarJanela(WindowsControler, MouseMovement, delta);
	}

	public override void _Input(InputEvent @event)
	{
		if (@event.GetType().ToString() == "Godot.InputEventMouseMotion")
			MouseMovement = (@event as InputEventMouseMotion).Relative;
	}

	private void VerificarMouseParado(Vector2 mouseMovement)
	{
		MouseMovement = mouseMovement;
		if (MouseMovement == MouseLastMovement)
			MouseMovement = new Vector2(0,0);
		else
			MouseLastMovement = MouseMovement;
	}
}
