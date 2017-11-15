using StockManagementSystem.Clases;
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
    public partial class WebForm2 : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection("Data Source= srv-sql01; Initial Catalog = MTDesa; Integrated Security = True");
        public string cod_actor;
        Auxiliares aux = new Auxiliares();
        public string html = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Collections.Specialized.NameValueCollection
           UserInfoCookieCollection;
            UserInfoCookieCollection = Request.Cookies["userInfo"].Values;
            cod_actor = Server.HtmlEncode(UserInfoCookieCollection["cod_actor"]);
         
            html = aux.ConvertDataTableToHTML(ListaPedidos());
        }

        public DataTable ListaPedidos()
        {

            String str = "select " +
                       " nroPedido , titulo , Status  , fechaPedido " +
                       "from stockPedido where UsuarioPedido like  @search ";

            con.Open();
            SqlCommand xp = new SqlCommand(str, con);
            xp.Parameters.Add("@search", SqlDbType.NVarChar).Value = cod_actor;
            SqlDataReader reader = xp.ExecuteReader();

            DataTable tabla = new DataTable();
            tabla.Columns.Add("Nro");
            tabla.Columns.Add("Titulo");
            tabla.Columns.Add("Status");
            tabla.Columns.Add("Fecha");

            while (reader.Read())
            {

                DataRow fila = tabla.NewRow();
                
                String Nropedido = "DetallePedido.aspx?" + String.Format("{0}", reader[0]);
                fila["Nro"] = "<a href='" + Nropedido + "'>" + Convert.ToInt32(String.Format("{0}", reader[0])) + "</a>";
                fila["Titulo"] = String.Format("{0}", reader.GetString(1));
                fila["Status"] = aux.colorStatus(String.Format("{0}", reader.GetString(2)));
                fila["Fecha"] = String.Format("{0}", reader.GetString(3));

                tabla.Rows.Add(fila);

            }
            con.Close();
            return tabla;


        }



   
    }
}
