<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="StockManagementSystem.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">


<head runat="server">
    <meta name="viewport" content="width=device-width" />

    <title>Login</title>
  




</head>

<body>


    <div id="contenedor">

        <br />
        <br />
        <br />
        <br />
        <div id="caja_login">
            <br />
            <center>

					<asp:Image id="Image1" runat="server" Height="60px" ImageUrl="file://srv-web01/PublicDocs/Extras/logo.jpg"  Width="345px" AlternateText="Imagen no disponible" ImageAlign="TextTop" />
                        <form id="Login" method="post" runat="server">
					<h4>
                        &nbsp;
					</h4>
					<asp:TextBox ID="txtUsername" Runat="server" width="80%"></asp:TextBox>
                            <br/>
                            <br/>
					<asp:TextBox ID="txtPassword" Runat="server" TextMode=Password width="80%"></asp:TextBox>
                            <br/>
                            <br/>
                            <br/>
					<asp:Button ID="btnLogin" Runat="server" Text="Acceder" OnClick="Login_Click" class="btn btn-primary btn-sm" cssClass="button"></asp:Button>
                            <br/>
					<asp:Label ID="errorLabel" Runat="server" ForeColor="#ff3300"></asp:Label>
                            <br/>
						

					</form>
					</center>
        </div>

    </div>
    <%--    <div id="Cabezal">
        <img src="App_LocalResources/logo.jpg" />
    </div>

    <div class="container">
        <div class="row">
            <div class="col-md-6 col-md-offset-3">
                <div class="panel panel-login">
                    <div class="panel-body">
                        <div class="row">
                            <div class="auto-style1" >
                                <form id="Login" method="post" role="form" runat="server">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtUsername" runat="server" Text="Nombre de usuario" class="form-control" style="position:fixed; left:50%; right:50%" Width="80%"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="form-control" style="text-align: 'center'" Width="80%"></asp:TextBox>
                                    </div>
<%--                                    <div class="form-group text-center">
                                        <input type="checkbox" tabindex="3" class="" name="remember" id="remember">
                                        <label for="remember">Remember Me</label>
                                    </div>--%>
    <%--    <div class="form-group">
                                        <div class="row">
                                            <div class="col-sm-6 col-sm-offset-3">
                                                <asp:Button ID="btnLogin" runat="server" Text="Acceder" OnClick="Login_Click" class="btn btn-primary" style="text-align: center"></asp:Button>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <div class="text-center">
                                                    <a href="https://password.british.edu.uy" tabindex="5" class="forgot-password">Forgot Password?</a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>

    <%--  <div id="contenedor" class="container"  style="text-align: center;">

        <br>
        <br>
        <img src="App_LocalResources/logo.jpg" alt="logo" class="auto-style2" /><br>
        <br>
        <div id="caja_login" style="text-align: center;">
            <br>

            <div class="row" style="text-align: center;">
                <div class="col-md-6 col-md-offset-3" style="text-align: center;">
                    <form id="Login" method="post" runat="server" style="text-align: center;">

                        <div class="form-group">
                            <label for="exampleInputEmail1">Nombre de usuario</label>
                            <asp:TextBox ID="txtUsername" runat="server" Text="Nombre de usuario" class="form-control" ></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword1">Contraseña</label>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="form-control"></asp:TextBox>
                        </div>
                        <asp:Label ID="errorLabel" runat="server" ForeColor="#ff3300"></asp:Label>
                        <br>
                        <asp:Button ID="btnLogin" runat="server" Text="Acceder" OnClick="Login_Click" class="btn btn-primary btn-sm"></asp:Button>
                        <br>
                        <br>
                    </form>
                </div>
            </div>
        </div>
    </div>--%>

    <script src="Boostrap/JS/bootstrap.js"></script>
    <script src="Boostrap/JS/bootstrap.min.js"></script>


</body>
</html>
    </asp:Content>