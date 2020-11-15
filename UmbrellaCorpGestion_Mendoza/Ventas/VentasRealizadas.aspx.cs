using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UmbrellaCorpGestion_Mendoza.ClasesCustom;

namespace UmbrellaCorpGestion_Mendoza.Ventas
{
    public partial class ventasRealizadas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string query = "SELECT ventasDetalle.id_producto AS ID, producto.nombre AS Producto, ventasDetalle.cantidad AS Cantidad, ventasDetalle.pu AS Precio_Unitario, " +
                "(ventasDetalle.cantidad * ventasDetalle.pu) AS SubTotal, ventasCabecera.estado AS Estado, ventasCabecera.id_cabecera AS id_Cabecera, ventasCabecera.tituloVenta AS Titulo " +
                "FROM ventasDetalle " +
                "INNER JOIN producto " +
                "ON ventasDetalle.id_producto = producto.id " +
                "INNER JOIN ventasCabecera " +
                "ON ventasDetalle.id_cabecera=ventasCabecera.id_cabecera " +
                "WHERE ventasCabecera.estado='Vendido'";
            try
            {
                SQL.Establecer_Consulta_GridView(query, GridView1, Label1);
            }
            catch (Exception)
            {

                Label1.ForeColor = Color.Red;
                Label1.Text = "Se ha producido un error contáctese con el administrador";
            }

        }
    }
}