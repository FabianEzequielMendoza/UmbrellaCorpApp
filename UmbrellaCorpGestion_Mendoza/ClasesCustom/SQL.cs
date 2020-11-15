using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace UmbrellaCorpGestion_Mendoza.ClasesCustom
{
    public class SQL
    {
        public static void Establecer_Consulta_GridView(string query, GridView GridView1, Label Label1)
        {
            Label1.Text = "";
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    if (da.Fill(ds) == 0)
                    {
                        Label1.ForeColor = Color.Red;
                        Label1.Text = "No se encontraron resultados";
                    }
                }
            }
            catch (Exception ex)
            {
                Label1.ForeColor = Color.Red;
                Label1.Text = "Error inesperado";

            }
        }

    }
}