<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Listado.aspx.cs" Inherits="tc_taller.Vehiculos.Listado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mb-3">
        <div class="col"><h3>Vehículos</h3></div>
        <div class="col text-end">
            <a href="Form.aspx" class="btn btn-primary">+ Nuevo Vehículo</a>
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
                    <a href='Form.aspx?id=<%# Eval("IdVehiculo") %>' class="btn btn-sm btn-warning">Editar</a>
                    <asp:Button runat="server" Text="Eliminar" CssClass="btn btn-sm btn-danger"
                        CommandArgument='<%# Eval("IdVehiculo") %>'
                        OnClick="btnEliminar_Click" CausesValidation="false"
                        OnClientClick="return confirm('¿Eliminar este vehículo?');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
