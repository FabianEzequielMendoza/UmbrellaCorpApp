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

namespace UmbrellaCorpGestion_Mendoza.Ventas
{
    public partial class VentasEnProceso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            mostrarGrid();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            mostrarGrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string idDetalle = GridView1.DataKeys[e.RowIndex].Values["id_detalle"].ToString();
            string idCabecera= GridView1.DataKeys[e.RowIndex].Values["id_cabecera"].ToString();

            string queryUpdateVD = "UPDATE ventasDetalle SET cantidad=@cant WHERE id_detalle=@idDetalle ";
            string queryUpdateVC = "UPDATE ventasCabecera SET tituloVenta=@titulo, descripcion=@descrip,estado=@estado WHERE id_cabecera=@idcabecera ";

            TextBox txtCantidad = GridView1.Rows[e.RowIndex].Cells[3].Controls[0] as TextBox;
            TextBox txtTituloVenta = GridView1.Rows[e.RowIndex].Cells[8].Controls[0] as TextBox;
            TextBox txtDescripcion= GridView1.Rows[e.RowIndex].Cells[9].Controls[0] as TextBox;
            TextBox txtEstado = GridView1.Rows[e.RowIndex].Cells[6].Controls[0] as TextBox;

            string cant = txtCantidad.Text;
            string tituloVenta = txtTituloVenta.Text;
            string descripcion = txtDescripcion.Text;
            string estado = txtEstado.Text;

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand(queryUpdateVD, conn);
                    command.Parameters.AddWithValue("cant",Convert.ToInt32(cant));
                    command.Parameters.AddWithValue("idDetalle", Convert.ToInt32(idDetalle));

                    command.ExecuteNonQuery();

                    conn.Close();

                    conn.Open();

                    SqlCommand command2 = new SqlCommand(queryUpdateVC, conn);
                    command2.Parameters.AddWithValue("titulo", tituloVenta);
                    command2.Parameters.AddWithValue("descrip", descripcion);
                    command2.Parameters.AddWithValue("estado", estado);
                    command2.Parameters.AddWithValue("idCabecera", Convert.ToInt32(idCabecera));

                    command2.ExecuteNonQuery();

                    conn.Close();



                    Label1.ForeColor = Color.Red;
                    Label1.Text = "se produjo ha actualizado correctamente";
                }
                catch (Exception ex)
                {
                    Label1.ForeColor = Color.Red;
                    Label1.Text = "se produjo un error inesperado";
                }
            }

                mostrarGrid();
            GridView1.EditIndex = -1;
        }

        public void mostrarGrid() {
            string query = "SELECT ventasDetalle.id_detalle, ventasDetalle.id_producto, producto.nombre AS Producto, ventasDetalle.cantidad AS Cantidad, ventasDetalle.pu AS Precio_Unitario, " +
               "(ventasDetalle.cantidad * ventasDetalle.pu) AS SubTotal, ventasCabecera.estado AS Estado, ventasCabecera.id_cabecera, ventasCabecera.tituloVenta AS Titulo,ventasCabecera.descripcion " +
               "FROM ventasDetalle " +
               "INNER JOIN producto " +
               "ON ventasDetalle.id_producto = producto.id " +
               "INNER JOIN ventasCabecera " +
               "ON ventasDetalle.id_cabecera=ventasCabecera.id_cabecera " +
               "WHERE ventasCabecera.estado='En proceso'";
            try
            {
                SQL.Establecer_Consulta_GridView(query, GridView1, Label1);
            }
            catch (Exception ex)
            {

                Label1.ForeColor = Color.Red;
                Label1.Text = "Se ha producido un error contáctese con el administrador";
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            mostrarGrid();
            GridView1.EditIndex = -1;
        }
    }
}