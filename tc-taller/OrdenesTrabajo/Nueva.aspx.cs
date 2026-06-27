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
    public partial class Nueva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Negocio.Seguridad.EsMecanico())
                Response.Redirect("~/Default.aspx");

            if (!IsPostBack)
            {
                CargarClientes();
                CargarMecanicos();
            }
        }

        private void CargarClientes()
        {
            var negocio = new ClienteNegocio();
            ddlCliente.DataSource = negocio.Listar();
            ddlCliente.DataTextField = "NombreCompleto";
            ddlCliente.DataValueField = "IdCliente";
            ddlCliente.DataBind();
            ddlCliente.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Seleccione cliente --", "0"));

            ddlVehiculo.Items.Clear();
            ddlVehiculo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Seleccione cliente primero --", "0"));
        }

        private void CargarMecanicos()
        {
            var negocio = new UsuarioNegocio();
            ddlMecanico.DataSource = negocio.ListarMecanicos();
            ddlMecanico.DataTextField = "NombreCompleto";
            ddlMecanico.DataValueField = "IdUsuario";
            ddlMecanico.DataBind();
            ddlMecanico.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Seleccione --", "0"));
        }

        protected void ddlCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idCliente = int.Parse(ddlCliente.SelectedValue);
            ddlVehiculo.Items.Clear();

            if (idCliente > 0)
            {
                var negocio = new VehiculoNegocio();
                var vehiculos = negocio.ListarPorCliente(idCliente);
                ddlVehiculo.DataSource = vehiculos;
                ddlVehiculo.DataTextField = "Descripcion";
                ddlVehiculo.DataValueField = "IdVehiculo";
                ddlVehiculo.DataBind();
                ddlVehiculo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Seleccione vehículo --", "0"));
            }
            else
            {
                ddlVehiculo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Seleccione cliente primero --", "0"));
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            var usuario = (Dominio.Usuario)Session["usuario"];
            var ot = new OrdenDeTrabajo();
            ot.FechaIngreso = DateTime.Now;
            ot.Descripcion = txtDescripcion.Text.Trim();
            ot.KilometrajeIngreso = int.Parse(txtKilometraje.Text.Trim());
            ot.Vehiculo = new Vehiculo { IdVehiculo = int.Parse(ddlVehiculo.SelectedValue) };
            ot.Mecanico = new Usuario { IdUsuario = int.Parse(ddlMecanico.SelectedValue) };
            ot.UsuarioCreador = usuario;

            if (!string.IsNullOrEmpty(txtFechaEstimada.Text))
                ot.FechaEstimada = DateTime.Parse(txtFechaEstimada.Text);

            var negocio = new OrdenDeTrabajoNegocio();
            int idOrden = negocio.agregar(ot);

            Response.Redirect("Detalle.aspx?id=" + idOrden);
        }
    }
}