using System.Collections.Generic;

namespace BibliotecaViva.DTO
{
    public class ConceitoDTO
    {
        public ConceitoDTO()
        {

        }
        public int? Id { get; set; }
        public int? GlossarioId { get; set; }
        public string Glossario { get; set; }
        public string Nome { get; set; }
        public List<SignificadoDTO> Significados { get; set;}
    }
}