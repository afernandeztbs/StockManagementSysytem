<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PedidoWeb.aspx.cs" Inherits="StockManagementSystem.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style11 {
            font-weight: bold;
        }
    .auto-style12 {
        width: 337px;
        height: 9px;
        font-weight: bold;
    }
    .auto-style13 {
        height: 53px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <form id="form3">

    <!DOCTYPE html >

    <html>
    <head>
        <meta name="viewport" content="width=device-width" />
        <title>Productos</title>


  

        <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" rel="stylesheet">
    </head>
    <body>
        <div class="container">
            <div class="panel-body" __designer:mapid="0">
                <form id="form2" runat="server" class="form-horizontal">
                   
                    <br __designer:mapid="2" />
       
                    <table class="auto-style2" __designer:mapid="3">
                        <tr __designer:mapid="4">
                            <td class="auto-style1" __designer:mapid="5">
                                <%=mensaje %>
                                <strong>Titulo</strong><asp:TextBox ID="Titulo" runat="server" class="form-control input-sm" Width="763px"></asp:TextBox>
                            </td>
                            <td __designer:mapid="7" class="auto-style7">&nbsp;</td>
                            <td __designer:mapid="7">&nbsp;</td>
                            <td __designer:mapid="9">&nbsp;</td>
                        </tr>
                        <tr __designer:mapid="4">
                            <td class="auto-style1" __designer:mapid="5">
                                &nbsp;</td>
                            <td __designer:mapid="7" class="auto-style7">&nbsp;</td>
                            <td __designer:mapid="7">&nbsp;</td>
                            <td __designer:mapid="9">&nbsp;</td>
                        </tr>
                        <tr __designer:mapid="4">
                            <td class="auto-style1" __designer:mapid="5">
                                <asp:TextBox ID="Buscador" runat="server" class="form-control input-sm" Width="763px"  AutoPostBack="True"  ></asp:TextBox>
                           
                                </td>
                            <td __designer:mapid="7" class="auto-style7">&nbsp;</td>
                            <td __designer:mapid="7">
                                <asp:Button ID="BtnBuscar" runat="server" OnClick="BtnBuscar_Click" Text="Search" class="btn btn-primary btn-sm" Width="225px" />

                            </td>
                            <td __designer:mapid="9">&nbsp;</td>
                        </tr>
                        <tr __designer:mapid="a">
                            <td class="auto-style1" __designer:mapid="b">
                                &nbsp;</td>
                            <td __designer:mapid="c" class="auto-style7">&nbsp;</td>
                            <td __designer:mapid="c">
                                &nbsp;</td>
                            <td __designer:mapid="d">&nbsp;</td>
                        </tr>
                        <tr __designer:mapid="e">
                            <td class="auto-style1" __designer:mapid="f">

                                <asp:ListBox ID="Articulos" runat="server" Height="108px" Width="778px"></asp:ListBox>

                            </td>
                            <td __designer:mapid="11" class="auto-style7">&nbsp;</td>
                            <td __designer:mapid="11">
                                <asp:Button ID="BtnSelect" runat="server" OnClick="BtnSelect_Click" Text="Select" class="btn btn-primary btn-sm" Width="225px" />
                            </td>
                            <td __designer:mapid="13">&nbsp;</td>
                        </tr>
                    </table>

                    <br __designer:mapid="14" />
                    <table class="auto-style3" __designer:mapid="15">
                        <tr __designer:mapid="16">
                            <td class="auto-style4" __designer:mapid="17">

                                <label class="control-label" __designer:mapid="18">Code</label><asp:TextBox ID="CodArticulo" runat="server" class="form-control input-sm" Width="335px"></asp:TextBox>
                            </td>
                            <td __designer:mapid="1a">

                                <label class="control-label" __designer:mapid="1b">Name</label><asp:TextBox ID="NomArticulo" runat="server" class="form-control input-sm" Width="335px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr __designer:mapid="1d">
                            <td class="auto-style6" colspan="2" __designer:mapid="1e">

                                <span class="auto-style11">Comentario</span><br __designer:mapid="20" />
                                <asp:TextBox ID="Comentario" runat="server" class="form-control input-sm" Height="43px" Width="704px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr __designer:mapid="22">
                            <td class="auto-style4" __designer:mapid="23">Stock<br __designer:mapid="24" />
                                &nbsp;<asp:TextBox ID="cantStock" runat="server" Enabled="False" Width="49px"></asp:TextBox>
                            </td>
                            <td __designer:mapid="26">Quantity<br __designer:mapid="27" />
                                <asp:TextBox ID="cantPedida" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr __designer:mapid="29">
                            <td class="auto-style12" colspan="2" __designer:mapid="2a"></td>
                        </tr>
                        <tr __designer:mapid="29">
                            <td class="auto-style11" colspan="2" __designer:mapid="2a">&nbsp;<asp:Button ID="insert" runat="server" Text="Insert" class="btn btn-primary btn-sm" Width="311px" OnClick="insert_Click" />
                            </td>
                        </tr>
                        <tr __designer:mapid="2c">
                            <td class="auto-style13" colspan="2" __designer:mapid="2d">

                                            <%=html %>
                            </td>
                        </tr>
                        <tr __designer:mapid="2e">
                            <td class="auto-style11" colspan="2" __designer:mapid="2f">
                                <asp:Button ID="save" runat="server" Text="Save" class="btn btn-primary btn-sm" Width="311px" OnClick="save_Click" />
                            </td>
                        </tr>
                    </table>


                </form>
            </div>
            <br />
            <br />
        </div>
        <%--  <script src="Scripts/jquery-1.10.2.min.js"></script>
        <script src="Scripts/bootstrap.min.js"></script>--%>
    </body>
    </html>
</form>
</asp:Content>
