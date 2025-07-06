using System;
using System.Text.Json.Serialization;

namespace TiendaVapes.Integracion.Domain.Entidades
{
    public class CuentaPorCobrar
    {
        [JsonPropertyName("cuentaPorCobrarId")]
        public int CuentaPorCobrarId { get; set; }

        [JsonPropertyName("clienteId")]
        public int ClienteId { get; set; }

        [JsonPropertyName("monto")]
        public decimal Monto { get; set; }

        [JsonPropertyName("fecha")]
        public DateTime Fecha { get; set; }
    }
}
