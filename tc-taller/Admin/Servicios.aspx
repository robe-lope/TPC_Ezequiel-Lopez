<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Servicios.aspx.cs" Inherits="tc_taller.Admin.Servicios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mb-3">
        <div class="col"><h3>Servicios</h3></div>
    </div>

    <div class="card p-4 mb-4" style="max-width:600px;">
        <h5><asp:Label ID="lblTitulo" runat="server" Text="Nuevo Servicio" /></h5>
        <asp:HiddenField ID="hfId" runat="server" Value="0" />
        <div class="mb-3">
            <label class="form-label">Descripción *</label>
            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDescripcion"
                ErrorMessage="La descripción es requerida." CssClass="text-danger" Display="Dynamic" />
        </div>
        <div class="mb-3">
            <label class="form-label">Precio Base *</label>
            <asp:TextBox ID="txtPrecioBase" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPrecioBase"
                ErrorMessage="El precio es requerido." CssClass="text-danger" Display="Dynamic" />
        </div>
        <div class="mb-3">
            <label class="form-label">Tipo de Servicio *</label>
            <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-select" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlTipo"
                InitialValue="0" ErrorMessage="Seleccione un tipo." CssClass="text-danger" Display="Dynamic" />
        </div>
        <div class="d-flex gap-2">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" 
                CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
                CssClass="btn btn-secondary" OnClick="btnCancelar_Click" CausesValidation="false" />
        </div>
    </div>

    <asp:GridView ID="gvServicios" runat="server" AutoGenerateColumns="false"
        CssClass="table table-striped table-bordered"
        EmptyDataText="No hay servicios registrados."
        DataKeyNames="IdServicio">
        <Columns>
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
            <asp:TemplateField HeaderText="Tipo">
                <ItemTemplate><%# Eval("TipoServicio.Descripcion") %></ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="PrecioBase" HeaderText="Precio Base" DataFormatString="{0:C}" />
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:LinkButton runat="server" CssClass="btn btn-sm btn-warning"
                        CommandArgument='<%# Eval("IdServicio") %>'
                        OnClick="btnEditar_Click" CausesValidation="false">
                        <i class="bi bi-pencil"></i>
                    </asp:LinkButton>
                    <asp:LinkButton runat="server" CssClass="btn btn-sm btn-danger"
                        CommandArgument='<%# Eval("IdServicio") %>'
                        OnClick="btnEliminar_Click" CausesValidation="false"
                        OnClientClick="return confirm('¿Eliminar este servicio?');">
                        <i class="bi bi-trash"></i>
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
