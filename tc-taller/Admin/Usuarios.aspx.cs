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
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Negocio.Seguridad.EsSupervisor())
                Response.Redirect("~/Default.aspx");
            if (!IsPostBack)
            {
                CargarDropDowns();
                CargarGrilla();
            }
        }

        private void CargarDropDowns()
        {
            var negocio = new PerfilNegocio();
            ddlPerfil.DataSource = negocio.Listar();
            ddlPerfil.DataTextField = "Descripcion";
            ddlPerfil.DataValueField = "IdPerfil";
            ddlPerfil.DataBind();
            ddlPerfil.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Seleccione --", "0"));
        }

        private void CargarGrilla()
        {
            var negocio = new UsuarioNegocio();
            gvUsuarios.DataSource = negocio.Listar();
            gvUsuarios.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            var usuario = new Usuario();
            usuario.IdUsuario = int.Parse(hfId.Value);
            usuario.Nombre = txtNombre.Text.Trim();
            usuario.Apellido = txtApellido.Text.Trim();
            usuario.Email = txtEmail.Text.Trim();
            usuario.Username = txtUsername.Text.Trim();
            usuario.Password = txtPassword.Text.Trim();
            usuario.Perfil = new Perfil { IdPerfil = int.Parse(ddlPerfil.SelectedValue) };

            var negocio = new UsuarioNegocio();
            if (usuario.IdUsuario == 0)
                negocio.Agregar(usuario);
            else
                negocio.Modificar(usuario);

            LimpiarForm();
            CargarGrilla();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            var btn = (System.Web.UI.WebControls.LinkButton)sender;
            int id = int.Parse(btn.CommandArgument);
            var negocio = new UsuarioNegocio();
            var usuario = negocio.Listar().Find(u => u.IdUsuario == id);
            if (usuario != null)
            {
                hfId.Value = usuario.IdUsuario.ToString();
                txtNombre.Text = usuario.Nombre;
                txtApellido.Text = usuario.Apellido;
                txtEmail.Text = usuario.Email;
                txtUsername.Text = usuario.Username;
                CargarDropDowns();
                ddlPerfil.SelectedValue = usuario.Perfil.IdPerfil.ToString();
                lblTitulo.Text = "Editar Usuario";
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            var btn = (System.Web.UI.WebControls.LinkButton)sender;
            int id = int.Parse(btn.CommandArgument);
            var negocio = new UsuarioNegocio();
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
            txtApellido.Text = "";
            txtEmail.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            lblTitulo.Text = "Nuevo Usuario";
            CargarDropDowns();
        }
    }
}