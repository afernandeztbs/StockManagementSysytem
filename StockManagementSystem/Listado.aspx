<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listado.aspx.cs" Inherits="StockManagementSystem.WebForm6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style11 {
            font-weight: bold;
        }

        </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form3" runat="server">

        <!DOCTYPE html>
        <html>

        <head>
            <meta name="viewport" content="width=device-width" />
            <title>Listados</title>
            <link href="Boostrap/CSS/bootstrap.min.css" rel="stylesheet" />
        </head>
        <body>
            <table id="tablaPedidos" class="w-100">
                <tr>
                    <th class="w-25">
                        <asp:DropDownList ID="DropDownList1" runat="server" class="form-control">
                            <asp:ListItem Selected="True" Value="Todo">Todo</asp:ListItem>
                            <asp:ListItem>Pendiente</asp:ListItem>
                            <asp:ListItem>En Proceso</asp:ListItem>
                            <asp:ListItem>Cancelado</asp:ListItem>
                            <asp:ListItem>Completado</asp:ListItem>
                        </asp:DropDownList>
                    </th>


                    <th class="w-25">
                        <asp:DropDownList ID="Sectores" runat="server" class="form-control">
                            <asp:ListItem Selected="True" Value="Todo">Todo</asp:ListItem>
                            <asp:ListItem>Junior</asp:ListItem>
                            <asp:ListItem>Senior</asp:ListItem>
                        </asp:DropDownList>
                    </th>
                    <th class="w-25">
                        <asp:TextBox ID="actor" runat="server" class="form-control input-sm"></asp:TextBox>
                    </th>
                    <th class="w-25">
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Buscar" class="btn btn-primary" Width="200px" />
                    </th>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <%=html %>
                    </td>
                </tr>
                <tr>
                    <td class="text-center">&nbsp;</td>
                </tr>
            </table>

            <script src="Boostrap/JS/bootstrap.js"></script>
            <script src="Boostrap/JS/bootstrap.min.js"></script>

        </body>
        </html>
    </form>

</asp:Content>
