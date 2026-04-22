namespace CasoEstudio2.Models
{
    public class CasasModel
    {
        public long IdCasa { get; set; }
        public string DescripcionCasa { get; set; } = string.Empty;
        public decimal PrecioCasa { get; set; }
        public string? UsuarioAlquiler { get; set; }
        public DateTime? FechaAlquiler { get; set; }
        public string Estado => string.IsNullOrEmpty(UsuarioAlquiler) ? "Disponible" : "Reservada";
        public string FechaFormateada => FechaAlquiler.HasValue
            ? FechaAlquiler.Value.ToString("dd/MM/yyyy")
            : "-";
    }
}