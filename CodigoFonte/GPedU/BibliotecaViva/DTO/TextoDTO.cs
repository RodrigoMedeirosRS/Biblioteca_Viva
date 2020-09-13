using BibliotecaViva.DTO.Model;

namespace BibliotecaViva.DTO
{
    public class TextoDTO : DocumentoDTO
    {
        public TextoDTO()
        {

        }
        public TextoDTO(Documento documento, string idioma, Pessoa autor, string texto) : base(documento, idioma, autor)
        {
            Texto = texto;
        }
        public string Texto { get; set; }
    }
}