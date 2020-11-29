using Godot;
using System;

[Tool]
public class SideBarController : Node2D
{
	[Export]
	public string Titulo 
	{ 
		get
		{
			PopularLabelTitulo();
			return LabelTitulo.Text;
		}
		set 
		{
			PopularLabelTitulo();
			LabelTitulo.Text = string.IsNullOrEmpty(value) ? "Titulo" : value;
			Atualizar();
		} 
	}
	public Label LabelTitulo { get; set; }

	public override void _Draw()
	{
		PopularLabelTitulo();
	}
	
	public override void _Ready()
	{
		PopularLabelTitulo();
	}

	private void PopularLabelTitulo()
	{
		if (LabelTitulo == null)
			LabelTitulo = GetNode<Label>("./Forma/Header/Label");
	}

	private void Atualizar()
	{
		if (IsInsideTree())
			Update();
	}
}
