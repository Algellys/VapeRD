using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaVapes.Core.Domain.Entidades
{
    public class InventarioMovimiento
    {
        public int MovimientoId { get; set; }
        public int ProductoId { get; set; }
        public string TipoMovimiento { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }
    }
}
