using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystem.Clases
{
    public class Actor
    {
        public int cod_actor { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String username { get; set; }
        public String email { get; set; }
        public String sector { get; set; }
        public String area { get; set; }

        public Actor(int cod_actor, string nombre, string apellido,
            string username, string email, string sector, string area)
        {
            this.cod_actor = cod_actor;
            this.nombre = nombre;
            this.apellido = apellido;
            this.username = username;
            this.email = email;
            this.sector = sector;
            this.area = area;
        }

        public Actor()
        {
            this.cod_actor = 0;
            this.nombre = "";
            this.apellido = "";
            this.username = "";
            email = "";
            this.sector = "";
            this.area = "";

        }
    }
}