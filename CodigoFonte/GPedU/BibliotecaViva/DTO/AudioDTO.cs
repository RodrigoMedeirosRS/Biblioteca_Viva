namespace BibliotecaViva.DTO
{
    public class AudioDTO : DocumentoDTO
    {
        public AudioDTO()
        {
            Id = null;
        }
        public AudioDTO(int? id)
        {
            Id = id;
        }
        public string Base64 { get; set; }
    }
}