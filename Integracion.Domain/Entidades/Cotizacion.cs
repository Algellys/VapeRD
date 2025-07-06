using System;
using System.Text.Json.Serialization;

namespace TiendaVapes.Integracion.Domain.Entidades
{
    public class Cotizacion
    {
        [JsonPropertyName("cotizacionId")]
        public int CotizacionId { get; set; }

        [JsonPropertyName("clienteId")]
        public int ClienteId { get; set; }

        [JsonPropertyName("fecha")]
        public DateTime Fecha { get; set; }
    }
}
