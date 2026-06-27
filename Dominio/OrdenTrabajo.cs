using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class OrdenDeTrabajo
    {
        public int IdOrden { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaEstimada { get; set; }
        public DateTime? FechaCierre { get; set; }
        public string Descripcion { get; set; }
        public int KilometrajeIngreso { get; set; }
        public EstadoOT Estado { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public Usuario Mecanico { get; set; }
        public Usuario UsuarioCreador { get; set; }
        public List<LineaOT> Lineas { get; set; }

        public OrdenDeTrabajo()
        {
            Lineas = new List<LineaOT>();
        }

        public decimal Total
        {
            get
            {
                decimal total = 0;
                if (Lineas != null)
                    foreach (var l in Lineas)
                        total += l.Subtotal;
                return total;
            }
        }
    }
}
