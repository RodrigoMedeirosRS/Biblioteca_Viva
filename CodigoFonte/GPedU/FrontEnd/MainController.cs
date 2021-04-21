using System.Collections.Generic;
using BLL;
using BLL.Interface;
using BLL.Utils;
using DTO;
using Godot;

namespace Controller
{
	public class MainController : Result
	{
		public IMainBLL BLL { get; set; }
		private Node2D WindowsControler { get; set; } 
		private Vector2 MouseMovement { get; set; }
		private Vector2 MouseLastMovement { get; set; }
		public MainController()
		{
			MouseMovement = new Vector2(0,0);
			MouseLastMovement = new Vector2(0,0);
		}

		public override void _Ready()
		{
			PopularNodes();
			BLL.RequisitarDadosBasicos();
		}

		private void PopularNodes()
		{
			BLL = new MainBLL(this);
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

		protected override List<IdiomaDTO> ConsultarIdiomaResult(int result, int response_code, string[] headers, byte[] body)
		{
			BLL.Idiomas = base.ConsultarIdiomaResult(result, response_code, headers, body);
			BLL.PopularDropDownIdioma(GetNode<OptionButton>("./Controles/Idioma"));
			return BLL.Idiomas;
		}
	}
}
