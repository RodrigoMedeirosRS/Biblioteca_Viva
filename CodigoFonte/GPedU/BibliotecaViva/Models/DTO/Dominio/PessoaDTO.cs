namespace BibliotecaViva.Models.DTO.Dominio
{
    public class PessoaDTO
    {
        public PessoaDTO(int? id, string nome, string sobrenome, string genero, string apelido = "", string nomeSocial = "")
        {
            if (id != null)
                ID = (int)id;
            Nome = nome;
            Sobrenome = sobrenome;
            Genero = genero;
            Apelido = apelido;
            NomeSocial = nomeSocial;
        }
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Genero { get; set; }
        public string Apelido { get; set; }
        public string NomeSocial { get; set; }
    }
}