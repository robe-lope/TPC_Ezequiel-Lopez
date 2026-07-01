<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="tc_taller.Login"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <title>Login — Taller Mecánico</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css" 
          rel="stylesheet">
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <div class="container">
            <div class="row justify-content-center mt-5">
                <div class="col-md-4">
                    <div class="card shadow p-4">
                        <h3 class="text-center mb-4">🔧 Taller Mecánico</h3>
                        <h5 class="text-center text-muted mb-4">Iniciar Sesión</h5>

                        <asp:Label ID="lblError" runat="server" 
                            CssClass="alert alert-danger d-block mb-3" 
                            Visible="false" />

                        <div class="mb-3">
                            <label class="form-label">Usuario</label>
                            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUsername"
                                ErrorMessage="El usuario es requerido." CssClass="text-danger" Display="Dynamic" />
                        </div>
                        <div class="mb-3">
                            <label class="form-label">Contraseña</label>
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" 
                                TextMode="Password" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword"
                                ErrorMessage="La contraseña es requerida." CssClass="text-danger" Display="Dynamic" />
                        </div>
                        <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" 
                            CssClass="btn btn-primary w-100" OnClick="btnIngresar_Click" />
                        <div class="text-center mt-3">
                            <a href="OlvideMiPass.aspx" class="text-muted" style="font-size:0.9rem;">¿Olvidaste tu contraseña?</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
