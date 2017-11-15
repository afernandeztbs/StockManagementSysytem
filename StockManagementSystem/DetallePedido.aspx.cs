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
    public partial class WebForm3 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source= srv-sql01; Initial Catalog = MTDesa; Integrated Security = True");
        public string cod_actor;
        public string html;
        Auxiliares aux = new Auxiliares();

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
                       "  nroLinea , cod_articulo,nom_articulo  ,Comentario, cantPedido, cantEntregado,status " +
                       "from stockPedidoDetalle where nroPedido =  @search ";

            con.Open();
            SqlCommand xp = new SqlCommand(str, con);
            xp.Parameters.Add("@search", SqlDbType.NVarChar).Value = Convert.ToInt32(Request.Url.Query.Split('?').Last());
            SqlDataReader reader = xp.ExecuteReader();

            DataTable tabla = new DataTable();
            tabla.Columns.Add("Linea");
            tabla.Columns.Add("Código Articulo");
            tabla.Columns.Add("Nombre Articulo");
            tabla.Columns.Add("Comentario");
            tabla.Columns.Add("Cantidad Pedido");
            tabla.Columns.Add("Cantidad Entregado");
            tabla.Columns.Add("Status");

            while (reader.Read())
            {

                DataRow fila = tabla.NewRow();
                fila["Linea"] = String.Format("{0}", reader.GetInt32(0));
                fila["Código Articulo"] = String.Format("{0}", reader.GetString(1));
                fila["Nombre Articulo"] = String.Format("{0}", reader.GetString(2));
                fila["Comentario"] = String.Format("{0}", reader.GetString(3));
                fila["Cantidad Pedido"] = String.Format("{0}", reader.GetInt32(4));
                fila["Cantidad Entregado"] = String.Format("{0}", reader.GetInt32(5));
                fila["Status"] = aux.colorStatus(String.Format("{0}", reader.GetString(6)));

                tabla.Rows.Add(fila);

            }
            con.Close();
            return tabla;


        }
    }
}