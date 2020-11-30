using Godot;
using System;

[Tool]
public class SideBarController : Node2D
{
	[Export]
	public string TituloPreview 
	{ 
		get
		{
			return Titulo;
		}
		set 
		{
			Titulo = value;
			Atualizar(Titulo);
		} 
	}
	public string Titulo { get; set; }

	public Label LabelTitulo { get; set; }

	public override void _Ready()
	{
		PopularLabelTitulo();
		LabelTitulo.Text = Titulo;
	}

	private void PopularLabelTitulo()
	{
		if (LabelTitulo == null)
			LabelTitulo = GetNode<Label>("./Forma/Header/Label");
	}

	private void Atualizar(string value)
	{
		if (IsInsideTree() && Engine.EditorHint)
		{
			PopularLabelTitulo();
			LabelTitulo.Text = string.IsNullOrEmpty(value) ? "Titulo" : value;
			Update();
		}
			
	}
}
