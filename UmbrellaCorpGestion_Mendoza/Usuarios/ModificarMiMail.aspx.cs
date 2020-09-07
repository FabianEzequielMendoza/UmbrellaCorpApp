using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UmbrellaCorpGestion_Mendoza.Usuarios
{
    public partial class ModificarMiMail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnConfirmar_Click(object sender, EventArgs e)
        {
            //username del usuario
            string username = Thread.CurrentPrincipal.Identity.Name; 

            //actualizar mail
            string query = @"UPDATE usuarios " +
                "SET mail=(@mail)" +
                "WHERE username=(@user)";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());// ESTABLECEMOS LA CONEXION

            try
            {
                SqlCommand command = new SqlCommand(query, conn); // CREAMOS EL COMANDO SQL A EJECUTAR

                command.Parameters.AddWithValue("mail", TBMail.Text);
                command.Parameters.AddWithValue("user", username);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();

                Label1.Text = "Se ha cambiado el mail exitosamente";
            }
            catch (Exception)
            {
                Label1.Text = "Se ha producido un error inesperado, volvé a intentarlo más tarde";

            }
        }
    }
}