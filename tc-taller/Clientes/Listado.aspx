<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Listado.aspx.cs" Inherits="tc_taller.Clientes.Listado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mb-3">
        <div class="col">
            <h3>Clientes</h3>
        </div>
        <div class="col text-end">
            <a href="Form.aspx" class="btn btn-primary">+ Nuevo Cliente</a>
        </div>
    </div>

    <asp:Label ID="lblMensaje" runat="server" CssClass="alert alert-success d-none" />

    <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="false"
        CssClass="table table-striped table-bordered"
        EmptyDataText="No hay clientes registrados."
        DataKeyNames="IdCliente">
        <Columns>
            <asp:BoundField DataField="Apellido"  HeaderText="Apellido" />
            <asp:BoundField DataField="Nombre"    HeaderText="Nombre" />
            <asp:BoundField DataField="DNI"       HeaderText="DNI" />
            <asp:BoundField DataField="Telefono"  HeaderText="Teléfono" />
            <asp:BoundField DataField="Email"     HeaderText="Email" />
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <a href='Form.aspx?id=<%# Eval("IdCliente") %>' class="btn btn-sm btn-warning">Editar</a>
                    <asp:Button runat="server" Text="Eliminar" CssClass="btn btn-sm btn-danger"
                        CommandArgument='<%# Eval("IdCliente") %>'
                        OnClick="btnEliminar_Click"
                        OnClientClick="return confirm('¿Eliminar este cliente?');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
