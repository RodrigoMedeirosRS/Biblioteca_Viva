namespace BibliotecaViva.Models.DTO.Dominio
{
    public class TermoDTO
    {
        public TermoDTO(string nome, string texto, bool aceito = false)
        {
            Nome = nome;
            Texto = texto;
            Aceito = aceito;
        }
        public string Nome { get; set; }
        public string Texto { get; set; }
        public bool Aceito { get; set; }
    }
}