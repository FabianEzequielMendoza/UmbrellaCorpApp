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

namespace UmbrellaCorpGestion_Mendoza.Productos
{
    public partial class ConsultaModificacionProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void Visibilidad_de_botones_on()
        {
            BtnInactivar.Visible = true;
            BtnEditarProducto.Visible = true;
            BtnModificarCantidad.Visible = true;
            BtnModificarPrecio.Visible = true;
        }
        public void Visibilidad_de_botones_off()
        {
            BtnInactivar.Visible = false;
            BtnEditarProducto.Visible = false;
            BtnModificarCantidad.Visible = false;
            BtnModificarPrecio.Visible = false;

        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = TBNombreABuscar.Text;
            string filtroDDL = "nombre";

            try
            {
                string query = "SELECT Id AS ID, nombre AS Nombre_Materia, pu AS Precio, cantidad AS Cantidad " +
               "FROM producto " +
               "WHERE " + filtroDDL + " LIKE '%" + busqueda + "%' AND activo='True'";

                SQL.Establecer_Consulta_GridView(query, GridView1, Label1);
            }
            catch (Exception ex)
            {
                Label1.ForeColor = Color.Red;
                Label1.Text = "Se ha producido un error inesperado, comuníquese con su administrador";

            }

            Visibilidad_de_botones_off();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Visibilidad_de_botones_on();
            TBNombrePActual1.Text = GridView1.SelectedDataKey.Values["Nombre_Materia"].ToString();
            TBNombrePActual2.Text = TBNombrePActual1.Text;
            TBNombrePActual3.Text = TBNombrePActual1.Text;
            TBPrecioActual.Text = GridView1.SelectedDataKey.Values["Precio"].ToString();
            TBCantidadActual.Text = GridView1.SelectedDataKey.Values["Cantidad"].ToString();
        }

        protected void BtnInactivar_Click(object sender, EventArgs e)
        {
            string query1 = @"UPDATE producto " +
               "SET activo ='False'" +
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
                Label1.Text = "Se ha inactivado a la materia exitosamente";
            }
            catch (Exception ex)
            {
                Label1.ForeColor = Color.Red;
                Label1.Text = "Se ha producido un error inesperado, volvé a intentarlo más tarde";

            }

            Visibilidad_de_botones_off();
        }

        protected void confirmarEdicion_Click(object sender, EventArgs e)
        {
            string query1 = @"UPDATE Producto " +
            "SET nombre =@nombre, descripcion=@descrip " +
            "WHERE id=@Id";


            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());// ESTABLECEMOS LA CONEXION

            try
            {
                SqlCommand command = new SqlCommand(query1, conn); // CREAMOS EL COMANDO SQL A EJECUTAR
                command.Parameters.AddWithValue("Id", GridView1.SelectedDataKey.Values["ID"].ToString());
                command.Parameters.AddWithValue("nombre", TBNombrePNuevo.Text);
                command.Parameters.AddWithValue("descrip", TBDescNueva.Text);

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
                Label1.ForeColor = Color.Green;
                Label1.Text = "Se ha realizado la edición exitosamente";
            }
            catch (Exception ex)
            {
                Label1.ForeColor = Color.Red;
                Label1.Text = "Se ha producido un error inesperado, volvé a intentarlo más tarde";

            }

            Visibilidad_de_botones_off();
        }

        protected void confirmarModificarPrecio_Click(object sender, EventArgs e)
        {
            string query1 = @"UPDATE producto " +
                "SET pu=@precio " +
                "WHERE id=@Id";


            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());// ESTABLECEMOS LA CONEXION

            try
            {
                SqlCommand command = new SqlCommand(query1, conn); // CREAMOS EL COMANDO SQL A EJECUTAR
                command.Parameters.AddWithValue("Id", GridView1.SelectedDataKey.Values["ID"].ToString());
                command.Parameters.AddWithValue("precio", TBPrecioNuevo.Text);

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
                Label1.ForeColor = Color.Green;
                Label1.Text = "Se ha modificar el precio exitosamente";
            }
            catch (Exception ex)
            {
                Label1.ForeColor = Color.Red;
                Label1.Text = "Se ha producido un error inesperado, volvé a intentarlo más tarde";

            }

            Visibilidad_de_botones_off();

        }

        protected void confirmarModificarCantidad_Click(object sender, EventArgs e)
        {
            string query1 = @"UPDATE producto " +
            "SET cantidad=@cantidad " +
            "WHERE id=@Id";


            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());// ESTABLECEMOS LA CONEXION

            try
            {
                SqlCommand command = new SqlCommand(query1, conn); // CREAMOS EL COMANDO SQL A EJECUTAR
                command.Parameters.AddWithValue("Id", GridView1.SelectedDataKey.Values["ID"].ToString());
                command.Parameters.AddWithValue("cantidad", TBCantidadNueva.Text);

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
                Label1.ForeColor = Color.Green;
                Label1.Text = "Se ha modificado la cantidad exitosamente";
            }
            catch (Exception ex)
            {
                Label1.ForeColor = Color.Red;
                Label1.Text = "Se ha producido un error inesperado, volvé a intentarlo más tarde";

            }

            Visibilidad_de_botones_off();
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Productos/ProductoInactivo.aspx");
        }
    }
}