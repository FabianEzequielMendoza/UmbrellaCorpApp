using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UmbrellaCorpGestion_Mendoza.ClasesCustom;

namespace UmbrellaCorpGestion_Mendoza.Usuarios
{
    public partial class ModificarMiPass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnConfirmar_Click(object sender, EventArgs e)
        {
            string queryValidarPass = @"SELECT * FROM usuarios WHERE username=(@user) AND pass=(@pass)";


            string username = Thread.CurrentPrincipal.Identity.Name;
            string pass = TBContraseniaActual.Text;
            string passActualEncriptada = Encriptar.ConvertiraHash(pass);
            string newPass = TBNuevaContrasenia.Text;
            string repePass = TBRepetirContrasenia.Text;

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());// ESTABLECEMOS LA CONEXION

            if (newPass== repePass)
            {
                try
                {
                    SqlCommand commandValidation = new SqlCommand(queryValidarPass, conn); // CREAMOS EL COMANDO SQL A EJECUTAR
                    commandValidation.Parameters.AddWithValue("user", username);
                    commandValidation.Parameters.AddWithValue("pass", passActualEncriptada);
                    conn.Open();
                    SqlDataReader leerbd = commandValidation.ExecuteReader();
                    if (leerbd.Read() == true)
                    {
                        conn.Close();

                        try
                        {
                            //actualizar password
                            string query = @"UPDATE usuarios " +
                                "SET pass=(@pw)" +
                                "WHERE username=(@user)";

                            SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());// ESTABLECEMOS LA CONEXION
                          
                            SqlCommand command = new SqlCommand(query, conn2); // CREAMOS EL COMANDO SQL A EJECUTAR

                            newPass  = Encriptar.ConvertiraHash(newPass);

                            command.Parameters.AddWithValue("pw", newPass);
                            command.Parameters.AddWithValue("user", username);
                            conn2.Open();
                            command.ExecuteNonQuery();
                            conn2.Close();

                            Label1.Text = "Se ha cambiado la contraseña exitosamente";

                        }
                        catch (Exception)
                        {
                            Label1.Text = "Se produjo un error inesperado";
                        }


                    }
                    else
                    {
                        Label1.Text ="Contraseña actual incorrecta";
                    }
                }
                catch
                {
                    Label1.Text = "Se produjo un error inesperado";
                }
            }
            else
            {
                Label1.Text = "Por favor, volvé a verificar las contraseñas";
            }

        }
    }
}