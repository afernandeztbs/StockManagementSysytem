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
    public partial class WebForm1 : System.Web.UI.Page
    {

        public string html;
        public string mensaje = "";
        public Pedido pedido;
        public string cod_actor;
        public Auxiliares aux = new Auxiliares();
        SqlConnection con = new SqlConnection("Data Source= srv-sql01; Initial Catalog = MTDesa; Integrated Security = True");



        protected void Page_Load(object sender, EventArgs e)
        {

            System.Collections.Specialized.NameValueCollection
            UserInfoCookieCollection;
            UserInfoCookieCollection = Request.Cookies["userInfo"].Values;
            cod_actor = Server.HtmlEncode(UserInfoCookieCollection["cod_actor"]);


            if (!Page.IsPostBack)
            { //Esto ocurre solo la primera vez que se carga tu página
              //Inicializas tus variables y las almacenas en el Session
                pedido = new Pedido();
                html = "<p></p>";
                Page.Session["pedido"] = pedido;
                Page.Session["html"] = html;
            }
            else
            { //Si no es la primera vez que se recarga la página ( Esto puede suseder cuando el servidor responde a un click del boton por ejemplo
              //obtienes el valor de tus variables desde el Session
                pedido = (Pedido)Page.Session["pedido"];

                html = aux.ConvertDataTableToHTML(pedido.tabla());


            }

        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            String str = "select " +
                        " nom_articulo " +
                        "from ct_articulos where nom_articulo like '%' + @search + '%'";

            con.Open();
            SqlCommand xp = new SqlCommand(str, con);
            xp.Parameters.Add("@search", SqlDbType.NVarChar).Value = Buscador.Text;


            //Cargo Lista

            Articulos.DataSource = xp.ExecuteReader();
            Articulos.DataTextField = "nom_articulo";
            Articulos.DataBind();


            con.Close();
        }

        protected void BtnSelect_Click(object sender, EventArgs e)
        {
            String str = "select " +
                         " cod_articulo " +
                         "from ct_articulos where nom_articulo like '%' + @search + '%'";

            con.Open();
            SqlCommand xp = new SqlCommand(str, con);
            xp.Parameters.Add("@search", SqlDbType.NVarChar).Value = Articulos.SelectedItem.ToString();
            SqlDataReader reader = xp.ExecuteReader();

            while (reader.Read())
            {
                CodArticulo.Text = String.Format("{0}", reader[0]);
            }

            NomArticulo.Text = Articulos.SelectedItem.ToString();



            con.Close();
        }

        protected void insert_Click(object sender, EventArgs e)
        {

            LineaPedido articulo = new LineaPedido();
            if (!cantPedida.Text.Equals(""))
            {
                articulo = new LineaPedido(CodArticulo.Text, NomArticulo.Text, Comentario.Text, Convert.ToInt32(cantPedida.Text),0,"Pendiente",0);


                if (!articulo.esVacio())
                {
                    if (articulo.cantidadValida())
                    {

                        if (pedido.agregarArticulo(articulo))
                        {


                            html = aux.ConvertDataTableToHTML(pedido.tabla());

                            mensaje = "<div class='alert alert-success'>" +
                            " Se agrego satifactoriamente el articulo <strong>" + articulo.getCodArticulo() +
                            "</strong></div>";
                            LimpiarCampos();

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
                        "<strong>Error:</strong> El articulo no puede ser vacío.</div>";
                }

            }
            else
            {

                mensaje = "<div class='alert alert-danger'>";
                mensaje += "<strong>Error:</strong> La cantidad no puede ser vacía.</div>";
            }
        }

        protected void save_Click(object sender, EventArgs e)
        {
            if (Titulo.Text.Equals(""))
            {
                mensaje = "<div class='alert alert-danger'>" +
                                            "<strong>Error:</strong> El titulo del pedido no puede ser vacío.</div>";
            }
            else
            {
                if (pedido.getListaPedido().Count == 0)
                {
                    mensaje = "<div class='alert alert-danger'>" +
                            "<strong>Error:</strong>La lista de articulos no puede estar vacía.</div>";
                }
                else
                {

                    Actor a = actorInsert(cod_actor);

                    SqlConnection con3 = new SqlConnection("Data Source= srv-sql01; Initial Catalog = MTDesa; Integrated Security = True");
                    String cantidad = "select count(*) from stockPedido";

                    SqlCommand xp3 = new SqlCommand(cantidad, con3);
                    con3.Open();


                    int cantP = Convert.ToInt32(xp3.ExecuteScalar()) + 1;
                    con3.Close();

                    String str = "insert into dbo.StockPedido values( " +
                                cantP + ", '" + Titulo.Text + "' , 'Pendiente','" + DateTime.Today.ToShortDateString()+"',''," +
                                cod_actor + ",'" + a.area + "','" + a.sector +"');";

                    SqlCommand xp;
                    for (int i = 0; i < pedido.getListaPedido().Count; i++)
                    {

                        LineaPedido lineaActual = pedido.getListaPedido().ElementAt(i);

                        String lineas = "insert into dbo.StockPedidoDetalle   " +
                            "values(" + cantP + "," + (i + 1) + ",'" + lineaActual.getCodArticulo().Trim() + 
                            "','"+lineaActual.getNomArticulo() + "','" + lineaActual.getComentario() + "'," +
                            lineaActual.getCantPedido() +","+lineaActual.getCantEntregado()+",'Pendiente','');";

                        SqlConnection con2 = new SqlConnection("Data Source= srv-sql01; Initial Catalog = MTDesa; Integrated Security = True");
                        SqlCommand xp1 = new SqlCommand(lineas, con2);
                        con2.Open();

                        xp1.ExecuteNonQuery();
                        con2.Close();

                    }


                    xp = new SqlCommand(str, con);
                    con.Open();
                    xp.ExecuteNonQuery();
                    mensaje = "<div class='alert alert-success'>" +
                             " Se creo satifactoriamente el pedido <strong> Nro " + cantP + ": " + Titulo.Text +
                             "</strong></div>";
                    LimpiarCampos();

                    con.Close();
                }
            }
        }

        // 

        public void LimpiarCampos() {

            Comentario.Text = "";
            Buscador.Text = "";
            cantPedida.Text = "";
            cantStock.Text = "";
            CodArticulo.Text = "";
            NomArticulo.Text = "";
            DataTable t = new DataTable();
            Articulos.DataSource = t;
            Articulos.DataBind();


        }

        public Actor actorInsert(string cod_actor)
        {

            int nro = Convert.ToInt32(cod_actor);
            Actor actor = new Actor();
            String str = "select cod_actor, nombre1, apellido1 ,username ,email,position,SucNom " +
            " from v_funcionariosactivos" +
            " where cod_actor =  @user";
            con.Open();
            SqlCommand xp = new SqlCommand(str, con);
            xp.Parameters.Add("@user", SqlDbType.NVarChar);
            xp.Parameters["@user"].Value = cod_actor;
            SqlDataReader reader = xp.ExecuteReader();

            while (reader.Read())
            {
                actor.cod_actor = Convert.ToInt32(String.Format("{0}", reader[0]));
                actor.nombre = String.Format("{0}", reader.GetString(1));
                actor.apellido = String.Format("{0}", reader.GetString(2));
                actor.username = String.Format("{0}", reader.GetString(3));
                actor.email = String.Format("{0}", reader.GetString(4));
                actor.sector = String.Format("{0}", reader.GetString(5));
                actor.area = String.Format("{0}", reader.GetString(6));
            }

            con.Close();

            return actor;

        }

    }
}