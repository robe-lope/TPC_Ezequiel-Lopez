<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tc_taller.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mt-4">
        <div class="col-12">
            <h2>Bienvenido al Sistema de Gestión</h2>
            <p class="text-muted">Taller Mecánico — Panel Principal</p>
            <hr />
        </div>
    </div>
    <div class="row mt-3">
        <div class="col-md-4">
            <div class="card text-white bg-primary mb-3">
                <div class="card-body">
                    <h5 class="card-title">👥 Clientes</h5>
                    <p class="card-text">Gestión de clientes del taller.</p>
                    <a href="/Clientes/Listado.aspx" class="btn btn-light">Ver Clientes</a>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="card text-white bg-warning mb-3">
                <div class="card-body">
                    <h5 class="card-title">🔩 Repuestos</h5>
                    <p class="card-text">Stock y gestión de repuestos.</p>
                    <a href="/Admin/Repuestos.aspx" class="btn btn-light">Ver Repuestos</a>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="card text-white bg-success mb-3">
                <div class="card-body">
                    <h5 class="card-title">🛠️ Servicios</h5>
                    <p class="card-text">Catálogo de servicios disponibles.</p>
                    <a href="/Admin/Servicios.aspx" class="btn btn-light">Ver Servicios</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
    