using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace StockManagementSystem.Clases
{
    public class Auxiliares
    {

        public  string ConvertDataTableToHTML(DataTable dt)
        {
            string html = "<table  runat='server' class='table table-striped'>";
            //add header row
            html += "<thead><tr>";
            for (int i = 0; i < dt.Columns.Count; i++)
                html += "<th>" + dt.Columns[i].ColumnName + "</th>";
            html += "</tr></thead>";
            //add rows
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                html += "<tbody><tr>";
                for (int j = 0; j < dt.Columns.Count; j++)
                    html += "<td text-aling='left'>" + dt.Rows[i][j].ToString() + "</td>";

                html += "</tr>";
            }
            html += "</tbody></table>";
            return html;
        }
        public String colorStatus(String st)
        {

            String color = "";
            if (st.Equals("Completado"))
            {
                color = "<h style='color: green; '>Completado</h>";

            }

            if (st.Equals("En Proceso"))
            {
                color = "<h style='color: brown; '>En Proceso</h>";

            }


            if (st.Equals("Parcial"))
            {
                color = "<h style='color: orange; '>Parcial</h>";

            }
            if (st.Equals("Pendiente"))
            {
                color = "<h style='color: orange; '>Pendiente</h>";

            }

            if (st.Equals("Cancelado"))
            {
                color = "<h style='color: red; '>Cancelado</h>";

            }

            return color;

        }
        
    }
}