using Godot;

namespace BLL
{
    public static class InstanciadorBLL
    {
        private const string CaminhoJanela = "res://RES/Cenas/Gui/Window.tscn";

        private static PackedScene LoadScene(string path)
        {
            return ResourceLoader.Load(path) as PackedScene;
        }

        public static Node2D InstanciarObjeto(Node nodoPai, Vector2 posicao)
        {
            var janelaInstanciada = LoadScene(CaminhoJanela).Instance();
            nodoPai.AddChild(janelaInstanciada);
            (janelaInstanciada as Node2D).Position = (Vector2)posicao;
            return (janelaInstanciada as Node2D);
        }
    }
}