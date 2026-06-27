using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Negocio
{
    public class Seguridad
    {
        public static Usuario GetUsuarioActual()
        {
            return HttpContext.Current.Session["usuario"] as Usuario;
        }

        public static bool EsSupervisor()
        {
            var u = GetUsuarioActual();
            return u != null && u.Perfil.Descripcion == "Supervisor";
        }

        public static bool EsAdministracion()
        {
            var u = GetUsuarioActual();
            return u != null && u.Perfil.Descripcion == "Administracion";
        }

        public static bool EsMecanico()
        {
            var u = GetUsuarioActual();
            return u != null && u.Perfil.Descripcion == "Mecanico";
        }

        public static bool PuedeAdministrar()
        {
            return EsSupervisor() || EsAdministracion();
        }
    }
}
