using System.Collections.Generic;

namespace DTO
{
    public class PessoaDTO : LocalizacaoGeograficaRetornoDTO
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Genero { get; set; }
        public string Apelido { get; set; }
        public string NomeSocial { get; set; }
        public List<PessoaRegistroDTO> Relacoes { get; set; }
    }
}