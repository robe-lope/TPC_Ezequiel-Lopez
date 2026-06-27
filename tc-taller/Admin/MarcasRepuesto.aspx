<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MarcasRepuesto.aspx.cs" Inherits="tc_taller.Admin.MarcasRepuesto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mb-3">
        <div class="col"><h3>Marcas de Repuesto</h3></div>
    </div>

    <div class="card p-4 mb-4" style="max-width:500px;">
        <h5><asp:Label ID="lblTitulo" runat="server" Text="Nueva Marca" /></h5>
        <asp:HiddenField ID="hfId" runat="server" Value="0" />
        <div class="mb-3">
            <label class="form-label">Nombre *</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombre"
                ErrorMessage="El nombre es requerido." CssClass="text-danger" Display="Dynamic" />
        </div>
        <div class="d-flex gap-2">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" 
                CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
                CssClass="btn btn-secondary" OnClick="btnCancelar_Click" CausesValidation="false" />
        </div>
    </div>

    <asp:GridView ID="gvMarcas" runat="server" AutoGenerateColumns="false"
        CssClass="table table-striped table-bordered"
        EmptyDataText="No hay marcas registradas."
        DataKeyNames="IdMarca">
        <Columns>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:LinkButton runat="server" CssClass="btn btn-sm btn-warning"
                        CommandArgument='<%# Eval("IdMarca") %>'
                        OnClick="btnEditar_Click" CausesValidation="false">
                        <i class="bi bi-pencil"></i>
                        </asp:LinkButton>
                    <asp:LinkButton runat="server" CssClass="btn btn-sm btn-danger"
                        CommandArgument='<%# Eval("IdMarca") %>'
                        OnClick="btnEliminar_Click" CausesValidation="false"
                        OnClientClick="return confirm('¿Eliminar esta marca?');">
                        <i class="bi bi-trash"></i>
                        </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
