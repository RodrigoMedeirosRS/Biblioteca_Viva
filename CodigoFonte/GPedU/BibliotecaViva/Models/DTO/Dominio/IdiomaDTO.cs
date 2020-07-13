namespace BibliotecaViva.Models.DTO.Dominio
{
    public class IdiomaDTO
    {
        public IdiomaDTO(string nome)
        {
            Nome = nome;
        }
        public IdiomaDTO(int id, string nome)
        {
            ID = id;
            Nome = nome;
        }
        public int ID { get; set; }
        public string Nome { get; set; }
    }
}