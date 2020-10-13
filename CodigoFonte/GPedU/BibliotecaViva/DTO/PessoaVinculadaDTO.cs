namespace BibliotecaViva.DTO
{
    public class PessoaVinculadaDTO : PessoaDTO
    {
        public PessoaVinculadaDTO()
        {
            Id = null;
        }

        public PessoaVinculadaDTO(int? id)
        {
            Id = null;
        }

        public string TipoVinculo { get; set; }
    }
}