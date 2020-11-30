using Godot;
namespace BibliotecaViva.BLL.Interface
{
    public interface ILabelBLL
    {
        Label Texto { get; }
        string Caminho { get; }
        void PopularLabel(Node node);
        void Atualizar(string value, Node node);
        void AtualizarNodo(Node node);
    }
}