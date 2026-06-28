<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Form.aspx.cs" Inherits="tc_taller.Clientes.Form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mb-3">
        <div class="col">
            <h3><asp:Label ID="lblTitulo" runat="server" Text="Nuevo Cliente" /></h3>
        </div>
    </div>

    <div class="card p-4" style="max-width:600px;">
        <div class="mb-3">
            <label class="form-label">Nombre *</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombre"
                ErrorMessage="El nombre es requerido." CssClass="text-danger" Display="Dynamic" />
        </div>
        <div class="mb-3">
            <label class="form-label">Apellido *</label>
            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtApellido"
                ErrorMessage="El apellido es requerido." CssClass="text-danger" Display="Dynamic" />
        </div>
        <div class="mb-3">
            <label class="form-label">DNI *</label>
            <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDNI"
                ErrorMessage="El DNI es requerido." CssClass="text-danger" Display="Dynamic" />
        </div>
        <div class="mb-3">
            <label class="form-label">Teléfono</label>
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" />
            <asp:RegularExpressionValidator runat="server" ControlToValidate="txtTelefono"
                ValidationExpression="^[\d\s\-\+\(\)]{8,15}$"
                ErrorMessage="Formato de teléfono inválido. Ej: 1154321234" 
                CssClass="text-danger" Display="Dynamic" />
        </div>
        <div class="mb-3">
            <label class="form-label">Email</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail"
                 ErrorMessage="El email es requerido." CssClass="text-danger" Display="Dynamic" />
            <asp:RegularExpressionValidator runat="server" ControlToValidate="txtEmail"
                ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"
                ErrorMessage="Formato de email inválido." 
                CssClass="text-danger" Display="Dynamic" />
        </div>
        <div class="mb-3">
            <label class="form-label">Dirección</label>
            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" />
        </div>
        <div class="d-flex gap-2">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" 
                CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
            <a href="Listado.aspx" class="btn btn-secondary">Cancelar</a>
        </div>
    </div>
</asp:Content>