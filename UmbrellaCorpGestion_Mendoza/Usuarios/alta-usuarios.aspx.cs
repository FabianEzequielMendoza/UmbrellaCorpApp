using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UmbrellaCorpGestion_Mendoza.ClasesCustom;

namespace UmbrellaCorpGestion_Mendoza.Usuarios
{
    public partial class alta_usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnEntrar_Click(object sender, EventArgs e)
        {
            string query1 = @"INSERT INTO usuarios (username,pass,mail,fechaIngreso,activo)
                            VALUES (@TB1,@TB2,@TB3,@TB4,@TB5)";
            string query2 = @"INSERT INTO permisos (permiso)
                            VALUES (@TB6)";
            string queryValidar = @"SELECT * FROM usuarios WHERE username LIKE @TB1";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());// ESTABLECEMOS LA CONEXION

            if (TBPass.Text == TBVerificar.Text)
            {
                try
                {
                    SqlCommand commandValidation = new SqlCommand(queryValidar, conn); // CREAMOS EL COMANDO SQL A EJECUTAR
                    commandValidation.Parameters.AddWithValue("TB1", TBUsuario.Text);
                    conn.Open();
                    SqlDataReader leerbd = commandValidation.ExecuteReader();
                    SqlCommand command = new SqlCommand(query1, conn); // CREAMOS EL COMANDO SQL A EJECUTAR
                    SqlCommand command2 = new SqlCommand(query2, conn);// CREAMOS EL COMANDO SQL A EJECUTAR
                    if (leerbd.Read() == true)
                    {
                        Label1.Text = "Usuario existente";
                        conn.Close();
                    }
                    else
                    {
                        try
                        {
                            conn.Close();
                            command.Parameters.AddWithValue("TB1", TBUsuario.Text);
                            string hash = Encriptar.ConvertiraHash(TBPass.Text);
                            command.Parameters.AddWithValue("TB2", hash);
                            command.Parameters.AddWithValue("TB3", TBMail.Text);
                            command.Parameters.AddWithValue("TB4", DateTime.Now);
                            command.Parameters.AddWithValue("TB5", 1);
                            command2.Parameters.AddWithValue("TB6", TBUsuario.Text);
                            conn.Open();//ABRIMOS LA CONEXION
                            command.ExecuteNonQuery(); // EJECUTAMOS EL COMANDO DEFINITIVO
                            command2.ExecuteNonQuery(); // EJECUTAMOS EL COMANDO DEFINITIVO
                            conn.Close(); // CERRAMOS LA CONEXION
                            Label1.Text = "Se agregaron los registros correctamente.";
                        }
                        catch (Exception )
                        {
                            Label1.Text = "Se ha producido un error inesperado, volvé a intentarlo más tarde";
                        }

                    }
                }
                catch (Exception)
                {
                    Label1.Text = "Se ha producido un error inesperado, volvé a intentarlo más tarde";

                }
            }
            else
            {
                Label1.Text = "Por favor, volvé a verificar las contraseñas";
            }
            
        }

        protected void BtnCancerlar_Click(object sender, EventArgs e)
        {

        }
    }
}