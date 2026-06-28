<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Listado.aspx.cs" Inherits="tc_taller.OrdenesTrabajo.Listado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mb-3">
        <div class="col"><h3>Órdenes de Trabajo</h3></div>
        <div class="col text-end">
            <a href="Nueva.aspx" class="btn btn-primary">+ Nueva OT</a>
        </div>
    </div>
    <div class="card p-3 mb-4">
    <div class="row g-2 align-items-center">
        <div class="col-md-3">
            <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-select">
                <asp:ListItem Value="0">-- Todos los estados --</asp:ListItem>
                <asp:ListItem Value="1">Abierta</asp:ListItem>
                <asp:ListItem Value="2">En Proceso</asp:ListItem>
                <asp:ListItem Value="3">Resuelta</asp:ListItem>
                <asp:ListItem Value="4">Cerrada</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-auto">
            <asp:Button ID="btnBuscar" runat="server" Text="Filtrar" 
                CssClass="btn btn-primary" OnClick="btnBuscar_Click" CausesValidation="false" />
        </div>
        <div class="col-auto">
            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" 
                CssClass="btn btn-secondary" OnClick="btnLimpiar_Click" CausesValidation="false" />
        </div>
    </div>
</div>
    <asp:GridView ID="gvOTs" runat="server" AutoGenerateColumns="false"
        CssClass="table table-striped table-bordered"
        EmptyDataText="No hay órdenes de trabajo."
        DataKeyNames="IdOrden">
        <Columns>
            <asp:BoundField DataField="IdOrden" HeaderText="N° OT" />
            <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:TemplateField HeaderText="Vehículo">
                <ItemTemplate><%# Eval("Vehiculo.Patente") %> — <%# Eval("Vehiculo.Marca") %> <%# Eval("Vehiculo.Modelo") %></ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cliente">
                <ItemTemplate><%# Eval("Vehiculo.Cliente.NombreCompleto") %></ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Mecánico">
                <ItemTemplate><%# Eval("Mecanico.NombreCompleto") %></ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Estado">
                <ItemTemplate>
                    <span class='<%# GetBadgeClass(Eval("Estado.Descripcion").ToString()) %>'>
                        <%# Eval("Estado.Descripcion") %>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <a href='Detalle.aspx?id=<%# Eval("IdOrden") %>' class="btn btn-sm btn-info">Ver</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
