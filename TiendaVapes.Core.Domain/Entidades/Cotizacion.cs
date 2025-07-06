using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaVapes.Core.Domain.Entidades
{
    public class Cotizacion
    {
        public int CotizacionId { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
    }
}
