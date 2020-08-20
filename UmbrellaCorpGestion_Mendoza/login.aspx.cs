using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using UmbrellaCorpGestion_Mendoza.ClasesCustom;

namespace UmbrellaCorpGestion_Mendoza
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnEntrar_Click(object sender, EventArgs e)
        {
            if (TBUsuario.Text== "Admin" && TBPass.Text=="admin")
            {
                FormsAuthentication.RedirectFromLoginPage(TBUsuario.Text, true);//Crea una cookie duradera
                Response.Redirect("index.aspx");
            }
            
            String sqlValidacion = "SELECT COUNT (*) FROM Usuarios WHERE (username=@username AND pass=@pass AND activo= '1')";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
                {
                    conn.Open();

                    SqlCommand cmdValidacion = new SqlCommand(sqlValidacion, conn);

                    cmdValidacion.Parameters.AddWithValue("@username", TBUsuario.Text);

                    string hash = Encriptar.ConvertiraHash(TBPass.Text);

                    cmdValidacion.Parameters.AddWithValue("@pass", hash);

                    int countDevolucion = Convert.ToInt32(cmdValidacion.ExecuteScalar());

                    if (countDevolucion == 0)
                    {
                        Label1.Text = "Usuario o contraseña incorrecta";
                    }
                    else
                    {
                        FormsAuthentication.RedirectFromLoginPage(TBUsuario.Text, true);//Crea una cookie duradera
                        Response.Redirect("index.aspx");
                    }
                    conn.Close();

                }
            }
            catch (Exception)
            {
                Label1.Text = "Se produjo un error inesperado.";
            }
        }
    }
}