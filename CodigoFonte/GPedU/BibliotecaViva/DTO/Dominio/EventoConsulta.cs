using System;
namespace BibliotecaViva.DTO.Dominio
{
    public class EventoConsulta
    {
        public string Nome { get; set; }
        public DateTime? DataHora { get; set; }
        public string Localizacao { get; set; }
    }
}