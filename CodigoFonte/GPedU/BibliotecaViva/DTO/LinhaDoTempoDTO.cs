using System.Collections.Generic;

namespace BibliotecaViva.DTO
{
    public class LinhaDoTempoDTO
    {
        public LinhaDoTempoDTO()
        {
            Id = null;
        }
        public int? GetId()
        {
            return Id;
        }
        public void SetId(int? id)
        {
            Id = id;
        }
        private int? Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<PessoaDTO> Pessoas { get; set; }
        public List<CabecalhoDTO> Documentos { get; set; }
    }
}