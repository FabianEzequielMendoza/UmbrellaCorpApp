using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UmbrellaCorpGestion_Mendoza.Productos
{
    public partial class AltaProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            camposDeBase.Visible = false;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.Items[0].Text.Equals("Seleccionar"))
            {
                DropDownList1.Items.RemoveAt(0);
            }

            camposDeBase.Visible = true;
            
            string query = @"SELECT * FROM MateriaPrima WHERE nombre=@nombre";

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {
                try
                {
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("nombre", DropDownList1.SelectedValue);
                    conn.Open();
                    SqlDataReader leerDB = command.ExecuteReader();

                    if (leerDB.Read())
                    {
                        TBID.Text= leerDB["id"].ToString();
                        TBPU.Text = leerDB["pu"].ToString();
                        TBCantidadMat.Text = leerDB["cantidad"].ToString();
                        TBProveedor.Text = leerDB["proveedor"].ToString();
                        leerDB.Close();
                    }
                    else
                    {
                        leerDB.Close();
                        TBPU.Text = "Sin datos";
                        TBCantidadMat.Text = "Sin datos";
                        TBProveedor.Text = "Sin datos";
                    }
                    conn.Close();

                }
                catch (Exception ex)
                {
                    Label1.ForeColor = Color.Red;
                    Label1.Text = "Se ha producido un error inesperado, volvé a intentarlo más tarde";
                }
            }
        }

        protected void BtnGenerar_Click(object sender, EventArgs e)
        {

            if (DropDownList1.Items[0].Text.Equals("Seleccionar"))
            {
                Label1.Text = "Debe seleccionar una materia prima";
            }
            else
            {
                camposDeBase.Visible = true;

                string queryInsertar = @"INSERT INTO Producto (nombre,descripcion,cantidad,pu,activo)
                            VALUES (@nombre,@desc,@cantidad,@pu,@activo)";
                string queryValidar = @"SELECT UPPER(nombre) FROM Producto WHERE nombre LIKE UPPER(@nombre)";
                string queryModificar = @"UPDATE MateriaPrima " +
               "SET cantidad =@cantidad " +
               "WHERE id=@Id";

                int cantidadAModificar = Convert.ToInt32(TBCantidadMat.Text) - Convert.ToInt32(TBCantidadSol.Text);

                if (cantidadAModificar>=0)
                {
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());// ESTABLECEMOS LA CONEXION

                    try
                    {
                        SqlCommand commandValidation = new SqlCommand(queryValidar, conn); // CREAMOS EL COMANDO SQL A EJECUTAR
                        commandValidation.Parameters.AddWithValue("nombre", TBNombreP.Text);
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

                                SqlCommand commandModificar = new SqlCommand(queryModificar, conn);
                                commandModificar.Parameters.AddWithValue("cantidad", cantidadAModificar.ToString());
                                commandModificar.Parameters.AddWithValue("Id", TBID.Text);

                                SqlCommand command = new SqlCommand(queryInsertar, conn); // CREAMOS EL COMANDO SQL A EJECUTAR
                                command.Parameters.AddWithValue("nombre", TBNombreP.Text);
                                command.Parameters.AddWithValue("desc", TBDescripcion.Text);
                                command.Parameters.AddWithValue("cantidad", TBCantidadProducto.Text);
                                command.Parameters.AddWithValue("pu", TBPUProducto.Text);
                                command.Parameters.AddWithValue("activo","True");

                                conn.Open();//ABRIMOS LA CONEXION
                                commandModificar.ExecuteNonQuery();
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
                else
                {
                    Label1.ForeColor = Color.Red;
                    Label1.Text = "La cantidad a solicitar es mayor que la cantidad disponible";
                }
                
            }

        }
    }
}