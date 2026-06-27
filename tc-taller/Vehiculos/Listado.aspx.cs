using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tc_taller.Vehiculos
{
    public partial class Listado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.GetUsuarioActual() == null)
            {
                Response.Redirect("~/Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                btnNuevo.Visible = !Seguridad.EsMecanico();
                CargarGrilla();
            }
        }

        private void CargarGrilla()
        {
            var negocio = new VehiculoNegocio();
            gvVehiculos.DataSource = negocio.Listar();
            gvVehiculos.DataBind();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            var btn = (System.Web.UI.WebControls.Button)sender;
            int id = int.Parse(btn.CommandArgument);
            var negocio = new VehiculoNegocio();
            negocio.Eliminar(id);
            CargarGrilla();
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Form.aspx");

        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            var btn = (System.Web.UI.WebControls.LinkButton)sender;
            Response.Redirect("Form.aspx?id=" + btn.CommandArgument);
        }
    }
}