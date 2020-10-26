namespace BibliotecaViva.DTO
{
    public class ConceitoDTO
    {
        public ConceitoDTO()
        {
            Id = null;
        }
        public ConceitoDTO(int? id)
        {
            Id = id;
        }
        public int? Id { get; private set; }
        public int? GlossarioId { get; set; }
        public string Glossario { get; set; }
        public string Nome { get; set; }
    }
}