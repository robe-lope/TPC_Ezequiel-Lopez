using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tc_taller.Clientes
{
    public partial class Form : System.Web.UI.Page
    {
        private int idCliente = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
                idCliente = int.Parse(Request.QueryString["id"]);

            if (!IsPostBack)
            {
                if (idCliente > 0)
                {
                    lblTitulo.Text = "Editar Cliente";
                    CargarCliente();
                }
            }
        }

        private void CargarCliente()
        {
            var negocio = new ClienteNegocio();
            var cliente = negocio.Listar().Find(c => c.IdCliente == idCliente);
            if (cliente != null)
            {
                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtDNI.Text = cliente.DNI;
                txtTelefono.Text = cliente.Telefono;
                txtEmail.Text = cliente.Email;
                txtDireccion.Text = cliente.Direccion;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            var cliente = new Cliente
            {
                IdCliente = idCliente,
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                DNI = txtDNI.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Direccion = txtDireccion.Text.Trim()
            };

            var negocio = new ClienteNegocio();
            if (idCliente == 0)
                negocio.Agregar(cliente);
            else
                negocio.Modificar(cliente);

            Response.Redirect("Listado.aspx");
        }
    }
}
