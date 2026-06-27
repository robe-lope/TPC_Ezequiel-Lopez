<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="tc_taller.OrdenesTrabajo.Detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mb-3">
        <div class="col">
            <h3>OT #<asp:Label ID="lblIdOrden" runat="server" /></h3>
            <span id="spanEstado" runat="server"></span>
        </div>
        <div class="col text-end">
            <a href="Listado.aspx" class="btn btn-secondary">← Volver</a>
        </div>
    </div>

    <%-- Info de la OT --%>
    <div class="card p-4 mb-4">
        <div class="row">
            <div class="col-md-3">
                <strong>Cliente:</strong><br />
                <asp:Label ID="lblCliente" runat="server" />
            </div>
            <div class="col-md-3">
                <strong>Vehículo:</strong><br />
                <asp:Label ID="lblVehiculo" runat="server" />
            </div>
            <div class="col-md-3">
                <strong>Mecánico:</strong><br />
                <asp:Label ID="lblMecanico" runat="server" />
            </div>
            <div class="col-md-3">
                <strong>Fecha ingreso:</strong><br />
                <asp:Label ID="lblFecha" runat="server" />
            </div>
            <div class="col-md-3 mt-2">
                <strong>Kilometraje:</strong><br />
                <asp:Label ID="lblKm" runat="server" />
            </div>
            <div class="col-md-6 mt-2">
                <strong>Descripción:</strong><br />
                <asp:Label ID="lblDescripcion" runat="server" />
            </div>
        </div>
    </div>

    <%-- Botones de estado --%>
    <div class="mb-4 d-flex gap-2">
        <asp:Button ID="btnEnProceso" runat="server" Text="▶ Iniciar Trabajo"
            CssClass="btn btn-primary" OnClick="btnEnProceso_Click" Visible="false" />
        <asp:Button ID="btnResolver" runat="server" Text="✔ Marcar Resuelta"
            CssClass="btn btn-warning" OnClick="btnResolver_Click" Visible="false" />
        <asp:Button ID="btnCerrar" runat="server" Text="✖ Cerrar OT"
            CssClass="btn btn-success" OnClick="btnCerrar_Click" Visible="false"
            OnClientClick="return confirm('¿Cerrar esta OT?');" />
        <asp:Button ID="btnReabrir" runat="server" Text="↩ Reabrir OT"
            CssClass="btn btn-danger" OnClick="btnReabrir_Click" Visible="false"
            OnClientClick="return confirm('¿Reabrir esta OT?');" />
    </div>

    <%-- Agregar línea --%>
    <div class="card p-4 mb-4" id="panelLinea" runat="server">
        <h5>Agregar línea</h5>
        <div class="row">
            <div class="col-md-3 mb-3">
                <label class="form-label">Tipo</label>
                <asp:DropDownList ID="ddlTipoLinea" runat="server" CssClass="form-select"
                    AutoPostBack="true" OnSelectedIndexChanged="ddlTipoLinea_SelectedIndexChanged">
                    <asp:ListItem Value="Servicio">Servicio</asp:ListItem>
                    <asp:ListItem Value="Repuesto">Repuesto</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-4 mb-3">
                <label class="form-label">Item</label>
                <asp:DropDownList ID="ddlItem" runat="server" CssClass="form-select" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged" AutoPostBack="true" />
            </div>
            <div class="col-md-2 mb-3">
                <label class="form-label">Cantidad</label>
                <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" Text="1" />
                
            </div>
            <div class="col-md-2 mb-3">
                <label class="form-label">Precio unit.</label>
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" ReadOnly="true" />
            </div>
            <div class="col-md-1 mb-3 d-flex align-items-end">
                <asp:Button ID="btnAgregarLinea" runat="server" Text="+" 
                    CssClass="btn btn-success w-100" OnClick="btnAgregarLinea_Click" 
                    CausesValidation="false" />
            </div>
        </div>
    </div>

    <%-- Grilla de líneas --%>
    <h5>Detalle de la OT</h5>
    <asp:GridView ID="gvLineas" runat="server" AutoGenerateColumns="false"
        CssClass="table table-striped table-bordered"
        EmptyDataText="Sin líneas cargadas aún.">
        <Columns>
            <asp:BoundField DataField="TipoLinea"      HeaderText="Tipo" />
            <asp:BoundField DataField="Descripcion"    HeaderText="Descripción" />
            <asp:BoundField DataField="Cantidad"       HeaderText="Cantidad" />
            <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio Unit." DataFormatString="{0:C}" />
            <asp:BoundField DataField="Subtotal"       HeaderText="Subtotal" DataFormatString="{0:C}" />
            <asp:TemplateField HeaderText="Acciones">
            <ItemTemplate>
                <asp:LinkButton runat="server" CssClass="btn btn-sm btn-danger"
                    CommandArgument='<%# Eval("IdLinea") %>'
                    OnClick="btnEliminarLinea_Click" CausesValidation="false"
                    Visible='<%# panelLinea.Visible %>'
                    OnClientClick="return confirm('¿Eliminar esta linea?');">
                    <i class="bi bi-trash"></i>
                </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <div class="text-end mt-2">
        <h5>Total: <asp:Label ID="lblTotal" runat="server" CssClass="text-primary" /></h5>
    </div>
</asp:Content>
