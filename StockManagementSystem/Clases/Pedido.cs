using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace StockManagementSystem.Clases
{
    public class Pedido
    {

        Auxiliares aux = new Auxiliares();

        private int NroPedido { get; set; }
        private String Titulo { get; set; }
        private List<LineaPedido> ListaPedido { get; set; }
        private String Status { get; set; }
        private String FechaPedido { get; set; }
        private String FechaCompleto { get; set; }
        private int UsuPedido { get; set; }
        private String Area { get; set; }
        private String Sector { get; set; }



        public Pedido() {

            NroPedido = 0;
            Titulo = "";
            ListaPedido = new List<LineaPedido>();
            Status = "Pendiente";
            FechaPedido = DateTime.Today.ToShortDateString();

        }


        public Pedido(int nro, String titulo, String st, int usu, String a, String s)
        {
            NroPedido = nro;
            Titulo = titulo;
            Status = st;
            FechaPedido = DateTime.Today.ToShortDateString();
            FechaCompleto = "";
            UsuPedido = usu;
            Area = a;
            Sector = s;
            ListaPedido = new List<LineaPedido>();


        }

        public bool agregarArticulo(LineaPedido linea)
        {

            if (existeArticulo(linea))
            {

                return false;
            }
            else
            {
                ListaPedido.Add(linea);
                return true;

            }



        }

        public bool borrarArticulo(LineaPedido articulo)
        {
            bool borro = true;

            if (!articulo.esVacio())
            {
                ListaPedido.Remove(articulo);


                return borro;

            }
            return !borro;
        }

        private bool existeArticulo(LineaPedido linea)
        {
            bool existe = true;
            if (ListaPedido.Count == 0)
            {
                return false;
            }
            for (int i = 0; i < this.ListaPedido.Count; i++)
            {
                if (linea.getCodArticulo().Equals(this.ListaPedido.ElementAt(i).getCodArticulo()))
                {
                    return existe;

                }
            }

            return !existe;
        }

        private bool estaCompleto() {

            bool completo = true;
            for (int i = 0; i <= ListaPedido.Count; i++)
            {
                LineaPedido lineaActual = ListaPedido.ElementAt(i);

                if (lineaActual.getCantEntregado() != lineaActual.getCantPedido())
                {

                    return !completo;
                }
                    
            }

            
            return completo;

        }

        public DataTable tabla()
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Nro");
            tabla.Columns.Add("Código");
            tabla.Columns.Add("Nombre");
            tabla.Columns.Add("Comentario");
            tabla.Columns.Add("CantidadPedida");
            tabla.Columns.Add("CantidadEntregada");
            tabla.Columns.Add("Status");
            tabla.Columns.Add("Borrar");
            int i = 1;
            foreach (LineaPedido item in ListaPedido)
            {

                DataRow fila = tabla.NewRow();


                String borrar = "<a runat= 'server' href='#' onclick='borrar(); return false;'>Borrar</a>";



                //"<asp:Button ID='"+i+"'   Text='Save' class='btn btn-primary btn - sm'  OnClick='borrar();' />";


                fila["Nro"] = i;
                fila["Código"] = item.getCodArticulo();
                fila["Nombre"] = item.getNomArticulo();
                fila["Comentario"] = item.getComentario();
                fila["CantidadPedida"] = item.getCantPedido();
                fila["CantidadEntregada"] = item.getCantEntregado();
                fila["Status"] = aux.colorStatus(item.getStatus());
                fila["Borrar"] = borrar;
                tabla.Rows.Add(fila);
                i++;
            }


            return tabla;
        }

        public List<LineaPedido> getListaPedido()
        {

            return ListaPedido;
        }
    }
}