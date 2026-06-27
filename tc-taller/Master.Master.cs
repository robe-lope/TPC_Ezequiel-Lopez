using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tc_taller
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                var usuario = (Usuario)Session["usuario"];
                lblUsuario.Text = $"👤 {usuario.NombreCompleto} ({usuario.Perfil.Descripcion})";
                btnSalir.Visible = true;
                linkLogin.Visible = false;
                string perfil = usuario.Perfil.Descripcion;
                if (perfil == "Mecanico")
                {
                    menuUsuarios.Visible = false;
                    menuAdmin.Visible = false;
                }
                if (perfil == "Administracion") menuUsuarios.Visible = false;
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("/Login.aspx");
        }
    }
}