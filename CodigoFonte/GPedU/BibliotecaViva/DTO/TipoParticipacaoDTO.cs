namespace BibliotecaViva.DTO
{
    public class TipoParticipacaoDTO
    {
        public TipoParticipacaoDTO()
        {

        }
        public TipoParticipacaoDTO(int? id)
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