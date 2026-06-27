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
    public partial class Detalle : System.Web.UI.Page
    {
        private int idOrden = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
                idOrden = int.Parse(Request.QueryString["id"]);

            if (!IsPostBack)
            {
                CargarOT();
                CargarItems();
                CargarLineas();
            }
        }

        private void CargarOT()
        {
            var negocio = new OrdenDeTrabajoNegocio();
            var ot = negocio.getById(idOrden);
            if (ot == null) { Response.Redirect("Listado.aspx"); return; }

            lblIdOrden.Text = ot.IdOrden.ToString();
            lblCliente.Text = ot.Vehiculo.Cliente.NombreCompleto;
            lblVehiculo.Text = $"{ot.Vehiculo.Patente} — {ot.Vehiculo.Marca} {ot.Vehiculo.Modelo}";
            lblMecanico.Text = ot.Mecanico.NombreCompleto;
            lblFecha.Text = ot.FechaIngreso.ToString("dd/MM/yyyy");
            lblKm.Text = ot.KilometrajeIngreso + " km";
            lblDescripcion.Text = ot.Descripcion;

            spanEstado.InnerHtml = $"<span class='{GetBadgeClass(ot.Estado.Descripcion)}'>{ot.Estado.Descripcion}</span>";

            // Botones según estado
            var usuario = (Usuario)Session["usuario"];
            bool esMecanico = usuario.Perfil.Descripcion == "Mecanico";
            bool esAdmin = usuario.Perfil.Descripcion == "Administracion" || usuario.Perfil.Descripcion == "Supervisor";

            switch (ot.Estado.IdEstado)
            {
                case 1: // Abierta
                    btnEnProceso.Visible = esMecanico;
                    panelLinea.Visible = false;
                    break;
                case 2: // En Proceso
                    btnResolver.Visible = esMecanico;
                    panelLinea.Visible = esMecanico;
                    break;
                case 3: // Resuelta
                    btnCerrar.Visible = esAdmin;
                    panelLinea.Visible = false;
                    break;
                case 4: // Cerrada
                    panelLinea.Visible = false;
                    btnReabrir.Visible = Seguridad.EsSupervisor();
                    break;
            }
        }

        private void CargarItems()
        {
            CargarItemsPorTipo(ddlTipoLinea.SelectedValue);
        }

        private void CargarItemsPorTipo(string tipo)
        {
            ddlItem.Items.Clear();
            if (tipo == "Servicio")
            {
                var negocio = new ServicioNegocio();
                var lista = negocio.Listar();
                ddlItem.DataSource = lista;
                ddlItem.DataTextField = "Descripcion";
                ddlItem.DataValueField = "IdServicio";
                ddlItem.DataBind();

                // Precargar precio
                if (lista.Count > 0)
                    txtPrecio.Text = lista[0].PrecioBase.ToString();
            }
            else
            {
                var negocio = new RepuestoNegocio();
                var lista = negocio.Listar();
                ddlItem.DataSource = lista;
                ddlItem.DataTextField = "Descripcion";
                ddlItem.DataValueField = "IdRepuesto";
                ddlItem.DataBind();

                if (lista.Count > 0)
                    txtPrecio.Text = lista[0].PrecioVenta.ToString();
            }
        }

        private void CargarLineas()
        {
            var negocio = new OrdenDeTrabajoNegocio();
            var lineas = negocio.listarLineas(idOrden);
            gvLineas.DataSource = lineas;
            gvLineas.DataBind();

            decimal total = lineas.Sum(l => l.Subtotal);
            lblTotal.Text = total.ToString("C");
        }

        protected void ddlTipoLinea_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarItemsPorTipo(ddlTipoLinea.SelectedValue);
        }

        protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal precio = 0;
            if (ddlTipoLinea.SelectedValue == "Servicio")
            {
                var negocio = new ServicioNegocio();
                var lista = negocio.Listar();
                var servicio = lista.Find(s => s.IdServicio.ToString() == ddlItem.SelectedValue);
                if (servicio != null)
                    precio = servicio.PrecioBase;
            }
            else
            {
                var negocio = new RepuestoNegocio();
                var lista = negocio.Listar();
                var repuesto = lista.Find(r => r.IdRepuesto.ToString() == ddlItem.SelectedValue);
                if (repuesto != null)
                    precio = repuesto.PrecioVenta;
            }
            
            txtPrecio.Text = precio.ToString();
        }
        

        protected void btnAgregarLinea_Click(object sender, EventArgs e)
        {
            var linea = new LineaOT();
            linea.IdOrden = idOrden;
            linea.TipoLinea = ddlTipoLinea.SelectedValue;
            linea.Cantidad = int.Parse(txtCantidad.Text.Trim());
            linea.PrecioUnitario = decimal.Parse(txtPrecio.Text.Trim());

            if (linea.TipoLinea == "Servicio")
                linea.Servicio = new Servicio { IdServicio = int.Parse(ddlItem.SelectedValue) };
            else
                linea.Repuesto = new Repuesto { IdRepuesto = int.Parse(ddlItem.SelectedValue) };

            var negocio = new OrdenDeTrabajoNegocio();
            negocio.agregarLinea(linea);
            CargarLineas();
        }

        protected void btnEliminarLinea_Click(object sender, EventArgs e)
        {
            var btn = (System.Web.UI.WebControls.LinkButton)sender;
            int idLinea = int.Parse(btn.CommandArgument);
            var negocio = new OrdenDeTrabajoNegocio();
            negocio.eliminarLinea(idLinea);
            CargarLineas();
        }

        protected void btnEnProceso_Click(object sender, EventArgs e)
        {
            var negocio = new OrdenDeTrabajoNegocio();
            negocio.cambiarEstado(idOrden, 2);
            Response.Redirect("Detalle.aspx?id=" + idOrden);
        }

        protected void btnResolver_Click(object sender, EventArgs e)
        {
            var negocio = new OrdenDeTrabajoNegocio();
            negocio.cambiarEstado(idOrden, 3);
            Response.Redirect("Detalle.aspx?id=" + idOrden);
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            var negocio = new OrdenDeTrabajoNegocio();
            negocio.cerrar(idOrden);
           
            var aux = negocio.getById(idOrden);
            if(!string.IsNullOrEmpty(aux.Vehiculo.Cliente.Email)) 
            {
                var lineas = negocio.listarLineas(idOrden);
                decimal total = 0;
                foreach (var l in lineas)
                    total += l.Subtotal;
                var mail = new MailNegocio();
                mail.EnviarMailOTCerrada(aux.Vehiculo.Cliente.Email, aux.Vehiculo.Cliente.Nombre, idOrden, total);
            }
            Response.Redirect("Detalle.aspx?id=" + idOrden);
        }
        protected void btnReabrir_Click(object sender, EventArgs e)
        {
            var negocio = new OrdenDeTrabajoNegocio();
            negocio.reabrir(idOrden);
            Response.Redirect("Detalle.aspx?id=" + idOrden);
        }
        protected string GetBadgeClass(string estado)
        {
            switch (estado)
            {
                case "Abierta": return "badge bg-secondary fs-6";
                case "En Proceso": return "badge bg-primary fs-6";
                case "Resuelta": return "badge bg-warning text-dark fs-6";
                case "Cerrada": return "badge bg-success fs-6";
                default: return "badge bg-secondary fs-6";
            }
        }
    }
}