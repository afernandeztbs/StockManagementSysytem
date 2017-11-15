using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockManagementSystem
{

    public partial class Site : System.Web.UI.MasterPage
    {
        public String name;
        public String cod_actor;
        public String menu;
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Collections.Specialized.NameValueCollection
            UserInfoCookieCollection;
            UserInfoCookieCollection = Request.Cookies["userInfo"].Values;
            cod_actor = Server.HtmlEncode(UserInfoCookieCollection["cod_actor"]);
            name = Server.HtmlEncode(UserInfoCookieCollection["name"]);
            cargarMenu();


        }



        public void cargarMenu() {
           SqlConnection con = new SqlConnection("Data Source= srv-sql01; Initial Catalog = MTDesa; Integrated Security = True");

            menu = "<ul>" +
                   "<li><a href = 'PedidoWeb.aspx'> Inicio </a></li>" +
                   "<li><a href = 'PedidosUsuario.aspx'> Mis Pedidos </a></li>";

            String str = "select " +
                        " position " +
                        "from cte_actores where cod_actor = @search";

            con.Open();
            SqlCommand xp = new SqlCommand(str, con);
            xp.Parameters.Add("@search", SqlDbType.NVarChar).Value = cod_actor;
            SqlDataReader reader = xp.ExecuteReader();
            String position ="";
            while (reader.Read())
            {
                position = String.Format("{0}", reader[0]);
            }
            if (position.Equals("Resources Centre Junior - Administration") || position.Equals("Resources Centre Senior - Administration")
                ||cod_actor.Equals("57014") || cod_actor.Equals("57269"))
            {
                menu += "<li><a href = 'SelecPedidos.aspx'> Entrega </a></li>";
                menu += "<li><a href = 'Listado.aspx'> Listados </a></li>";
            }


            menu += "<li class='pull-right'><a href = 'Login.aspx'> Salir </a></li>" +
                     "<li class='pull-right'><a href = ''> Bienvenido " + name +"</a></li>   </ul>";

            reader.Close();
            con.Close();
        }
    }
}