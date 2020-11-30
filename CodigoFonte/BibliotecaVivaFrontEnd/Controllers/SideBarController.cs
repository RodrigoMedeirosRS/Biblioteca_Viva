using Godot;
using BibliotecaViva.BLL;
using BibliotecaViva.BLL.Interface;

[Tool]
public class SideBarController : Node2D
{
	[Export]
	public string Titulo
	{ 
		get
		{
			return _titulo;
		}
		set 
		{
			_titulo = value;
			LabelTitulo.Atualizar(_titulo, this);
		} 
	}
	private string _titulo { get; set; }
	private ILabelBLL LabelTitulo = new LabelBLL("./Forma/Header/Label");

	public override void _Ready()
	{
		LabelTitulo.PopularLabel(this);
		LabelTitulo.Texto.Text = Titulo;
	}
}
