using System.Runtime.InteropServices.ComTypes;
using Godot;
using BibliotecaViva.BLL;
using BibliotecaViva.BLL.Interface;

[Tool]
public class ModalController : Node2D
{
	private bool Maximizado { get; set; }
	private Vector2 PosicaoOriginal { get; set; }
	private Vector2 PosicaoCentral { get; set; }
	private ITweenBLL TweenBll { get; set; }
	private AnimationPlayer Animation { get; set; }
	
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
	private ILabelBLL LabelTitulo = new LabelBLL("./Textos/Titulo");

	public override void _Ready()
	{
		Maximizado = false;
		PosicaoCentral = new Vector2(184, -254);
		TweenBll = new TweenBLL(this, GetNode<Tween>("./Tween"));
		Animation = GetNode<AnimationPlayer>("./AnimationPlayer");
		LabelTitulo.PopularLabel(this);
		LabelTitulo.Texto.Text = Titulo;
	}

	private void _on_Text_button_down()
	{
		Maximizado = Maximizado ? Minimizar() : Maximizar();
	}

	private bool Maximizar()
	{
		PosicaoOriginal = this.Position;
		TweenBll.Mover2D(PosicaoOriginal, PosicaoCentral);
		Animation.Play("Maximizado", 0.5f);
		return true;
	}

	private bool Minimizar()
	{
		TweenBll.Mover2D(PosicaoCentral, PosicaoOriginal);
		Animation.Play("Normal", 0.5f);
		return false;
	}


}



