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
    public partial class WebForm7 : System.Web.UI.Page
    {
        public string cod_actor;
        Auxiliares aux = new Auxiliares();
        public string html = "";
        String search;
        String actorBuscar;
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
                actorBuscar = "";
                sector = "";
                Page.Session["search"] = search;
                Page.Session["actorBuscar"] = actorBuscar;
                Page.Session["sector"] = sector;
                Page.Session["html"] = html;
                sectorPorDefecto();
            }
            else
            { //Si no es la primera vez que se recarga la página ( Esto puede suseder cuando el servidor responde a un click del boton por ejemplo
              //obtienes el valor de tus variables desde el Session
                search = Page.Session["search"].ToString();
                actorBuscar = Page.Session["actorBuscar"].ToString();
                sector = Page.Session["sector"].ToString();
                html = Page.Session["html"].ToString();

            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem.Value.Equals("Todo"))
            {

                search = "";
            }
            else
            {
                search = DropDownList1.SelectedItem.Value;

            }

            if (Sectores.SelectedItem.Value.Equals("Todo"))
            {
                sector = "";
            }
            else
            {
                sector = Sectores.SelectedItem.Value;
            }

            if (actor.Text.Trim().Equals(""))
            {
                actorBuscar = "";

            }
            else
            {
                actorBuscar = actor.Text;
            }

            html = aux.ConvertDataTableToHTML(ListaPedidos());
        }



        public DataTable ListaPedidos()
        {
            SqlConnection con = new SqlConnection("Data Source= srv-sql01; Initial Catalog = MTDesa; Integrated Security = True");

            String str = "select " +
                       " s.nroPedido , s.titulo , s.Status , a.nombre1 +' '+ isnull(a.apellido1,'') , isnull(a.email,'') ,s.fechaPedido, s.fechaCompletado, s.Sector " +
                       "from stockPedido s," +
                       "cte_actores a" +
                       " where s.status like '%' + @search + '%' and (a.nombre1 like '%' + @actor + '%' or a.apellido1 like '%' + @actor + '%') and " +
                       "s.sector like  '%' + @sector + '%'  and  s.UsuarioPedido = a.cod_actor";

            con.Open();
            SqlCommand xp = new SqlCommand(str, con);
            xp.Parameters.Add("@search", SqlDbType.NVarChar).Value = search;
            xp.Parameters.Add("@actor", SqlDbType.NVarChar).Value = actorBuscar;
            xp.Parameters.Add("@sector", SqlDbType.NVarChar).Value = sector;
            SqlDataReader reader = xp.ExecuteReader();

            DataTable tabla = new DataTable();
            tabla.Columns.Add("Nro");
            tabla.Columns.Add("Titulo");
            tabla.Columns.Add("Status");
            tabla.Columns.Add("Usuario");
            tabla.Columns.Add("Email");
            tabla.Columns.Add("Fecha Pedido");
            tabla.Columns.Add("Fecha Completo");
            tabla.Columns.Add("Sector");

            while (reader.Read())
            {

                DataRow fila = tabla.NewRow();
                String Nropedido = "";
                if (String.Format("{0}", reader.GetString(2)).Equals("Pendiente") || String.Format("{0}", reader.GetString(2)).Equals("En Proceso"))
                {
                    Nropedido = "EntregaPedido.aspx?" + String.Format("{0}", reader[0]);
                }


                fila["Nro"] = "<a href='" + Nropedido + "'>" + Convert.ToInt32(String.Format("{0}", reader[0])) + "</a>";
                fila["Titulo"] = String.Format("{0}", reader.GetString(1));
                fila["Status"] = aux.colorStatus(String.Format("{0}", reader.GetString(2)));
                fila["Usuario"] = String.Format("{0}", reader.GetString(3));
                fila["Email"] = String.Format("{0}", reader.GetString(4));
                fila["Fecha Pedido"] = String.Format("{0}", reader.GetString(5));
                fila["Fecha Completo"] = String.Format("{0}", reader.GetString(6));
                fila["Sector"] = String.Format("{0}", reader.GetString(7));

                tabla.Rows.Add(fila);

            }
            con.Close();
            return tabla;


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
                Sectores.SelectedIndex = 1;

            }
            if (position.Equals("Resources Centre Senior - Administration"))
            {
                Sectores.SelectedIndex = 2;
            }
            if (cod_actor.Equals("57014") || cod_actor.Equals("57269"))
            {
                Sectores.SelectedIndex = 2;
            }

            reader.Close();
            con.Close();
        }
    }
}