using System;
using System.Text.Json.Serialization;

namespace TiendaVapes.Integracion.Domain.Entidades
{
    public class Facturas
    {
        [JsonPropertyName("facturaId")]
        public int FacturaId { get; set; }

        [JsonPropertyName("clienteId")]
        public int ClienteId { get; set; }

        [JsonPropertyName("fecha")]
        public DateTime Fecha { get; set; }

        [JsonPropertyName("total")]
        public decimal Total { get; set; }
    }
}
