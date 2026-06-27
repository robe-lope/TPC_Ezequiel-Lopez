<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CategoriasRepuesto.aspx.cs" Inherits="tc_taller.Admin.CategoriaRepuesto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mb-3">
        <div class="col"><h3>Categorías de Repuesto</h3></div>
    </div>

    <div class="card p-4 mb-4" style="max-width:500px;">
        <h5><asp:Label ID="lblTitulo" runat="server" Text="Nueva Categoría" /></h5>
        <asp:HiddenField ID="hfId" runat="server" Value="0" />
        <div class="mb-3">
            <label class="form-label">Descripción *</label>
            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDescripcion"
                ErrorMessage="La descripción es requerida." CssClass="text-danger" Display="Dynamic" />
        </div>
        <div class="d-flex gap-2">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" 
                CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
                CssClass="btn btn-secondary" OnClick="btnCancelar_Click" CausesValidation="false" />
        </div>
    </div>

    <asp:GridView ID="gvCategorias" runat="server" AutoGenerateColumns="false"
        CssClass="table table-striped table-bordered"
        EmptyDataText="No hay categorías registradas."
        DataKeyNames="IdCategoria">
        <Columns>
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:LinkButton runat="server" CssClass="btn btn-sm btn-warning"
                        CommandArgument='<%# Eval("IdCategoria") %>'
                        OnClick="btnEditar_Click" CausesValidation="false">
                        <i class="bi bi-pencil"></i>
                    </asp:LinkButton>
                    <asp:LinkButton runat="server" CssClass="btn btn-sm btn-danger"
                        CommandArgument='<%# Eval("IdCategoria") %>'
                        OnClick="btnEliminar_Click" CausesValidation="false"
                        OnClientClick="return confirm('¿Eliminar esta categoría?');">
                        <i class="bi bi-trash"></i>
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
