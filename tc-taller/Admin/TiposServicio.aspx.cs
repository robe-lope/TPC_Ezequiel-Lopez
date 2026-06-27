using Negocio;
using System;
using Dominio;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tc_taller.Admin
{
    public partial class TipoServicio : System.Web.UI.Page
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
            var negocio = new TipoServicioNegocio();
            gvTipos.DataSource = negocio.Listar();
            gvTipos.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            var tipo = new Dominio.TipoServicio();
            tipo.Descripcion = txtDescripcion.Text.Trim();
            tipo.IdTipoServicio = int.Parse(hfId.Value);

            var negocio = new TipoServicioNegocio();
            if (tipo.IdTipoServicio == 0)
                negocio.Agregar(tipo);
            else
                negocio.Modificar(tipo);

            LimpiarForm();
            CargarGrilla();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            var btn = (System.Web.UI.WebControls.LinkButton)sender;
            int id = int.Parse(btn.CommandArgument);
            var negocio = new TipoServicioNegocio();
            var tipo = negocio.Listar().Find(t => t.IdTipoServicio == id);
            if (tipo != null)
            {
                hfId.Value = tipo.IdTipoServicio.ToString();
                txtDescripcion.Text = tipo.Descripcion;
                lblTitulo.Text = "Editar Tipo de Servicio";
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            var btn = (System.Web.UI.WebControls.LinkButton)sender;
            int id = int.Parse(btn.CommandArgument);
            var negocio = new TipoServicioNegocio();
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
            lblTitulo.Text = "Nuevo Tipo de Servicio";
        }
    }
}