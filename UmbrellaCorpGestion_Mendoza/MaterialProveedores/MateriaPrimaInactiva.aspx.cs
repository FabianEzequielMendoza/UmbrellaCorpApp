using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UmbrellaCorpGestion_Mendoza.ClasesCustom;

namespace UmbrellaCorpGestion_Mendoza.MaterialProveedores
{
    public partial class MateriaPrimaInactiva : System.Web.UI.Page
    {
        public void Visibilidad_de_botones_on()
        {
            BtnActivar.Visible = true;
        }
        public void Visibilidad_de_botones_off()
        {
            BtnActivar.Visible = false;

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string query = "";
            try
            {
               query = "SELECT Id AS ID, nombre AS Nombre_Materia, pu AS Precio, cantidad AS Cantidad, proveedor AS Proveedor " +
              "FROM MateriaPrima " +
              "WHERE activo='False'";
               SQL.Establecer_Consulta_GridView(query, GridView1, Label1);
            }
            catch (Exception)
            {

                Label1.ForeColor = Color.Red;
                Label1.Text = "Se ha producido un error contáctese con el administrador";
            }

            Visibilidad_de_botones_off();
        }

        protected void BtnActivar_Click(object sender, EventArgs e)
        {
            string query1 = @"UPDATE MateriaPrima " +
               "SET activo ='True'" +
               "WHERE id=@Id";


            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());// ESTABLECEMOS LA CONEXION


            try
            {
                SqlCommand command = new SqlCommand(query1, conn); // CREAMOS EL COMANDO SQL A EJECUTAR
                command.Parameters.AddWithValue("Id", GridView1.SelectedDataKey.Values["ID"].ToString());

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
                Label1.ForeColor = Color.Green;
                Label1.Text = "Se ha activado a la materia exitosamente";
            }
            catch (Exception)
            {
                Label1.ForeColor = Color.Red;
                Label1.Text = "Se ha producido un error inesperado, volvé a intentarlo más tarde";

            }
            Visibilidad_de_botones_off();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/MaterialProveedores/ConsultaModificacionMateriaPrima.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Visibilidad_de_botones_on();
        }
    }
}