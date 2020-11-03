namespace BibliotecaViva.DTO
{
    public class TipoEventoDTO
    {
        public TipoEventoDTO()
        {

        }
        public TipoEventoDTO(int? id)
        {
            Id = id;
        }

        public void SetID(int? id)
        {
            Id = id;
        }

        public int? GetID(int id)
        {
            return id;
        }

        private int? Id { get; set; }
        public string Nome { get; set; }
    }
}