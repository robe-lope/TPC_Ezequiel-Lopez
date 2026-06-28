<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Listado.aspx.cs" Inherits="tc_taller.Vehiculos.Listado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mb-3">
        <div class="col"><h3>Vehículos</h3></div>
        <div class="col text-end">
            <asp:Button ID="btnNuevo" runat="server" Text="+ Nuevo Vehículo" 
                CssClass="btn btn-primary" OnClick="btnNuevo_Click" />
        </div>
    </div>

    <asp:GridView ID="gvVehiculos" runat="server" AutoGenerateColumns="false"
        CssClass="table table-striped table-bordered"
        EmptyDataText="No hay vehículos registrados."
        DataKeyNames="IdVehiculo">
        <Columns>
            <asp:BoundField DataField="Patente"  HeaderText="Patente" />
            <asp:BoundField DataField="Marca"    HeaderText="Marca" />
            <asp:BoundField DataField="Modelo"   HeaderText="Modelo" />
            <asp:BoundField DataField="Anio"     HeaderText="Año" />
            <asp:BoundField DataField="Color"    HeaderText="Color" />
            <asp:BoundField DataField="Kilometraje" HeaderText="Km" />
            <asp:TemplateField HeaderText="Cliente">
                <ItemTemplate><%# Eval("Cliente.NombreCompleto") %></ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:LinkButton runat="server" CssClass="btn btn-sm btn-warning"
                        CommandArgument='<%# Eval("IdVehiculo") %>'
                        OnClick="btnEditar_Click" CausesValidation="false"
                        Visible='<%# !Negocio.Seguridad.EsMecanico() %>'>
                        <i class="bi bi-pencil"></i
                    </asp:LinkButton>
                    <asp:LinkButton runat="server" CssClass="btn btn-sm btn-danger"
                        CommandArgument='<%# Eval("IdVehiculo") %>'
                        OnClick="btnEliminar_Click" CausesValidation="false"
                        Visible='<%# !Negocio.Seguridad.EsMecanico() %>'
                        OnClientClick="return confirm('¿Eliminar este vehículo?');">
                        <i class="bi bi-trash"></i>
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
