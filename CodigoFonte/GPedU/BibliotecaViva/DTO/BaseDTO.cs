namespace BibliotecaViva.DTO
{
    public abstract class BaseDTO
    {
        public BaseDTO()
        {
            Codigo = null;
        }
        public BaseDTO(int? codigo)
        {
            Codigo = codigo;
        }
        public void AtualizarCodigo(int? codigo)
        {
            Codigo = Codigo ?? codigo;
        }

        public void DefinirCodigo(int? codigo)
        {
            Codigo = codigo;
        }

        public int? Codigo { get; protected set; }
    }
}