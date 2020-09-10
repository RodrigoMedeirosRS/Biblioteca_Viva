using BibliotecaViva.DTO.Model;

namespace BibliotecaViva.DTO
{
    public class PessoaDTO
    {
        public PessoaDTO()
        {
            Id = null;
        }

        private int? Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Genero { get; set; }
        public string Apelido { get; set; }
        public string NomeSocial { get; set; }

        public int? GetId()
        {
            return Id;
        }

        public void SetId(int? id)
        {
            Id = id;
        }
    }
}