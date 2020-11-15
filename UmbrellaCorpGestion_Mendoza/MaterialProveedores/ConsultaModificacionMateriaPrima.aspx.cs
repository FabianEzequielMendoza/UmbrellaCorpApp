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

namespace UmbrellaCorpGestion_Mendoza.MaterialProveedores
{
    public partial class ConsultaModificacionMateriaPrima : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void Visibilidad_de_botones_on()
        {
            BtnInactivar.Visible = true;
            BtnEditarMateria.Visible = true;
            BtnModificarCantidad.Visible = true;
            BtnModificarPrecio.Visible = true;
        }
        public void Visibilidad_de_botones_off()
        {
            BtnInactivar.Visible = false;
            BtnEditarMateria.Visible = false;
            BtnModificarCantidad.Visible = false;
            BtnModificarPrecio.Visible = false;

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Visibilidad_de_botones_on();
            TBNombreMPActual1.Text = GridView1.SelectedDataKey.Values["Nombre_Materia"].ToString();
            TBNombreMPActual2.Text = TBNombreMPActual1.Text;
            TBNombreMPActual3.Text = TBNombreMPActual1.Text;
            TBPrecioActual.Text = GridView1.SelectedDataKey.Values["Precio"].ToString();
            TBCantidadActual.Text = GridView1.SelectedDataKey.Values["Cantidad"].ToString();
        }

        protected void BtnInactivar_Click(object sender, EventArgs e)
        {
            string query1 = @"UPDATE MateriaPrima " +
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

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = TBNombreABuscar.Text;
            string filtroDDL = "nombre";

            try
            {
                string query = "SELECT Id AS ID, nombre AS Nombre_Materia, pu AS Precio, cantidad AS Cantidad, proveedor AS Proveedor " +
               "FROM MateriaPrima " +
               "WHERE " + filtroDDL + " LIKE '%" + busqueda +"%' AND activo='True'";

                SQL.Establecer_Consulta_GridView(query,GridView1,Label1);
            }
            catch (Exception ex)
            {
                Label1.ForeColor = Color.Red;
                Label1.Text = "Se ha producido un error inesperado, comuníquese con su administrador";

            }
  
            Visibilidad_de_botones_off();
        }
        protected void confirmarEdicion_Click(object sender, EventArgs e)
        {
            
            string query1 = @"UPDATE MateriaPrima " +
            "SET nombre =@nombre, descripcion=@descrip, proveedor=@proveedor " +
            "WHERE id=@Id";


            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());// ESTABLECEMOS LA CONEXION

            try
            {
                SqlCommand command = new SqlCommand(query1, conn); // CREAMOS EL COMANDO SQL A EJECUTAR
                command.Parameters.AddWithValue("Id", GridView1.SelectedDataKey.Values["ID"].ToString());
                command.Parameters.AddWithValue("nombre", TBNombreMPNuevo.Text);
                command.Parameters.AddWithValue("descrip", TBDescNueva.Text);
                command.Parameters.AddWithValue("proveedor", TBProveedorNuevo.Text);

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

        protected void confirmarPrecio_Click(object sender, EventArgs e)
        {
            string query1 = @"UPDATE MateriaPrima " +
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

        protected void confirmarCantidad_Click(object sender, EventArgs e)
        {
            string query1 = @"UPDATE MateriaPrima " +
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
            Response.Redirect("/MaterialProveedores/MateriaPrimaInactiva.aspx");
        }
    }
}