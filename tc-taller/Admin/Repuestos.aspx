<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Repuestos.aspx.cs" Inherits="tc_taller.Admin.Repuestos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mb-3">
        <div class="col"><h3>Repuestos</h3></div>
    </div>

    <div class="card p-4 mb-4">
        <h5><asp:Label ID="lblTitulo" runat="server" Text="Nuevo Repuesto" /></h5>
        <asp:HiddenField ID="hfId" runat="server" Value="0" />
        <div class="row">
            <div class="col-md-6 mb-3">
                <label class="form-label">Código *</label>
                <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCodigo"
                    ErrorMessage="El código es requerido." CssClass="text-danger" Display="Dynamic" />
            </div>
            <div class="col-md-6 mb-3">
                <label class="form-label">Descripción *</label>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDescripcion"
                    ErrorMessage="La descripción es requerida." CssClass="text-danger" Display="Dynamic" />
            </div>
            <div class="col-md-6 mb-3">
                <label class="form-label">Marca *</label>
                <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-select" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlMarca"
                    InitialValue="0" ErrorMessage="Seleccione una marca." CssClass="text-danger" Display="Dynamic" />
            </div>
            <div class="col-md-6 mb-3">
                <label class="form-label">Categoría *</label>
                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlCategoria"
                    InitialValue="0" ErrorMessage="Seleccione una categoría." CssClass="text-danger" Display="Dynamic" />
            </div>
            <div class="col-md-3 mb-3">
                <label class="form-label">Precio Compra *</label>
                <asp:TextBox ID="txtPrecioCompra" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPrecioCompra"
                    ErrorMessage="Requerido." CssClass="text-danger" Display="Dynamic" />
                <asp:CompareValidator runat="server" ControlToValidate="txtPrecioCompra"
                    Operator="DataTypeCheck" Type="Double"
                    ErrorMessage="Debe ser un número." CssClass="text-danger" Display="Dynamic" />
            </div>
            <div class="col-md-3 mb-3">
                <label class="form-label">Precio Venta *</label>
                <asp:TextBox ID="txtPrecioVenta" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPrecioVenta"
                    ErrorMessage="Requerido." CssClass="text-danger" Display="Dynamic" />
                <asp:CompareValidator runat="server" ControlToValidate="txtPrecioVenta"
                    Operator="DataTypeCheck" Type="Double"
                    ErrorMessage="Debe ser un número." CssClass="text-danger" Display="Dynamic" />
            </div>
            <div class="col-md-3 mb-3">
                <label class="form-label">Stock Actual *</label>
                <asp:TextBox ID="txtStockActual" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtStockActual"
                    ErrorMessage="Requerido." CssClass="text-danger" Display="Dynamic" />
                     <asp:CompareValidator runat="server" ControlToValidate="txtStockActual"
                     Operator="DataTypeCheck" Type="Integer"
                     ErrorMessage="Debe ser un número." CssClass="text-danger" Display="Dynamic" />

            </div>
            <div class="col-md-3 mb-3">
                <label class="form-label">Stock Mínimo *</label>
                <asp:TextBox ID="txtStockMinimo" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtStockMinimo"
                    ErrorMessage="Requerido." CssClass="text-danger" Display="Dynamic" />
                <asp:CompareValidator runat="server" ControlToValidate="txtStockMinimo"
                    Operator="DataTypeCheck" Type="Integer"
                    ErrorMessage="Debe ser un número." CssClass="text-danger" Display="Dynamic" />
            </div>
        </div>
        <div class="d-flex gap-2">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" 
                CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
                CssClass="btn btn-secondary" OnClick="btnCancelar_Click" CausesValidation="false" />
        </div>
    </div>

    <asp:GridView ID="gvRepuestos" runat="server" AutoGenerateColumns="false"
        CssClass="table table-striped table-bordered"
        EmptyDataText="No hay repuestos registrados."
        DataKeyNames="IdRepuesto">
        <Columns>
            <asp:BoundField DataField="Codigo"      HeaderText="Código" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
            <asp:TemplateField HeaderText="Marca">
                <ItemTemplate><%# Eval("Marca.Nombre") %></ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Categoría">
                <ItemTemplate><%# Eval("Categoria.Descripcion") %></ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="PrecioCompra" HeaderText="P. Compra" DataFormatString="{0:C}" />
            <asp:BoundField DataField="PrecioVenta"  HeaderText="P. Venta"  DataFormatString="{0:C}" />
            <asp:TemplateField HeaderText="Stock">
                <ItemTemplate>
                    <asp:Label runat="server" 
                        Text='<%# Eval("StockActual") %>'
                        ForeColor='<%# (int)Eval("StockActual") <= (int)Eval("StockMinimo") ? System.Drawing.Color.Red : System.Drawing.Color.Black %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="StockMinimo" HeaderText="Stock Mín." />
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:LinkButton runat="server" CssClass="btn btn-sm btn-warning"
                        CommandArgument='<%# Eval("IdRepuesto") %>'
                        OnClick="btnEditar_Click" CausesValidation="false">
                        <i class="bi bi-pencil"></i>
                    </asp:LinkButton>
                    <asp:LinkButton runat="server" CssClass="btn btn-sm btn-danger"
                        CommandArgument='<%# Eval("IdRepuesto") %>'
                        OnClick="btnEliminar_Click" CausesValidation="false"
                        OnClientClick="return confirm('¿Eliminar este repuesto?');">
                        <i class="bi bi-trash"></i>
                    </asp:LinkButton>
</ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>