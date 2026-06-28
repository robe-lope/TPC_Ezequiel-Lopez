<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Nueva.aspx.cs" Inherits="tc_taller.OrdenesTrabajo.Nueva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mb-3">
        <div class="col"><h3>Nueva Orden de Trabajo</h3></div>
    </div>

    <div class="card p-4 mb-4">
        <div class="row">
            <div class="col-md-6 mb-3">
                <label class="form-label">Cliente *</label>
                <asp:DropDownList ID="ddlCliente" runat="server" CssClass="form-select" 
                    AutoPostBack="true" OnSelectedIndexChanged="ddlCliente_SelectedIndexChanged" />
            </div>
            <div class="col-md-6 mb-3">
                <label class="form-label">Vehículo *</label>
                <asp:DropDownList ID="ddlVehiculo" runat="server" CssClass="form-select" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlVehiculo"
                    InitialValue="0" ErrorMessage="Seleccione un vehículo." CssClass="text-danger" Display="Dynamic" />
            </div>
            <div class="col-md-6 mb-3">
                <label class="form-label">Mecánico *</label>
                <asp:DropDownList ID="ddlMecanico" runat="server" CssClass="form-select" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlMecanico"
                    InitialValue="0" ErrorMessage="Seleccione un mecánico." CssClass="text-danger" Display="Dynamic" />
            </div>
            <div class="col-md-6 mb-3">
                <label class="form-label">Kilometraje de ingreso *</label>
                <asp:TextBox ID="txtKilometraje" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtKilometraje"
                    ErrorMessage="El kilometraje es requerido." CssClass="text-danger" Display="Dynamic" />
                <asp:CompareValidator runat="server" ControlToValidate="txtKilometraje"
                    Operator="DataTypeCheck" Type="Integer"
                    ErrorMessage="Debe ser un número." CssClass="text-danger" Display="Dynamic" />
            </div>
            <div class="col-md-6 mb-3">
                <label class="form-label">Fecha estimada de entrega</label>
                <asp:TextBox ID="txtFechaEstimada" runat="server" CssClass="form-control" TextMode="Date" />
            </div>
            <div class="col-md-12 mb-3">
                <label class="form-label">Descripción del problema *</label>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" 
                    TextMode="MultiLine" Rows="3" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDescripcion"
                    ErrorMessage="La descripción es requerida." CssClass="text-danger" Display="Dynamic" />
            </div>
        </div>
        <div class="d-flex gap-2">
            <asp:Button ID="btnGuardar" runat="server" Text="Crear OT" 
                CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
            <a href="Listado.aspx" class="btn btn-secondary">Cancelar</a>
        </div>
    </div>
</asp:Content>
