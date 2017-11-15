using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystem.Clases
{
    public class LineaPedido
    {
        private String Cod_Articulo { get; set; }
        private String Nom_Articulo { get; set; }
        private String Comentario { get; set; }
        private int CantPedido { get; set; }
        private int CantEntregado { get; set; }
        private String Status { get; set; }
        private int UsuEntrega { get; set; }


        public LineaPedido() { }



        public LineaPedido(String articulo,String nom, String com, int cantP, int cantE, String st, int usu)
        {
            Cod_Articulo = articulo;
            Nom_Articulo = nom;
            Comentario = com;
            CantPedido = cantP;
            CantEntregado = cantE;
            Status = st;
            UsuEntrega = usu;
            
        }



        //GET
        public String getCodArticulo() {

            return this.Cod_Articulo;

        }

        public String getNomArticulo()
        {

            return this.Nom_Articulo;

        }

        public String getComentario()
        {

            return this.Comentario;

        }

        public int getCantEntregado()
        {

            return this.CantEntregado;

        }

        public int getCantPedido()
        {

            return this.CantPedido;

        }

        public String getStatus()
        {

            return this.Status;

        }




        public bool esVacio()
        {
            bool esVacio = true;
            if (Cod_Articulo.Equals( ""))
            {

                return esVacio;
            }


            return !esVacio;
        }

        public bool cantidadValida()
        {
            bool valido = true;

            if (CantPedido > 0)
            {


                return valido;
            }


            return !valido;
        }

    }
}