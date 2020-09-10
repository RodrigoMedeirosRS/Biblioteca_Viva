using BibliotecaViva.DTO.Model;

namespace BibliotecaViva.DTO
{
    public class PessoaDTO
    {
        public PessoaDTO()
        {

        }
        public Pessoa Dados { get; set; }
        public Genero Genero { get; set; }
        public NomeSocial NomeSocial { get; set; }
        public Apelido Apelido { get; set; }
    }
}