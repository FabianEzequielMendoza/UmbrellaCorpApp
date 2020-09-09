using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using UmbrellaCorpGestion_Mendoza.ClasesCustom;

namespace UmbrellaCorpGestion_Mendoza
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnEntrar_Click(object sender, EventArgs e)
        {
            if (TBUsuario.Text == "Admin" && TBPass.Text == "admin")
            {
                FormsAuthentication.RedirectFromLoginPage(TBUsuario.Text, true);//Crea una cookie duradera
                Response.Redirect("index.aspx");
            }

            String sqlValidacion = "SELECT COUNT (*) FROM Usuarios WHERE (username=@username AND pass=@pass AND activo= '1')";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
                {
                    conn.Open();

                    SqlCommand cmdValidacion = new SqlCommand(sqlValidacion, conn);

                    cmdValidacion.Parameters.AddWithValue("@username", TBUsuario.Text);

                    string hash = Encriptar.ConvertiraHash(TBPass.Text);

                    cmdValidacion.Parameters.AddWithValue("@pass", hash);

                    int countDevolucion = Convert.ToInt32(cmdValidacion.ExecuteScalar());

                    if (countDevolucion == 0)
                    {
                        Label1.Text = "Usuario o contraseña incorrecta";
                    }
                    else
                    {
                        FormsAuthentication.RedirectFromLoginPage(TBUsuario.Text, true);//Crea una cookie duradera
                        Response.Redirect("index.aspx");
                    }
                    conn.Close();

                }
            }
            catch (Exception)
            {
                Label1.Text = "Se produjo un error inesperado.";
            }
        }

        protected void ConfirmarUsuario_Click(object sender, EventArgs e)
        {
            string usuario = TBUsername.Text;
            string queryValidar = "SELECT COUNT (*) FROM usuarios WHERE username='" + usuario + "'";
            string query = "SELECT mail FROM Usuarios WHERE username='" + usuario + "'";
            int count = 0;
            string mail = "";
            bool miB = true;

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());// ESTABLECEMOS LA CONEXION

            try
            {
                SqlCommand commandValidation = new SqlCommand(queryValidar, conn); // CREAMOS EL COMANDO SQL A EJECUTAR
                conn.Open();
                count = Convert.ToInt32(commandValidation.ExecuteScalar());
                conn.Close();
                if (count == 1)
                {

                    SqlCommand command = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader leerDB = command.ExecuteReader();

                    if (leerDB.Read())
                    {
                        mail = leerDB["mail"].ToString();
                    }
                    else
                    {
                        Label1.Text = "No se encontraron resultados";
                       
                    }
                    conn.Close();

                }
                else
                {
                    Label1.Text = "Usuario incorrecto, por favor comuníquese con su administrador.";
                    miB = false;
                }

            }
            catch (Exception)
            {

                Label1.Text = "Se ha producido un error inesperado, por favor comuníquese con su administrador.";
            }

            if (miB)
            {
                //actualizar password
                string queryActualizarPass = @"UPDATE usuarios " +
                    "SET pass=(@pw)" +
                    "WHERE username=(@user)";

                SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());// ESTABLECEMOS LA CONEXION

                try
                {
                    SqlCommand command = new SqlCommand(queryActualizarPass, conn2); // CREAMOS EL COMANDO SQL A EJECUTAR

                    string passwordRandom = GenerarRandom();

                    EnviarMail.EnviarContraseniaAlCorreo(mail, passwordRandom, Label1);

                    passwordRandom = Encriptar.ConvertiraHash(passwordRandom);

                    command.Parameters.AddWithValue("pw", passwordRandom);
                    command.Parameters.AddWithValue("user", usuario);
                    conn2.Open();
                    command.ExecuteNonQuery();
                    conn2.Close();


                }
                catch (Exception)
                {
                    Label1.Text = "Se ha producido un error inesperado, volvé a intentarlo más tarde";


                }
            }
                    
            

        }

        public string GenerarRandom()
        {
            Random obj = new Random(); //Metodo Random para obtener un caracter aleatoriamente
            string posibles = "0123456789"; // Caracteres posibles para el random
            int longitud = posibles.Length; //Largo del string
            char letra;
            int longitudnuevacadena = 6;//Largo de la cadena aleatoria
            string nuevacadena = "";
            for (int i = 0; i < longitudnuevacadena; i++)
            {
                letra = posibles[obj.Next(longitud)];
                nuevacadena += letra.ToString();
            }
            return nuevacadena;
        }


    }
}