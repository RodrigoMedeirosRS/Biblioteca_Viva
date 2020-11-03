namespace BibliotecaViva.DTO.Dominio
{
    public class VincularPessoaEntrada
    {
        public PessoaConsulta Pessoa { get; set; } 
        public EventoConsulta Evento { get; set; }
        public TipoParticipacaoDTO TipoParticipacao { get; set; }
    }
}