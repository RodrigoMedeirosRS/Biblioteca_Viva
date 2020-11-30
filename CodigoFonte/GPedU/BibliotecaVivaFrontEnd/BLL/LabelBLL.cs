using Godot;
using BibliotecaViva.BLL.Interface;

namespace BibliotecaViva.BLL
{
    public class LabelBLL : ILabelBLL
    {
        public Label Texto { get; private set; }
        public string Caminho { get; private set; }
        public LabelBLL(string caminho)
        {
            Caminho = caminho;
        }
        public void PopularLabel(Node node)
        {
            if (Texto == null)
			    Texto = node.GetNode<Label>(Caminho);
        }
        public void Atualizar(string value, Node node)
        {
            if (node.IsInsideTree() && Engine.EditorHint)
		    {
			    PopularLabel(node);
			    Texto.Text = string.IsNullOrEmpty(value) ? "Titulo" : value;
                
			    AtualizarNodo(node);
		    }
        }

        public void AtualizarNodo(Node node)
        {
            switch (node.GetType().Name)
            {
                case("Node2D"):
                    (node as Node2D).Update();
                    break;
                case("Control"):
                    (node as Node2D).Update();
                    break;
            }
        }

    }
}