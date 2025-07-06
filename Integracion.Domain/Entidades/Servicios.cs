using System.Text.Json.Serialization;

namespace TiendaVapes.Integracion.Domain.Entidades
{
    public class Servicios
    {
        [JsonPropertyName("servicioId")]
        public int ServicioId { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }

        [JsonPropertyName("precio")]
        public decimal Precio { get; set; }
    }
}
