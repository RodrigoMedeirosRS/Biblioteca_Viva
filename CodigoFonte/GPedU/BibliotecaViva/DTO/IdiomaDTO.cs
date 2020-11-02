namespace BibliotecaViva.DTO
{
    public class IdiomaDTO
    {
        public IdiomaDTO()
        {
            Id = null;
        }
        public IdiomaDTO(int? id)
        {
            Id = id;
        }
        public int? Id { get; private set; }
        public string Nome { get; set; }
    }
}