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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "" || txtUsername.Text == "")
            {
                Response.Redirect("inicio.aspx");
            }
            else
            {

                Session["user"] = txtUsername.Text;
                Session["dominio"] = "british.edu.uy";
                Session["pass"] = txtPassword.Text;
                SqlConnection con = new SqlConnection("Data Source= srv-sql01; Initial Catalog = MTDesa; Integrated Security = True");

                String str = "select " +
                           " cod_actor , MTProd.dbo.getNombreCompleto(cod_actor,'NombreCompleto')" +
                           "from cte_Actores where username = @user ";

                con.Open();
                SqlCommand xp = new SqlCommand(str, con);
                xp.Parameters.Add("@user", SqlDbType.NVarChar).Value = txtUsername.Text;
                SqlDataReader reader = xp.ExecuteReader();
                String cod_actor = "";
                String name = "";
                while (reader.Read())
                {
                    cod_actor = String.Format("{0}", reader[0]);
                    name = String.Format("{0}", reader.GetString(1));
                }

                Response.Cookies["userInfo"]["cod_actor"] = cod_actor;
                Response.Cookies["userInfo"]["name"] = name;
                Response.Cookies["userInfo"]["lastVisit"] = DateTime.Now.ToString();

                HttpCookie aCookie = new HttpCookie("userInfo");
                aCookie.Values["cod_actor"] = cod_actor;
                aCookie.Values["name"] = name;

                aCookie.Values["lastVisit"] = DateTime.Now.ToString();
                Response.Cookies.Add(aCookie);
                Response.Redirect("PedidoWeb.aspx");
            }
        }
    }
}