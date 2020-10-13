using System.Collections.Generic;

namespace BibliotecaViva.DTO
{
    public class LinhaDoTempoDTO
    {
        public LinhaDoTempoDTO()
        {
            Id = null;
        }
        public LinhaDoTempoDTO(int? id)
        {
            Id = id;
        }
        public int? Id { get; protected set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<PessoaDTO> Pessoas { get; set; }
        public List<DocumentoDTO> Documentos { get; set; }
    }
}