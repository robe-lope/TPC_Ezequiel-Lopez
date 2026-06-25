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
            if (!IsPostBack)
                CargarGrilla();
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
    }
}