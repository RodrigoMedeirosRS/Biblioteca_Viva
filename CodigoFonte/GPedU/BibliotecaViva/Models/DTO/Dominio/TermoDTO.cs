namespace BibliotecaViva.Models.DTO.Dominio
{
    public class TermoDTO
    {
        public TermoDTO(string nome, string texto)
        {
            Nome = nome;
            Texto = texto;
            Aceito = false;
            Pessoa = null;
        }

        public TermoDTO(string nome, string texto, PessoaDTO pessoa, bool aceito = false)
        {
            Nome = nome;
            Texto = texto;
            Aceito = aceito;
            Pessoa = pessoa;
        }

        public string Nome { get; set; }
        public string Texto { get; set; }
        public bool Aceito { get; set; }
        public PessoaDTO Pessoa {get; set; }
    }
}