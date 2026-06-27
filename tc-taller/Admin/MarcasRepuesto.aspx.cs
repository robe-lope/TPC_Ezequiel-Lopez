using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tc_taller.Admin
{
    public partial class MarcasRepuesto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Negocio.Seguridad.EsMecanico())
                Response.Redirect("~/Default.aspx");
            if (!IsPostBack)
                CargarGrilla();
        }

        private void CargarGrilla()
        {
            var negocio = new MarcaRepuestoNegocio();
            gvMarcas.DataSource = negocio.Listar();
            gvMarcas.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            var marca = new MarcaRepuesto();
            marca.Nombre = txtNombre.Text.Trim();
            marca.IdMarca = int.Parse(hfId.Value);

            var negocio = new MarcaRepuestoNegocio();
            if (marca.IdMarca == 0)
                negocio.Agregar(marca);
            else
                negocio.Modificar(marca);

            LimpiarForm();
            CargarGrilla();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            var btn = (System.Web.UI.WebControls.LinkButton)sender;
            int id = int.Parse(btn.CommandArgument);
            var negocio = new MarcaRepuestoNegocio();
            var marca = negocio.Listar().Find(m => m.IdMarca == id);
            if (marca != null)
            {
                hfId.Value = marca.IdMarca.ToString();
                txtNombre.Text = marca.Nombre;
                lblTitulo.Text = "Editar Marca";
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            var btn = (System.Web.UI.WebControls.LinkButton)sender;
            int id = int.Parse(btn.CommandArgument);
            var negocio = new MarcaRepuestoNegocio();
            negocio.Eliminar(id);
            CargarGrilla();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarForm();
        }

        private void LimpiarForm()
        {
            hfId.Value = "0";
            txtNombre.Text = "";
            lblTitulo.Text = "Nueva Marca";
        }
    }
}