using BibliotecaViva.DTO;

namespace BibliotecaViva.DTO.Dominio
{
    public class VincularDocumentoEntrada
    {
        public DocumentoConsulta Documento { get; set; }
        public EventoConsulta Evento { get; set; }
    }
}