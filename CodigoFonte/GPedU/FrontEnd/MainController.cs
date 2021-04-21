using BLL;
using Godot;

namespace Controller
{
	public class MainController : ServiceController
	{
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
			BLL = new MainBLL(this);
			Request = new HTTPRequest();
			this.AddChild(Request);
			CriarRequest();
		}

		private void PopularNodes()
		{
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
}
