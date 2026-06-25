<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Form.aspx.cs" Inherits="tc_taller.Vehiculos.Form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mb-3">
        <div class="col">
            <h3><asp:Label ID="lblTitulo" runat="server" Text="Nuevo Vehículo" /></h3>
        </div>
    </div>

    <div class="card p-4" style="max-width:600px;">
        <div class="mb-3">
            <label class="form-label">Cliente *</label>
            <asp:DropDownList ID="ddlCliente" runat="server" CssClass="form-select" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlCliente"
                InitialValue="0" ErrorMessage="Seleccione un cliente." CssClass="text-danger" Display="Dynamic" />
        </div>
        <div class="mb-3">
            <label class="form-label">Patente *</label>
            <asp:TextBox ID="txtPatente" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPatente"
                ErrorMessage="La patente es requerida." CssClass="text-danger" Display="Dynamic" />
        </div>
        <div class="row">
            <div class="col-md-6 mb-3">
                <label class="form-label">Marca *</label>
                <asp:TextBox ID="txtMarca" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtMarca"
                    ErrorMessage="La marca es requerida." CssClass="text-danger" Display="Dynamic" />
            </div>
            <div class="col-md-6 mb-3">
                <label class="form-label">Modelo *</label>
                <asp:TextBox ID="txtModelo" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtModelo"
                    ErrorMessage="El modelo es requerido." CssClass="text-danger" Display="Dynamic" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-4 mb-3">
                <label class="form-label">Año *</label>
                <asp:TextBox ID="txtAnio" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAnio"
                    ErrorMessage="El año es requerido." CssClass="text-danger" Display="Dynamic" />
            </div>
            <div class="col-md-4 mb-3">
                <label class="form-label">Color</label>
                <asp:TextBox ID="txtColor" runat="server" CssClass="form-control" />
            </div>
            <div class="col-md-4 mb-3">
                <label class="form-label">Kilometraje *</label>
                <asp:TextBox ID="txtKilometraje" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtKilometraje"
                    ErrorMessage="El kilometraje es requerido." CssClass="text-danger" Display="Dynamic" />
            </div>
        </div>
        <div class="d-flex gap-2">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" 
                CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
            <a href="Listado.aspx" class="btn btn-secondary">Cancelar</a>
        </div>
    </div>
</asp:Content>