using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using UmbrellaCorpGestion_Mendoza.ClasesCustom;

namespace UmbrellaCorpGestion_Mendoza.Usuarios
{
    public partial class consultas_usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        
        }

        public void Visibilidad_de_botones_on() {
            BtnDesvincular.Visible = true;
            BtnModificarMail.Visible = true;
            BtnRestablecerCont.Visible = true;
        }
        public void Visibilidad_de_botones_off()
        {
            BtnDesvincular.Visible = false;
            BtnModificarMail.Visible = false;
            BtnRestablecerCont.Visible = false;
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = TextBox1.Text;
            string query="";
            string filtroDDL;
            bool miB = true;
            string activo="";

            if (DropDownList1.Text == "Id")
            {
                filtroDDL = "id";
            }
            else
            {
                filtroDDL = "username";
            }

            if (CheckBox1.Checked == true && CheckBox2.Checked == false)
            {
                activo = "AND activo=1";
            }
            else if (CheckBox1.Checked == false && CheckBox2.Checked == true)
            {
                activo = "AND activo=0";
            }
            else if (CheckBox1.Checked == true && CheckBox2.Checked == true)
            {
                activo = "AND activo in(1,0)";
            }
            else
            {
                miB = false;
            }

            if (miB)
            {
                query = "SELECT username AS Nombre_de_Usuario,mail As Email, fechaIngreso AS Fecha_de_Ingreso, fechaDesvinculacion AS Fecha_de_Desvinc, motivoDesv AS Motivo_de_Desvinc " +
                "FROM usuarios " +
                "WHERE " + filtroDDL + " LIKE '%" + busqueda + "%' "+activo;
                SQL.Establecer_Consulta_GridView(query, GridView1, Label1);
            }
            else
            {
                Label1.ForeColor = Color.Red;
                Label1.Text = "Debe elegir una opción en usuario activo o no activo";
            }

            Visibilidad_de_botones_off();
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Visibilidad_de_botones_on();


        }

        protected void ConfirmarDesvinculacion_Click(object sender, EventArgs e)
        {
  
            string query1 = @"UPDATE usuarios " +
                "SET fechaDesvinculacion=(@fd), motivoDesv=(@md), activo =0" +
                "WHERE username=(@user)";
            string user= GridView1.SelectedRow.Cells[1].Text; 

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());// ESTABLECEMOS LA CONEXION

          
            try
            {
                SqlCommand command = new SqlCommand(query1, conn); // CREAMOS EL COMANDO SQL A EJECUTAR
                command.Parameters.AddWithValue("fd", DateTime.Now);
                command.Parameters.AddWithValue("md", motivoDesv.Text);
                command.Parameters.AddWithValue("user", user);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
                Label1.ForeColor = Color.Green;
                Label1.Text = "Se ha desvinculado al usuario "+user+" exitosamente";
            }
            catch (Exception)
            {
                Label1.ForeColor = Color.Red;
                Label1.Text = "Se ha producido un error inesperado, volvé a intentarlo más tarde";

            }
           

        }
    

        protected void ConfirmarContrasenia_Click(object sender, EventArgs e) 
        {
            //consultar username y mail del usuario
            string username = GridView1.SelectedRow.Cells[1].Text;
            string mail= GridView1.SelectedRow.Cells[2].Text;

            //actualizar password
            string query = @"UPDATE usuarios " +
                "SET pass=(@pw)" +
                "WHERE username=(@user)";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());// ESTABLECEMOS LA CONEXION

            try
            {
                SqlCommand command = new SqlCommand(query, conn); // CREAMOS EL COMANDO SQL A EJECUTAR
                
                string passwordRandom = GenerarRandom();

                EnviarMail.EnviarContraseniaAlCorreo(mail,passwordRandom,Label1);

                passwordRandom = Encriptar.ConvertiraHash(passwordRandom);

                command.Parameters.AddWithValue("pw", passwordRandom);
                command.Parameters.AddWithValue("user", username);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();

                Label1.ForeColor = Color.Green;
                Label1.Text = "Se ha cambiado la contraseña exitosamente";
            }
            catch (Exception)
            {
                Label1.ForeColor = Color.Red;
                Label1.Text = "Se ha producido un error inesperado, volvé a intentarlo más tarde";

            }

           
        }

        protected void ConfirmarMail_Click(object sender, EventArgs e)
        {
            //username del usuario
            string username = GridView1.SelectedRow.Cells[1].Text;

            //actualizar mail
            string query = @"UPDATE usuarios " +
                "SET mail=(@mail)" +
                "WHERE username=(@user)";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());// ESTABLECEMOS LA CONEXION

            try
            {
                SqlCommand command = new SqlCommand(query, conn); // CREAMOS EL COMANDO SQL A EJECUTAR

                command.Parameters.AddWithValue("mail", setMail.Text);
                command.Parameters.AddWithValue("user", username);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();

                Label1.ForeColor = Color.Green;
                Label1.Text = "Se ha cambiado el mail exitosamente";
            }
            catch (Exception)
            {
                Label1.Text = "Se ha producido un error inesperado, volvé a intentarlo más tarde";

            }

        }

        protected void cancelarDesvinculacion_Click(object sender, EventArgs e)
        {
            Visibilidad_de_botones_off();
        }

        protected void cancelarContrasenia_Click(object sender, EventArgs e)
        {
            Visibilidad_de_botones_off();
        }

        protected void cancelarMail_Click(object sender, EventArgs e)
        {
            Visibilidad_de_botones_off();
        }
        private string GenerarRandom()
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