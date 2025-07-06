using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaVapes.Core.Domain.Entidades
{
    public class Log
    {
        public int LogId { get; set; }
        public int UsuarioId { get; set; }
        public string Accion { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
    }
}
