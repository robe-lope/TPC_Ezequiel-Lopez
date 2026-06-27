<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tc_taller.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
        .card-foto {
            position: relative;
            height: 200px;
            border-radius: 10px;
            overflow: hidden;
            cursor: pointer;
            transition: transform 0.2s, box-shadow 0.2s;
        }

        .card-foto:hover {
            transform: translateY(-4px);
            box-shadow: 0 8px 24px rgba(0,0,0,0.18);
        }

        .card-foto img {
            width: 100%;
            height: 100%;
            object-fit: cover;
        }

        .card-foto .overlay {
            position: absolute;
            inset: 0;
            background: linear-gradient(to top, rgba(10,20,40,0.85) 40%, rgba(10,20,40,0.2) 100%);
        }

        .card-foto .card-content {
            position: absolute;
            bottom: 0;
            left: 0;
            right: 0;
            padding: 20px;
            color: #ffffff;
        }

        .card-foto .card-content i {
            font-size: 1.8rem;
            margin-bottom: 6px;
            display: block;
            color: #2e86de;
        }

        .card-foto .card-content h5 {
            margin: 0 0 4px 0;
            font-weight: 700;
            font-size: 1.1rem;
        }

        .card-foto .card-content p {
            margin: 0;
            font-size: 0.8rem;
            color: #cdd6e0;
        }

        .bienvenida {
            background: linear-gradient(135deg, #1e2a3a 0%, #2e86de 100%);
            border-radius: 10px;
            padding: 28px 32px;
            color: white;
            margin-bottom: 32px;
        }

        .bienvenida h2 {
            color: white;
            font-weight: 700;
            margin: 0 0 4px 0;
        }

        .bienvenida p {
            margin: 0;
            color: #cdd6e0;
            font-size: 0.95rem;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mt-4">
        <div class="col-12">
            <h2>Bienvenido al Sistema de Gestión</h2>
            <p class="text-muted">Taller Mecánico — Panel Principal</p>
            <hr />
        </div>
    </div>
    <div class="row g-4" id="panelCards" runat="server">
        
        <%-- Ordenes de trabajo --%>

        <div class="col-md-4" id="cardOT" runat="server">
            <a href="/OrdenesTrabajo/Listado.aspx" class="text-decoration-none">
            <div class="card-foto">
                <img src="https://plus.unsplash.com/premium_photo-1658526934242-aa541776ca49?q=80&w=1172&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" alt="Chango trabajando"/>
                    <div class="overlay"></div>
                    <div class="card-content">
                        <i class="bi bi-clipboard check"></i>
                        <h5>Ordenes de Trabajo</h5>
                    </div>
            </div>
            </a>
        </div>
        <%-- Cklientes --%>
        <div class="col-md-4" id="cardClientes" runat="server">
            <a href="/Clientes/Listado.aspx" class="text-decoration-none">
            <div class="card-foto">
                <img src="https://plus.unsplash.com/premium_photo-1661375020363-763af0afa483?q=80&w=1170&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" alt="Cliente contento"/>
                    <div class="overlay"></div>
                    <div class="card-content">
                        <i class="bi bi-people"></i>
                        <h5>Clientes</h5>
                    </div>
            </div>
            </a>
        </div>

        <%-- Vehiculos --%>
        <div class="col-md-4" id="cardVehiculos" runat="server">
            <a href="/Vehiculos/Listado.aspx" class="text-decoration-none">
            <div class="card-foto">
                <img src="https://plus.unsplash.com/premium_photo-1661962547142-76b04601832d?q=80&w=1171&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" alt="Autos estacionados"/>
                    <div class="overlay"></div>
                    <div class="card-content">
                        <i class="bi bi-car-front"></i>
                        <h5>Vehiculos</h5>
                    </div>
            </div>
            </a>
        </div>
         <%-- Re puestos --%>
        <div class="col-md-4" id="cardRepuestos" runat="server">
            <a href="/Admin/Repuestos.aspx" class="text-decoration-none">
                <div class="card-foto">
                    <img src="https://images.unsplash.com/photo-1759419281480-bacc913c9606?q=80&w=1074&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" alt="Repuestos" />
                    <div class="overlay"></div>
                    <div class="card-content">
                        <i class="bi bi-box-seam"></i>
                        <h5>Repuestos</h5>
                        <p>Stock y precios</p>
                    </div>
                </div>
            </a>
        </div>
        <%-- sERVICIOS   --%>
        <div class="col-md-4" id="cardServicios" runat="server">
            <a href="/Admin/Servicios.aspx" class="text-decoration-none">
                <div class="card-foto">
                    <img src="https://images.unsplash.com/photo-1487754180451-c456f719a1fc?q=80&w=1170&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" alt="Servicios" />
                    <div class="overlay"></div>
                    <div class="card-content">
                        <i class="bi bi-wrench-adjustable"></i>
                        <h5>Servicios</h5>
                        <p>Catálogo de servicios</p>
                    </div>
                </div>
            </a>
        </div>
        <%--  Usuarios  --%>
        <div class="col-md-4" id="cardUsuarios" runat="server">
            <a href="/Admin/Usuarios.aspx" class="text-decoration-none">
                <div class="card-foto">
                    <img src="https://plus.unsplash.com/premium_photo-1676998430913-12457cc6c6f0?q=80&w=1170&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" alt="Usuarios" />
                    <div class="overlay"></div>
                    <div class="card-content">
                        <i class="bi bi-person-gear"></i>
                        <h5>Usuarios</h5>
                        <p>Gestión de accesos</p>
                    </div>
                </div>
            </a>
        </div>


    </div>
</asp:Content>
    