using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class LineaOT
    {
        public int IdLinea { get; set; }
        public int IdOrden { get; set; }
        public string TipoLinea { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public Servicio Servicio { get; set; }
        public Repuesto Repuesto { get; set; }

        public decimal Subtotal => Cantidad * PrecioUnitario;

        public string Descripcion => TipoLinea == "Servicio"
            ? Servicio?.Descripcion
            : Repuesto?.Descripcion;
    }
}
