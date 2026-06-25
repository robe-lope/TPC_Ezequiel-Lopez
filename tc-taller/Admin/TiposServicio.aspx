<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="TiposServicio.aspx.cs" Inherits="tc_taller.Admin.TipoServicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mb-3">
        <div class="col"><h3>Tipos de Servicio</h3></div>
    </div>

    <div class="card p-4 mb-4" style="max-width:500px;">
        <h5><asp:Label ID="lblTitulo" runat="server" Text="Nuevo Tipo de Servicio" /></h5>
        <asp:HiddenField ID="hfId" runat="server" Value="0" />
        <div class="mb-3">
            <label class="form-label">Descripción *</label>
            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDescripcion"
                ErrorMessage="La descripción es requerida." CssClass="text-danger" Display="Dynamic" />
        </div>
        <div class="d-flex gap-2">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" 
                CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
                CssClass="btn btn-secondary" OnClick="btnCancelar_Click" CausesValidation="false" />
        </div>
    </div>

    <asp:GridView ID="gvTipos" runat="server" AutoGenerateColumns="false"
        CssClass="table table-striped table-bordered"
        EmptyDataText="No hay tipos de servicio registrados."
        DataKeyNames="IdTipoServicio">
        <Columns>
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:Button runat="server" Text="Editar" CssClass="btn btn-sm btn-warning"
                        CommandArgument='<%# Eval("IdTipoServicio") %>'
                        OnClick="btnEditar_Click" CausesValidation="false" />
                    <asp:Button runat="server" Text="Eliminar" CssClass="btn btn-sm btn-danger"
                        CommandArgument='<%# Eval("IdTipoServicio") %>'
                        OnClick="btnEliminar_Click" CausesValidation="false"
                        OnClientClick="return confirm('¿Eliminar este tipo de servicio?');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
