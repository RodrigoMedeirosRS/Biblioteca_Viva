namespace BibliotecaViva.Models.DTO.Dominio
{
    public class PessoaDTO
    {
        public PessoaDTO(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
        }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
    }
}