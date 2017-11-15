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
    public partial class WebForm5 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source= srv-sql01; Initial Catalog = MTDesa; Integrated Security = True");
        public   String mensaje;
        public string cod_actor;
        public String nro;

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Collections.Specialized.NameValueCollection
              UserInfoCookieCollection;
            UserInfoCookieCollection = Request.Cookies["userInfo"].Values;
            cod_actor = Server.HtmlEncode(UserInfoCookieCollection["cod_actor"]);
            if (!Page.IsPostBack)
            {
             
                Page.Session["nro"] = Request.Url.Query.Split('?').Last();
                lista(Request.Url.Query.Split('?').Last());
                Articulos.SelectedIndex = 0;
            }
            else
            {
                nro = Page.Session["nro"].ToString();
               
            }
        }
        protected void BtnSelect_Click(object sender, EventArgs e)
        {
          
                int lug = Articulos.SelectedIndex;
                String s = Articulos.SelectedItem.ToString();
                String str = "select " +
                          " cod_articulo, nom_articulo, comentario, cantPedido, cantEntregado " +
                          "from StockPedidoDetalle where nroPedido = @search  and nom_articulo like @nom";


                con.Open();
                SqlCommand xp = new SqlCommand(str, con);
                xp.Parameters.Add("@search", SqlDbType.NVarChar).Value = Convert.ToInt32(nro);
                
                xp.Parameters.Add("@nom", SqlDbType.NVarChar).Value = s;
                SqlDataReader reader = xp.ExecuteReader();
                while (reader.Read())
                {


                    CodArticulo.Text = String.Format("{0}", reader.GetString(0));
                    NomArticulo.Text = String.Format("{0}", reader.GetString(1));
                    Comentario.Text = String.Format("{0}", reader.GetString(2));
                    cantPedido.Text = String.Format("{0}", reader.GetInt32(3));
                    cantEntregado.Text = String.Format("{0}", reader.GetInt32(4));
                }
                con.Close();
            
           
        }
        protected void save_Click(object sender, EventArgs e)
        {
            if (!cantAEntregar.Text.Equals(""))
            {
                if (Convert.ToInt32(cantAEntregar.Text) < 0)
                {
                    if (Convert.ToInt32(cantAEntregar.Text) <= (Convert.ToInt32(cantPedido.Text) - Convert.ToInt32(cantEntregado.Text)))
                    {

                        String str = "update stockpedidodetalle set cantEntregado = @entrego" +
                                           " where nroPedido = @search and cod_articulo like @nom";

                        String str2 = "update stockpedidodetalle set usuEntrega = @usu" +
                                           " where nroPedido = @search  and cod_articulo like @nom";
                        con.Open();
                        SqlCommand xp = new SqlCommand(str, con);
                        SqlCommand xp2 = new SqlCommand(str2, con);
                        xp.Parameters.Add("@search", SqlDbType.NVarChar).Value = Convert.ToInt32(nro);

                        xp.Parameters.Add("@nom", SqlDbType.NVarChar).Value = CodArticulo.Text;
                        xp.Parameters.Add("@entrego", SqlDbType.NVarChar).Value = Convert.ToInt32(cantAEntregar.Text) + Convert.ToInt32(cantEntregado.Text);

                        xp2.Parameters.Add("@search", SqlDbType.NVarChar).Value = Convert.ToInt32(nro);

                        xp2.Parameters.Add("@nom", SqlDbType.NVarChar).Value = CodArticulo.Text;
                        xp2.Parameters.Add("@usu", SqlDbType.NVarChar).Value = Convert.ToInt32(cod_actor);

                        xp.ExecuteNonQuery();
                        xp2.ExecuteNonQuery();
                        String art = CodArticulo.Text;
                        mensaje = "<div class='alert alert-success'>" +
                                    " Se entrego " + cantAEntregar.Text + " del <strong>" + art +
                                    "</strong></div>";
                        con.Close();
                        lista(nro);
                        lineaCompleta(Convert.ToInt32(nro));
                        limpiarCampos();


                    }
                    else
                    {
                        mensaje = "<div class='alert alert-danger'>" +
                               "<strong>Error:</strong> La cantidad a entregar no puede ser mayor" +
                               "a la cantidad pedida menos la entregada.</div>";
                    }



                }
                else
                {

                    mensaje = "<div class='alert alert-danger'>" +
                               "<strong>Error:</strong> La cantidad debe ser mayor a 0.</div>";


                }
            }
            else
            {
                mensaje = "<div class='alert alert-danger'>" +
                             "<strong>Error:</strong> La cantidad debe ser mayor a 0.</div>";
            }
        }
        protected void finPedido_Click(object sender, EventArgs e)
        {


            FinOCancelar("Completado");
            Response.Redirect("PedidoWeb.aspx");


        }
        protected void cancelar_Click(object sender, EventArgs e)
        {
            FinOCancelar("Cancelado");
            Response.Redirect("PedidoWeb.aspx");
        }

        //Aux
        public void lineaCompleta(int nroP)
        {
            String str = "update stockpedidodetalle set status = 'Completado'" +
                                      " where nroPedido = @search and cantPedido=cantEntregado";

            String str1 = "update stockpedidodetalle set status = 'Parcial'" +
                                      " where nroPedido = @search and cantPedido<>cantEntregado and cantEntregado>0";

            String str2 = "select count(*) from stockPedidodetalle" +
                          " where nroPedido = @search and cantPedido<>cantEntregado";

            String str3 = "update stockpedido set status = 'En Proceso'" +
                                     " where nroPedido = @search";

            String str4 = "update stockpedido set status = 'Completado'" +
                                     " where nroPedido = @search ";

            String str5 = "update stockpedido set FechaCompletado = '"+DateTime.Today.ToShortDateString()+"'" +
                                     " where nroPedido = @search ";
            con.Open();
            SqlCommand xp = new SqlCommand(str, con);
            SqlCommand xp1 = new SqlCommand(str1, con);
            SqlCommand xp2 = new SqlCommand(str2, con);
            SqlCommand xp3 = new SqlCommand(str3, con);
            SqlCommand xp4 = new SqlCommand(str4, con);
            SqlCommand xp5 = new SqlCommand(str5, con);


            xp.Parameters.Add("@search", SqlDbType.NVarChar).Value = nroP;
            xp.Parameters.Add("@nro", SqlDbType.NVarChar).Value = Articulos.SelectedIndex + 1;

            xp1.Parameters.Add("@search", SqlDbType.NVarChar).Value = nroP;
            xp1.Parameters.Add("@nro", SqlDbType.NVarChar).Value = Articulos.SelectedIndex + 1;

            xp2.Parameters.Add("@search", SqlDbType.NVarChar).Value = nroP;
            
            xp3.Parameters.Add("@search", SqlDbType.NVarChar).Value = nroP;
            
            xp4.Parameters.Add("@search", SqlDbType.NVarChar).Value = nroP;

            xp5.Parameters.Add("@search", SqlDbType.NVarChar).Value = nroP;
            xp.ExecuteNonQuery();
            xp1.ExecuteNonQuery();
            SqlDataReader reader = xp2.ExecuteReader();
            int i = 0;

            while (reader.Read())
            {
                i= Convert.ToInt32(String.Format("{0}", reader[0]));
            }

            reader.Close();

                if (i >0)
            {

                xp3.ExecuteNonQuery();

            }
            else
            {
                xp4.ExecuteNonQuery();
                xp5.ExecuteNonQuery();
                Response.Redirect("PedidoWeb.aspx");

            }

            con.Close();
            




        }
        public void lista(String i)
        {

            String str = "select " +
                       " nom_articulo " +
                       "from StockPedidoDetalle where nroPedido = @search and cantPedido<>cantEntregado";

            con.Open();
            SqlCommand xp = new SqlCommand(str, con);
            xp.Parameters.Add("@search", SqlDbType.NVarChar).Value = i;


            //Cargo Lista

            Articulos.DataSource = xp.ExecuteReader();
            Articulos.DataTextField = "nom_articulo";
            Articulos.DataBind();


            con.Close();
        }
        public void FinOCancelar(String s)
        {
            
            String str = "update stockpedidodetalle set status ='"+s+"'" +
                                    " where nroPedido = @search ";
            con.Open();
            SqlCommand xp = new SqlCommand(str, con);
            xp.Parameters.Add("@search", SqlDbType.NVarChar).Value = Convert.ToInt32(nro);
            xp.ExecuteNonQuery();
            con.Close();


            String str1 = "update stockpedido set status ='" + s + "'" +
                               " where nroPedido = @search ";

            con.Open();
            SqlCommand xp1 = new SqlCommand(str1, con);
            xp1.Parameters.Add("@search", SqlDbType.NVarChar).Value = Convert.ToInt32(nro);
            xp1.ExecuteNonQuery();
            con.Close();


            if (!s.Equals("Cancelado")) { 
            String str2 = "update stockpedido set FechaCompletado = @fecha" +
                               " where nroPedido = @search ";

            con.Open();
            SqlCommand xp2 = new SqlCommand(str2, con);
            xp2.Parameters.Add("@search", SqlDbType.NVarChar).Value = Convert.ToInt32(nro);
            xp2.Parameters.Add("@fecha", SqlDbType.NVarChar).Value = DateTime.Today.ToShortDateString();
            xp2.ExecuteNonQuery();
            con.Close();

            }

        }

        public void limpiarCampos() {

            CodArticulo.Text = "";
            NomArticulo.Text = "";
            cantAEntregar.Text = "";
            cantEntregado.Text = "";
            cantPedido.Text = "";
            Comentario.Text = "";
        }
    }
}