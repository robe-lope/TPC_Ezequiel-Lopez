using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tc_taller
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var usuario = (Usuario)Session["usuario"];

                cardRepuestos.Visible = !Seguridad.EsMecanico();
                cardServicios.Visible = !Seguridad.EsMecanico();
                cardUsuarios.Visible = Seguridad.EsSupervisor();
            }
        }
    }
}