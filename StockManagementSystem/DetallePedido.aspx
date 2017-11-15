<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetallePedido.aspx.cs" Inherits="StockManagementSystem.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!DOCTYPE html>
    <style type="text/css">
    ul {
        list-style-type: none;
        margin: 0;
        padding: 0;
        overflow: hidden;
        background-color: #333;
    }

    li {
        float: left;
    }

        li a {
            display: block;
            color: white;
            text-align: center;
            padding: 14px 16px;
            text-decoration: none;
        }

            li a:hover {
                background-color: #111;
            }

    .auto-style1 {
        width: 100%;
        height: 250px;
    }

    .auto-style2 {
        height: 189px;
        text-align: left;
    }
</style>
    <html>
    <head>
        <meta name="viewport" content="width=device-width" />
        <title>Productos</title>


        <link href="Content/bootstrap.min.css" rel="stylesheet" />

        <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" rel="stylesheet">
    </head>
    <body>
        <div class="panel-body" __designer:mapid="0">
            <form id="form2" runat="server" class="form-horizontal">
                <table id="tablaPedidos" class="auto-style1">
                    <tr>
                        <td class="auto-style2">
                            <%=html %>
                        </td>
                    </tr>
                    <tr>
                        <td class="text-center">&nbsp;</td>
                    </tr>
                </table>


            </form>
        </div>
        <br />
        <br />
        </div>
    <script src="Scripts/jquery-1.10.2.min.js"></script>
        <script src="Scripts/bootstrap.min.js"></script>


    </body>
    </html>
</asp:Content>
