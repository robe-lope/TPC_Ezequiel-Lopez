using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tc_taller.Clientes
{
    public partial class Listado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarClientes();
        }

        private void CargarClientes()
        {
            var negocio = new ClienteNegocio();
            gvClientes.DataSource = negocio.Listar();
            gvClientes.DataBind();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            var btn = (System.Web.UI.WebControls.Button)sender;
            int id = int.Parse(btn.CommandArgument);
            var negocio = new ClienteNegocio();
            negocio.Eliminar(id);
            CargarClientes();
        }
    }
}