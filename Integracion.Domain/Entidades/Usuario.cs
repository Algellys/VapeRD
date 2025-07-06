using System.Text.Json.Serialization;

namespace TiendaVapes.Integracion.Domain.Entidades
{
    public class Usuario
    {
        [JsonPropertyName("usuarioId")]
        public int UsuarioId { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }

        [JsonPropertyName("clave")]
        public string Clave { get; set; }

        [JsonPropertyName("perfilId")]
        public int PerfilId { get; set; }
    }
}
