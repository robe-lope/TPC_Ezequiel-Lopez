<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="tc_taller.Admin.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mb-3">
        <div class="col"><h3>Usuarios</h3></div>
    </div>

    <div class="card p-4 mb-4" style="max-width:600px;">
        <h5><asp:Label ID="lblTitulo" runat="server" Text="Nuevo Usuario" /></h5>
        <asp:HiddenField ID="hfId" runat="server" Value="0" />
        <div class="row">
            <div class="col-md-6 mb-3">
                <label class="form-label">Nombre *</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombre"
                    ErrorMessage="Requerido." CssClass="text-danger" Display="Dynamic" />
            </div>
            <div class="col-md-6 mb-3">
                <label class="form-label">Apellido *</label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtApellido"
                    ErrorMessage="Requerido." CssClass="text-danger" Display="Dynamic" />
            </div>
            <div class="col-md-6 mb-3">
                <label class="form-label">Email *</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="Requerido." CssClass="text-danger" Display="Dynamic" />
            </div>
            <div class="col-md-6 mb-3">
                <label class="form-label">Username *</label>
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUsername"
                    ErrorMessage="Requerido." CssClass="text-danger" Display="Dynamic" />
            </div>
            <div class="col-md-6 mb-3">
                <label class="form-label">Password *</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword"
                    ErrorMessage="Requerido." CssClass="text-danger" Display="Dynamic" />
            </div>
            <div class="col-md-6 mb-3">
                <label class="form-label">Perfil *</label>
                <asp:DropDownList ID="ddlPerfil" runat="server" CssClass="form-select" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlPerfil"
                    InitialValue="0" ErrorMessage="Seleccione un perfil." CssClass="text-danger" Display="Dynamic" />
            </div>
        </div>
        <div class="d-flex gap-2">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" 
                CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
                CssClass="btn btn-secondary" OnClick="btnCancelar_Click" CausesValidation="false" />
        </div>
    </div>

    <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="false"
        CssClass="table table-striped table-bordered"
        EmptyDataText="No hay usuarios registrados."
        DataKeyNames="IdUsuario">
        <Columns>
            <asp:BoundField DataField="Username"  HeaderText="Usuario" />
            <asp:BoundField DataField="Apellido"  HeaderText="Apellido" />
            <asp:BoundField DataField="Nombre"    HeaderText="Nombre" />
            <asp:BoundField DataField="Email"     HeaderText="Email" />
            <asp:TemplateField HeaderText="Perfil">
                <ItemTemplate><%# Eval("Perfil.Descripcion") %></ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:Button runat="server" Text="Editar" CssClass="btn btn-sm btn-warning"
                        CommandArgument='<%# Eval("IdUsuario") %>'
                        OnClick="btnEditar_Click" CausesValidation="false" />
                    <asp:Button runat="server" Text="Eliminar" CssClass="btn btn-sm btn-danger"
                        CommandArgument='<%# Eval("IdUsuario") %>'
                        OnClick="btnEliminar_Click" CausesValidation="false"
                        OnClientClick="return confirm('¿Eliminar este usuario?');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
