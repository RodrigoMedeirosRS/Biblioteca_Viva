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

        public int? GetID()
        {
            return Id;
        }
        private int? Id { get; set; }
        public string Nome { get; set; }
    }
}