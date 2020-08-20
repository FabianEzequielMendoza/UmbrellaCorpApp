using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UmbrellaCorpGestion_Mendoza.ClasesCustom;

namespace UmbrellaCorpGestion_Mendoza.Usuarios
{
    public partial class consultas_usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = TextBox1.Text;
            string query = "SELECT username AS Nombre_de_Usuario,mail As Email, fechaIngreso AS Fecha_de_Ingreso, fechaDesvinculacion AS Fecha_de_Desvinc,motivoDesv AS Motivo_de_Desv " +
                "FROM usuarios " +
                "WHERE username LIKE'%" + busqueda + "%'";

            SQL.Establecer_Consulta_GridView(query, GridView1, Label1);
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}