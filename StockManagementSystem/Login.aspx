<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="StockManagementSystem.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">


<head runat="server">
    <meta name="viewport" content="width=device-width" />

    <title>Login</title>
    <link href="Boostrap/CSS/bootstrap.min.css" rel="stylesheet" />

    <link href="Style/Login2.css" rel="stylesheet" />

    <link href="Boostrap/CSS/bootstrap.min.css" rel="stylesheet" />

    <style type="text/css">
        .auto-style3 {
            width: 316px;
            height: 46px;
        }

        .auto-style4 {
            width: 456px;
            height: 320px;
            margin-bottom: 1rem;
        }

        .auto-style5 {
            width: 379px;
            height: 215px;
        }

        .auto-style6 {
            width: 422px;
            height: 72px;
        }
        .auto-style7 {
            margin-left: 160px;
        }
        #footer {
        position: absolute;
        bottom: 10px;
        width: 100%;
        height: 60px; /* Height of the footer */
        /*background: #6cf;*/
    }
    </style>

</head>

<body>


    <div id="container">
        <center>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/App_LocalResources/logo.jpg" />
            <img src="App_LocalResources/logo.jpg" class="auto-style3" />
        <br />
        <br />
        <form id="Login" method="post" runat="server" class="auto-style4">
             <br />
             <img alt="logoTBS" class="auto-style6" longdesc="The British Schools" src="App_LocalResources/logo-pie.jpg" /><br />
             <br />
            <div class="auto-style5">
          <div class="form-group row">
              <label for="txtUsername" class="col-2 col-form-label">Usuario</label>
              <div class="col-10">
            <asp:TextBox ID="txtUsername" runat="server" Width="80%" class="form-control input-sm"></asp:TextBox>
            </div>
              </div>
            <div class="form-group row">
              <label for="txtUsername" class="col-2 col-form-label">Contraseña</label>
              <div class="col-10">
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="80%" class="form-control input-sm"></asp:TextBox>
           </div>
           </div>
            <asp:Label ID="errorLabel" runat="server" ForeColor="#ff3300"></asp:Label>
            <br />
                <br />
            <asp:Button ID="btnLogin" runat="server" Text="Acceder" OnClick="Login_Click" class="btn btn-primary btn-sm"></asp:Button>
            <br />
            <br />
            <br />
            </div>
        </form>
        </center>


        <div id="footer">
        <div>
            <p class="auto-style12">
                <a href="mailto:helpdesk@british.edu.uy">Report a problem</a>
            </p>
        </div>
        <div style="text-align: center">
            Copyright &copy; 2017 <a href="http://portal.british.edu.uy/web">The British Schools</a>
        </div>
    </div>

    <script src="Boostrap/JS/bootstrap.js"></script>
    <script src="Boostrap/JS/bootstrap.min.js"></script>

</body>
</html>
