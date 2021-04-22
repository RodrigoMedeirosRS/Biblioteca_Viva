using System;
using System.Collections.Generic;

namespace DTO
{
    public class RegistroDTO : LocalizacaoGeograficaRetornoDTO
    {
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Idioma { get; set; }
        public string Tipo { get; set; }
        public string Conteudo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInsercao { get; set; }
        public List<ReferenciaDTO> Referencias { get; set; }
    }
}