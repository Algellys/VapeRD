using System.Text.Json.Serialization;

namespace TiendaVapes.Integracion.Domain.Entidades
{
    public class Clientes
    {
        [JsonPropertyName("clienteId")]
        public int ClienteId { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }

        [JsonPropertyName("documento")]
        public string Documento { get; set; }
    }
}
