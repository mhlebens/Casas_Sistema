namespace CasoEstudio2.Models
{
    public class CasasModel
    {
        public long IdCasa { get; set; }
        public string DescripcionCasa { get; set; } = string.Empty;
        public decimal PrecioCasa { get; set; }
        public string UsuarioAlquiler { get; set; } = string.Empty;
        public DateTime FechaAlquiler { get; set; }
    }
}
