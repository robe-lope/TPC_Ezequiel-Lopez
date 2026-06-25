using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tc_taller
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            var negocio = new UsuarioNegocio();
            var usuario = negocio.Login(txtUsername.Text.Trim(), txtPassword.Text.Trim());

            if (usuario != null)
            {
                Session["usuario"] = usuario;
                Session["perfil"] = usuario.Perfil.Descripcion;
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                lblError.Text = "Usuario o contraseña incorrectos.";
                lblError.Visible = true;
            }
        }
    }
}