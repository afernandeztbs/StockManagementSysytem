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
    public partial class WebForm4 : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection("Data Source= srv-sql01; Initial Catalog = MTDesa; Integrated Security = True");
        public string cod_actor;
        Auxiliares aux = new Auxiliares();
        public string html = "";
        String search ;
        String sector;

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Collections.Specialized.NameValueCollection
            UserInfoCookieCollection;
            UserInfoCookieCollection = Request.Cookies["userInfo"].Values;
            cod_actor = Server.HtmlEncode(UserInfoCookieCollection["cod_actor"]);

            if (!Page.IsPostBack)
            { //Esto ocurre solo la primera vez que se carga tu página
              //Inicializas tus variables y las almacenas en el Session
                html = "";
                search = "";
                sector = "";
                Page.Session["search"] = search;
                Page.Session["html"] = html;
                Page.Session["sector"] = sector;
                sectorPorDefecto();
            }
            else
            { //Si no es la primera vez que se recarga la página ( Esto puede suseder cuando el servidor responde a un click del boton por ejemplo
              //obtienes el valor de tus variables desde el Session
                search = Page.Session["search"].ToString();
                html = Page.Session["html"].ToString();
                sector = Page.Session["sector"].ToString();

            }


        }


        public DataTable ListaPedidos()
        {

            String str = "select " +
                       " nroPedido , titulo , Status  , fechaPedido, Sector  " +
                       "from stockPedido where status like '%' + @search + '%' and status in ('Pendiente','En Proceso') and sector like '%' + @sector + '%'";

            con.Open();
            SqlCommand xp = new SqlCommand(str, con);
            xp.Parameters.Add("@search", SqlDbType.NVarChar).Value = search;
            xp.Parameters.Add("@sector", SqlDbType.NVarChar).Value = sector;
            SqlDataReader reader = xp.ExecuteReader();

            DataTable tabla = new DataTable();
            tabla.Columns.Add("Nro");
            tabla.Columns.Add("Titulo");
            tabla.Columns.Add("Status");
            tabla.Columns.Add("Fecha");
            tabla.Columns.Add("Sector");

            while (reader.Read())
            {

                DataRow fila = tabla.NewRow();

                String Nropedido = "EntregaPedido.aspx?" + String.Format("{0}", reader[0]);
                fila["Nro"] = "<a href='" + Nropedido + "'>" + Convert.ToInt32(String.Format("{0}", reader[0])) + "</a>";
                fila["Titulo"] = String.Format("{0}", reader.GetString(1));
                fila["Status"] = aux.colorStatus(String.Format("{0}", reader.GetString(2)));
                fila["Fecha"] = String.Format("{0}", reader.GetString(3));
                fila["Sector"] = String.Format("{0}", reader.GetString(4));

                tabla.Rows.Add(fila);

            }
            con.Close();
            return tabla;


        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem.Value.Equals("Todo")){

                search = "";
            }
            else
            {
                search = DropDownList1.SelectedItem.Value;

            }

            if (sectores.SelectedItem.Value.Equals("Todo"))
            {

                sector = "";
            }
            else
            {
                sector = sectores.SelectedItem.Value;

            }

            html = aux.ConvertDataTableToHTML(ListaPedidos());
        }

        public void sectorPorDefecto()
        {

            SqlConnection con = new SqlConnection("Data Source= srv-sql01; Initial Catalog = MTDesa; Integrated Security = True");

            String str = "select " +
                     " position " +
                     "from cte_actores where cod_actor = @search";

            con.Open();
            SqlCommand xp = new SqlCommand(str, con);
            xp.Parameters.Add("@search", SqlDbType.NVarChar).Value = cod_actor;
            SqlDataReader reader = xp.ExecuteReader();
            String position = "";
            while (reader.Read())
            {
                position = String.Format("{0}", reader[0]);
            }
            if (position.Equals("Resources Centre Junior - Administration"))
            {
                sectores.SelectedIndex = 1;

            }
            if (position.Equals("Resources Centre Senior - Administration"))
            {
                sectores.SelectedIndex = 2;
            }
            if (cod_actor.Equals("57014") || cod_actor.Equals("57269"))
            {
                sectores.SelectedIndex = 2;
            }

            reader.Close();
            con.Close();
        }
    }
}
