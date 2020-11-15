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
    public partial class ConsultaModificacionProveedroes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void Visibilidad_de_botones_on()
        {
            BtnInactivar.Visible = true;
            BtnEditarProveedor.Visible = true;
        }
        public void Visibilidad_de_botones_off()
        {
            BtnInactivar.Visible = false;
            BtnEditarProveedor.Visible = false;

        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = TextBox1.Text;
            string query = "";
            string filtroDDL;
            bool miB = true;
            string certificado = "";

            if (DropDownList1.Text == "Razon Social")
            {
                filtroDDL = "razonSocial";
            }
            else
            {
                filtroDDL = "CUIT";
            }

            if (CheckBox1.Checked == true && CheckBox2.Checked == false)
            {
                certificado = "AND certificado='True'";
            }
            else if (CheckBox1.Checked == false && CheckBox2.Checked == true)
            {
                certificado = "AND certificado='False'";
            }
            else if (CheckBox1.Checked == true && CheckBox2.Checked == true)
            {
                certificado = "AND certificado in('True','False')";
            }
            else
            {
                miB = false;
            }

            if (miB)
            {
                query = "SELECT id AS ID, razonSocial AS Razon_Social, CUIT AS Cuit, certificado AS Certificado, activo AS Activo " +
                "FROM Proveedores " +
                "WHERE " + filtroDDL + " LIKE '%" + busqueda + "%' "+certificado+" AND activo='True'";
                SQL.Establecer_Consulta_GridView(query, GridView1, Label1);

            }
            else
            {
                Label1.ForeColor = Color.Red;
                Label1.Text = "Debe elegir una opción entre certificados y no certificados";
            }
            Visibilidad_de_botones_off();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Visibilidad_de_botones_on();
            TBRazonSocial.Text = GridView1.SelectedDataKey.Values["Razon_Social"].ToString(); 
        }

        protected void BtnInactivar_Click(object sender, EventArgs e)
        {
            string query1 = @"UPDATE Proveedores " +
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
                Label1.Text = "Se ha inactivado al proveedor exitosamente";
            }
            catch (Exception)
            {
                Label1.ForeColor = Color.Red;
                Label1.Text = "Se ha producido un error inesperado, volvé a intentarlo más tarde";

            }

            Visibilidad_de_botones_off();
        }

        protected void confirmarEdicion_Click(object sender, EventArgs e)
        {
            string query = @"UPDATE Proveedores " +
                "SET CUIT=(@CUIT), certificado=(@cert)" +
                "WHERE id=(@Id)";
            bool chkCertificado = true;

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());// ESTABLECEMOS LA CONEXION
            if (RadioButton1.Checked)
            {
                chkCertificado = true;
            }
            else if (RadioButton2.Checked)
            {
                chkCertificado = false;
            }
            try
            {
                SqlCommand command = new SqlCommand(query, conn); // CREAMOS EL COMANDO SQL A EJECUTAR

                command.Parameters.AddWithValue("CUIT", TBCuit.Text);
                command.Parameters.AddWithValue("cert", chkCertificado.ToString());
                command.Parameters.AddWithValue("Id", GridView1.SelectedDataKey.Values["ID"].ToString());
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
                Label1.ForeColor = Color.Green;
                Label1.Text = "Se ha editado al proveedor exitosamente";
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Label1.Text = "Se ha producido un error inesperado, volvé a intentarlo más tarde";

            }
            Visibilidad_de_botones_off();
        }

        protected void cancelarEdicion_Click(object sender, EventArgs e)
        {
            Visibilidad_de_botones_off();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/MaterialProveedores/ProveedoresInactivos.aspx");
        }
    }
}