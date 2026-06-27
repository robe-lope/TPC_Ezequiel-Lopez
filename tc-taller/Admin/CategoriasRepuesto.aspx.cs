using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tc_taller.Admin
{
    public partial class CategoriaRepuesto : System.Web.UI.Page
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
            var negocio = new CategoriaRepuestoNegocio();
            gvCategorias.DataSource = negocio.Listar();
            gvCategorias.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            var categoria = new Dominio.CategoriaRepuesto();
            categoria.Descripcion = txtDescripcion.Text.Trim();
            categoria.IdCategoria = int.Parse(hfId.Value);

            var negocio = new CategoriaRepuestoNegocio();
            if (categoria.IdCategoria == 0)
                negocio.Agregar(categoria);
            else
                negocio.Modificar(categoria);

            LimpiarForm();
            CargarGrilla();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            var btn = (System.Web.UI.WebControls.LinkButton)sender;
            int id = int.Parse(btn.CommandArgument);
            var negocio = new CategoriaRepuestoNegocio();
            var cat = negocio.Listar().Find(c => c.IdCategoria == id);
            if (cat != null)
            {
                hfId.Value = cat.IdCategoria.ToString();
                txtDescripcion.Text = cat.Descripcion;
                lblTitulo.Text = "Editar Categoría";
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            var btn = (System.Web.UI.WebControls.LinkButton)sender;
            int id = int.Parse(btn.CommandArgument);
            var negocio = new CategoriaRepuestoNegocio();
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
            txtDescripcion.Text = "";
            lblTitulo.Text = "Nueva Categoría";
        }
    }
}