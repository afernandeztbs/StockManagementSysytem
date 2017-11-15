<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listado.aspx.cs" Inherits="StockManagementSystem.WebForm6" %>



    <form id="form3" runat="server"  >

        <link href="Style/Listado.css" rel="stylesheet" />
  
            <link href="Boostrap/CSS/bootstrap.min.css" rel="stylesheet" />
        
        <!DOCTYPE html>
        <link href="Style/Listado.css" rel="stylesheet" />

        <html>
            
        <head>
            <meta name="viewport" content="width=device-width" />
            <title>Listados</title>
            
            

        </head>
        <body>
            <div class="panel-body" __designer:mapid="0">
            </div>
            <table id="tablaPedidos" class="auto-style1">
                <tr>
                    <td class="auto-style13">
                        <asp:DropDownList ID="DropDownList1" runat="server" Width="124px">
                            <asp:ListItem Selected="True" Value="Todo">Todo</asp:ListItem>
                            <asp:ListItem>Pendiente</asp:ListItem>
                            <asp:ListItem>En Proceso</asp:ListItem>
                            <asp:ListItem>Cancelado</asp:ListItem>
                            <asp:ListItem>Completado</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;&nbsp;
                            <asp:DropDownList ID="Sectores" runat="server" Width="122px">
                                <asp:ListItem Selected="True" Value="Todo">Todo</asp:ListItem>
                                <asp:ListItem>Junior</asp:ListItem>
                                <asp:ListItem>Senior</asp:ListItem>
                            </asp:DropDownList>
                        <asp:TextBox ID="actor" runat="server"></asp:TextBox>
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Buscar" />
                    </td>
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


            <br />
            <br />
            <script src="Boostrap/JS/bootstrap.js"></script>
            <script src="Boostrap/JS/bootstrap.min.js"></script>


        </body>
        </html>

    </form>

