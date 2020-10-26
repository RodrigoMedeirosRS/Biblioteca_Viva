namespace BibliotecaViva.DTO
{
    public class GlossarioDTO
    {
        public GlossarioDTO()
        {
            Id = null;
        }
        public GlossarioDTO(int? id)
        {
            Id = id;
        }
        public int? Id { get; private set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}