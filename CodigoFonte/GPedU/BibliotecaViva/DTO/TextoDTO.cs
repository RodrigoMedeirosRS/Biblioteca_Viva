using BibliotecaViva.DTO.Model;

namespace BibliotecaViva.DTO
{
    public class TextoDTO : DocumentoDTO
    {
        public TextoDTO()
        {
            Id = null;
        }
        public TextoDTO(int? id)
        {
            Id = id;
        }
        public string Texto { get; set; }
    }
}