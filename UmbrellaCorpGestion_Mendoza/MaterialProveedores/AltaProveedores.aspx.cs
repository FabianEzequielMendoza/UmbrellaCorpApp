using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UmbrellaCorpGestion_Mendoza.MaterialProveedores
{
    public partial class AltaProveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            string query1 = @"INSERT INTO Proveedores (razonsocial,CUIT,certificado,activo)
                            VALUES (@TB1,@TB2,@TB3,@TB4)";
            string queryValidar = @"SELECT * FROM Proveedores WHERE razonsocial LIKE @TB1";
            byte chkCertValue=0;

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());// ESTABLECEMOS LA CONEXION

            if (chkCertificado.Checked)
            {
                chkCertValue = 1;
            }

            try
            {
                SqlCommand commandValidation = new SqlCommand(queryValidar, conn); // CREAMOS EL COMANDO SQL A EJECUTAR
                commandValidation.Parameters.AddWithValue("TB1", TBRazonSocial.Text);
                conn.Open();
                SqlDataReader leerbd = commandValidation.ExecuteReader();

                if (leerbd.Read() == true)
                {
                    Label1.ForeColor = Color.Red;
                    Label1.Text = "Usuario existente";
                    conn.Close();
                }
                else
                {
                    try
                    {
                        conn.Close();
                        SqlCommand command = new SqlCommand(query1, conn); // CREAMOS EL COMANDO SQL A EJECUTAR
                        command.Parameters.AddWithValue("TB1", TBRazonSocial.Text);
                        command.Parameters.AddWithValue("TB2", TBCuit.Text);
                        command.Parameters.AddWithValue("TB3", chkCertValue);
                        command.Parameters.AddWithValue("TB4", 1);
                        conn.Open();//ABRIMOS LA CONEXION
                        command.ExecuteNonQuery(); // EJECUTAMOS EL COMANDO DEFINITIVO
                        conn.Close(); // CERRAMOS LA CONEXION
                        Label1.ForeColor = Color.Green;
                        Label1.Text = "Se agregaron los registros correctamente.";
                    }
                    catch (Exception)
                    {
                        Label1.ForeColor = Color.Red;
                        Label1.Text = "Se ha producido un error inesperado, volvé a intentarlo más tarde";
                    }

                }
            }
            catch (Exception)
            {
                Label1.ForeColor = Color.Red;
                Label1.Text = "Se ha producido un error inesperado, volvé a intentarlo más tarde";

            }
        }

        protected void BtnCancerlar_Click(object sender, EventArgs e)
        {

        }
    }
}