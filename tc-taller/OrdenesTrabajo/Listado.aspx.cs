using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tc_taller.OrdenesTrabajo
{
    public partial class Listado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Seguridad.GetUsuarioActual() == null)
            {
                Response.Redirect("~/Login.aspx");
                return;
            }

            if (!IsPostBack)
                CargarGrilla();
        }

        private void CargarGrilla()
        {
            var negocio = new OrdenDeTrabajoNegocio();
            var usuario = (Usuario)Session["usuario"];

            if (usuario.Perfil.Descripcion == "Mecanico")
                gvOTs.DataSource = negocio.listarPorMecanico(usuario.IdUsuario);
            else
                gvOTs.DataSource = negocio.listar();

            gvOTs.DataBind();
        }

        protected string GetBadgeClass(string estado)
        {
            switch (estado)
            {
                case "Abierta": return "badge bg-secondary";
                case "En Proceso": return "badge bg-primary";
                case "Resuelta": return "badge bg-warning text-dark";
                case "Cerrada": return "badge bg-success";
                default: return "badge bg-secondary";
            }
        }
    }
}