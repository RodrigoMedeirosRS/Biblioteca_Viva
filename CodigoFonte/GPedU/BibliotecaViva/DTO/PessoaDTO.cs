using BibliotecaViva.DTO.Model;

namespace BibliotecaViva.DTO
{
    public class PessoaDTO
    {
        public PessoaDTO()
        {
            Id = null;
        }
        public PessoaDTO(int? id)
        {
            Id = id;
        }
        public int? Id { get; protected set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Genero { get; set; }
        public string Apelido { get; set; }
        public string NomeSocial { get; set; }
    }
}