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
    public partial class Servicios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDropDowns();
                CargarGrilla();
            }
        }

        private void CargarDropDowns()
        {
            var negocio = new TipoServicioNegocio();
            ddlTipo.DataSource = negocio.Listar();
            ddlTipo.DataTextField = "Descripcion";
            ddlTipo.DataValueField = "IdTipoServicio";
            ddlTipo.DataBind();
            ddlTipo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Seleccione --", "0"));
        }

        private void CargarGrilla()
        {
            var negocio = new ServicioNegocio();
            gvServicios.DataSource = negocio.Listar();
            gvServicios.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            var servicio = new Servicio();
            servicio.IdServicio = int.Parse(hfId.Value);
            servicio.Descripcion = txtDescripcion.Text.Trim();
            servicio.PrecioBase = decimal.Parse(txtPrecioBase.Text.Trim());
            servicio.TipoServicio = new Dominio.TipoServicio();
            servicio.TipoServicio.IdTipoServicio = int.Parse(ddlTipo.SelectedValue);

            var negocio = new ServicioNegocio();
            if (servicio.IdServicio == 0)
                negocio.Agregar(servicio);
            else
                negocio.Modificar(servicio);

            LimpiarForm();
            CargarGrilla();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            var btn = (System.Web.UI.WebControls.Button)sender;
            int id = int.Parse(btn.CommandArgument);
            var negocio = new ServicioNegocio();
            var servicio = negocio.Listar().Find(s => s.IdServicio == id);
            if (servicio != null)
            {
                hfId.Value = servicio.IdServicio.ToString();
                txtDescripcion.Text = servicio.Descripcion;
                txtPrecioBase.Text = servicio.PrecioBase.ToString();
                CargarDropDowns();
                ddlTipo.SelectedValue = servicio.TipoServicio.IdTipoServicio.ToString();
                lblTitulo.Text = "Editar Servicio";
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            var btn = (System.Web.UI.WebControls.Button)sender;
            int id = int.Parse(btn.CommandArgument);
            var negocio = new ServicioNegocio();
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
            txtPrecioBase.Text = "";
            lblTitulo.Text = "Nuevo Servicio";
            CargarDropDowns();
        }
    }
}
