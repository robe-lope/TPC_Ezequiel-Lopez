<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Listado.aspx.cs" Inherits="tc_taller.Clientes.Listado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mb-3">
        <div class="col">
            <h3>Clientes</h3>
        </div>
        <div class="col text-end">
            <asp:Button ID="btnNuevo" runat="server" Text="+ Nuevo Cliente" 
                CssClass="btn btn-primary" 
                OnClick="btnNuevo_Click" />
        </div>
    </div>

    <asp:Label ID="lblMensaje" runat="server" CssClass="alert alert-success d-none" />
    <div class="card p-3 mb-4">
    <div class="row g-2 align-items-center">
        <div class="col-md-4">
            <asp:TextBox ID="txtBusqueda" runat="server" CssClass="form-control" 
                placeholder="Buscar por nombre, apellido o DNI..." />
        </div>
        <div class="col-auto">
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" 
                CssClass="btn btn-primary" OnClick="btnBuscar_Click" CausesValidation="false" />
        </div>
        <div class="col-auto">
            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" 
                CssClass="btn btn-secondary" OnClick="btnLimpiar_Click" CausesValidation="false" />
        </div>
    </div>
</div>
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
                    <asp:LinkButton runat="server"
                        
                        CommandArgument='<%# Eval("IdCliente") %>'
                        OnClick="btnEditar_Click" CausesValidation="false"
                        CssClass="btn btn-sm btn-warning"
                        Visible='<%# !Negocio.Seguridad.EsMecanico() %>'>
                        <i class="bi bi-pencil"></i>
                    </asp:LinkButton>
                    <asp:LinkButton runat="server" CssClass="btn btn-sm btn-danger"
                        CommandArgument='<%# Eval("IdCliente") %>'
                        OnClick="btnEliminar_Click" CausesValidation="false"
                        Visible='<%# !Negocio.Seguridad.EsMecanico() %>'
                        OnClientClick="return confirm('¿Eliminar este cliente?');">
                        <i class="bi bi-trash"></i>
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
