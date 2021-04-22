using DTO;
using BLL;
using Godot;
using System;
using BLL.Interface;

public class WindowController : Node2D
{
	private enum Animations { Maximized, Minimized, Normal, Close }
	private Animations LastAnimation { get; set; }
	private AnimationPlayer Window { get; set; }
	private TextureButton Header {get; set; }
	private Node2D Texto { get; set; }
	private IWindowBLL BLL { get; set; }

	public override void _Ready()
	{
		BLL = new WindowBLL();
		LastAnimation = Animations.Normal;
		Window = GetNode<AnimationPlayer>("./AnimationPlayer");
		Texto = GetNode<Node2D>("./LabelsDeExibicao/Texto");
	}

	private void _on_Header_button_down()
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
	private void _on_Close_button_down()
	{
		Window.Play(Animations.Close.ToString());
	}
	
	private void _on_AnimationPlayer_animation_finished(String anim_name)
	{
		if(anim_name == "Close")
			QueueFree();
	}

	public void ExibirPessoa(PessoaDTO pessoaDTO)
	{
		Texto.Visible = true;
		BLL.ExibirPessoa(pessoaDTO, GetNode<Label>("./LabelsDeExibicao/Titulo"), 
		GetNode<RichTextLabel>("./LabelsDeExibicao/Descricao"), 
		GetNode<RichTextLabel>("./LabelsDeExibicao/Texto/CorpoDoTexto"));
	}

	public void ExibirRegistro(RegistroDTO registroDTO)
	{
		Texto.Visible = true;
		BLL.ExibirRegistro(registroDTO, GetNode<Label>("./LabelsDeExibicao/Titulo"), 
		GetNode<RichTextLabel>("./LabelsDeExibicao/Descricao"), 
		GetNode<RichTextLabel>("./LabelsDeExibicao/Texto/CorpoDoTexto"));
	}
}
