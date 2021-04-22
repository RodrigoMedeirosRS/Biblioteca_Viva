using BLL;
using BLL.Interface;
using Godot;

namespace Controller
{
	public class MainController : Node2D
	{
		public IMainBLL BLL { get; set; }
		private Node2D WindowsControler { get; set; }
		private Node2D WindowTarget { get; set; } 
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
		}

		private void PopularNodes()
		{
			BLL = new MainBLL();
			WindowsControler = GetNode<Node2D>("./Windows");
			WindowTarget = GetNode<Node2D>("./Target");
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
