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
    public partial class AltaMateriaPrima : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnGenerar_Click(object sender, EventArgs e)
        {
            string query = @"INSERT INTO MateriaPrima (nombre,descripcion,proveedor,pu,moneda,cantidad,activo)
                            VALUES (@nombre,@descrip,@prov,@pu,@moneda,@cant,@activo)";
            string queryValidar = @"SELECT UPPER(nombre) FROM MateriaPrima WHERE nombre LIKE UPPER(@nombre)";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());// ESTABLECEMOS LA CONEXION

            try
            {
                SqlCommand commandValidation = new SqlCommand(queryValidar, conn); // CREAMOS EL COMANDO SQL A EJECUTAR
                commandValidation.Parameters.AddWithValue("nombre", TBNombreMP.Text);
                conn.Open();
                SqlDataReader leerbd = commandValidation.ExecuteReader();

                if (leerbd.Read() == true)
                {
                    Label1.ForeColor = Color.Red;
                    Label1.Text = "Usuario existente, elige otro nombre";
                    conn.Close();
                }
                else
                {
                    try
                    {
                        conn.Close();
                        SqlCommand command = new SqlCommand(query, conn); // CREAMOS EL COMANDO SQL A EJECUTAR
                        command.Parameters.AddWithValue("nombre", TBNombreMP.Text);
                        command.Parameters.AddWithValue("descrip", TBDescripcion.Text);
                        command.Parameters.AddWithValue("prov", DropDownList1.SelectedValue);
                        command.Parameters.AddWithValue("pu", TBPrecio.Text);
                        command.Parameters.AddWithValue("moneda", DropDownList2.SelectedValue);
                        command.Parameters.AddWithValue("cant", TBCantidad.Text);
                        command.Parameters.AddWithValue("activo", "True");
                        conn.Open();//ABRIMOS LA CONEXION
                        command.ExecuteNonQuery(); // EJECUTAMOS EL COMANDO DEFINITIVO
                        conn.Close(); // CERRAMOS LA CONEXION
                        Label1.ForeColor = Color.Green;
                        Label1.Text = "Se agregaron los registros correctamente.";
                    }
                    catch (Exception ex)
                    {
                        Label1.ForeColor = Color.Red;
                        Label1.Text = "Se ha producido un error inesperado, volvé a intentarlo más tarde";
                    }

                }
            }
            catch (Exception ex)
            {
                Label1.ForeColor = Color.Red;
                Label1.Text = "Se ha producido un error inesperado, volvé a intentarlo más tarde";

            }
        }
    }
    
}