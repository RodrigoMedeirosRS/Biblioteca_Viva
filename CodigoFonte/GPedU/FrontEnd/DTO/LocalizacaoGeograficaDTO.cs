namespace DTO
{
    public class LocalizacaoGeograficaDTO : BaseDTO
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class LocalizacaoGeograficaRetornoDTO : BaseDTO
    {
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}