using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tc_taller.Vehiculos
{
    public partial class Form : System.Web.UI.Page
    {
        private int idVehiculo = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Negocio.Seguridad.EsMecanico())
                Response.Redirect("~/Vehiculos/Listado.aspx");

            if (Request.QueryString["id"] != null)
                idVehiculo = int.Parse(Request.QueryString["id"]);

            if (!IsPostBack)
            {
                CargarClientes();
                if (idVehiculo > 0)
                {
                    lblTitulo.Text = "Editar Vehículo";
                    CargarVehiculo();
                }
            }
        }

        private void CargarClientes()
        {
            var negocio = new ClienteNegocio();
            ddlCliente.DataSource = negocio.Listar();
            ddlCliente.DataTextField = "NombreCompleto";
            ddlCliente.DataValueField = "IdCliente";
            ddlCliente.DataBind();
            ddlCliente.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Seleccione --", "0"));
        }

        private void CargarVehiculo()
        {
            var negocio = new VehiculoNegocio();
            var vehiculo = negocio.Listar().Find(v => v.IdVehiculo == idVehiculo);
            if (vehiculo != null)
            {
                txtPatente.Text = vehiculo.Patente;
                txtMarca.Text = vehiculo.Marca;
                txtModelo.Text = vehiculo.Modelo;
                txtAnio.Text = vehiculo.Anio.ToString();
                txtColor.Text = vehiculo.Color;
                txtKilometraje.Text = vehiculo.Kilometraje.ToString();
                ddlCliente.SelectedValue = vehiculo.Cliente.IdCliente.ToString();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            var vehiculo = new Vehiculo();
            vehiculo.IdVehiculo = idVehiculo;
            vehiculo.Patente = txtPatente.Text.Trim().ToUpper();
            vehiculo.Marca = txtMarca.Text.Trim();
            vehiculo.Modelo = txtModelo.Text.Trim();
            vehiculo.Anio = int.Parse(txtAnio.Text.Trim());
            vehiculo.Color = txtColor.Text.Trim();
            vehiculo.Kilometraje = int.Parse(txtKilometraje.Text.Trim());
            vehiculo.Cliente = new Cliente { IdCliente = int.Parse(ddlCliente.SelectedValue) };

            var negocio = new VehiculoNegocio();
            if (idVehiculo == 0)
                negocio.Agregar(vehiculo);
            else
                negocio.Modificar(vehiculo);

            Response.Redirect("Listado.aspx");
        }
    }
}