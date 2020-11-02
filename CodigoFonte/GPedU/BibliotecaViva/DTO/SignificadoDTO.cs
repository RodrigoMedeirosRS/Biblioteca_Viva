namespace BibliotecaViva.DTO
{
    public class SignificadoDTO
    {
        public SignificadoDTO()
        {
            Id = null;
        }
        public SignificadoDTO(int? id)
        {
            Id = id;
        }
        public int? Id { get; protected set; }
        public int? Conceito { get; set; }
        public int? Idioma { get; set; }
        public string NomeIdioma { get; set; }
        public string Link { get; set; }
        public string Descricao { get; set; }
    }
}