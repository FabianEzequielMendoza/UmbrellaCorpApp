using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Web.UI.WebControls;
using UmbrellaCorpGestion_Mendoza.ClasesCustom;

namespace UmbrellaCorpGestion_Mendoza.Ventas
{
    public partial class VentaProducto : System.Web.UI.Page
    {
        private string estado;
        private string venta="";
        public string ObtenerIdUsuario()
        {

            string query = @"SELECT id FROM Usuarios WHERE username=@username";
            string idUsuario = "";

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {
                try
                {
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("username", Thread.CurrentPrincipal.Identity.Name);
                    conn.Open();
                    SqlDataReader leerDB = command.ExecuteReader();

                    if (leerDB.Read())
                    {
                        idUsuario = leerDB["id"].ToString();
                        leerDB.Close();
                    }
                    else
                    {
                        leerDB.Close();
                    }
                    conn.Close();

                }
                catch (Exception ex)
                {
                    Label1.ForeColor = Color.Red;
                    Label1.Text = "Se ha producido un error inesperado, volvé a intentarlo más tarde";
                }
            }
            return idUsuario;
        }
        public void EstablecerTotal(string idCabecera)
        {

            string query = "SELECT SUM(cantidad*pu) AS Total " +
               "FROM ventasDetalle " +
               "WHERE id_cabecera in('" + idCabecera + "') ";

            string total = "";

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {
                try
                {
                    SqlCommand command = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader leerDB = command.ExecuteReader();

                    if (leerDB.Read())
                    {
                        total = leerDB["Total"].ToString();
                        leerDB.Close();
                    }
                    else
                    {
                        leerDB.Close();
                    }
                    conn.Close();

                }
                catch (Exception ex)
                {
                    Label1.ForeColor = Color.Red;
                    Label1.Text = "Se ha producido un error inesperado, volvé a intentarlo más tarde";
                }
            }
            lblTotal.Text = total;
        }
        public string ObtenerIdCliente()
        {
            string query = @"SELECT id FROM Cliente WHERE nombre=@nombre";
            string idCliente = "";

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {
                try
                {
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("nombre", ddlCliente.SelectedValue);
                    conn.Open();
                    SqlDataReader leerDB = command.ExecuteReader();

                    if (leerDB.Read())
                    {
                        idCliente = leerDB["id"].ToString();
                        leerDB.Close();
                    }
                    else
                    {
                        leerDB.Close();
                    }
                    conn.Close();

                }
                catch (Exception ex)
                {
                    Label1.ForeColor = Color.Red;
                    Label1.Text = "Se ha producido un error inesperado, volvé a intentarlo más tarde";
                }
            }
            return idCliente;
        }

        public string ObtenerIdVentaCabecera()
        {
            string query = @"SELECT max(id_cabecera) AS id_cabecera FROM VentasCabecera ";
            string idVentaCabecera = "";

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {
                try
                {
                    SqlCommand command = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader leerDB = command.ExecuteReader();

                    if (leerDB.Read())
                    {
                        idVentaCabecera = leerDB["id_cabecera"].ToString();
                        leerDB.Close();
                    }
                    else
                    {
                        leerDB.Close();
                    }
                    conn.Close();

                }
                catch (Exception ex)
                {
                    Label1.ForeColor = Color.Red;
                    Label1.Text = "Se ha producido un error inesperado, volvé a intentarlo más tarde";
                }
            }
            return idVentaCabecera;
        }
        public string ObtenerProductoCantidadDisponible()
        {
            string query = @"SELECT cantidad FROM Producto WHERE nombre=@nombre";
            string cantidad = "";

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {
                try
                {
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("nombre", ddlProducto.SelectedValue);
                    conn.Open();
                    SqlDataReader leerDB = command.ExecuteReader();

                    if (leerDB.Read())
                    {
                        cantidad = leerDB["cantidad"].ToString();
                        leerDB.Close();
                    }
                    else
                    {
                        leerDB.Close();
                    }
                    conn.Close();

                }
                catch (Exception ex)
                {
                    Label1.ForeColor = Color.Red;
                    Label1.Text = "Se ha producido un error inesperado, volvé a intentarlo más tarde";
                }
            }
            return cantidad;
        }
        public string ObtenerIdProducto()
        {
            string query = @"SELECT id FROM Producto WHERE nombre=@nombre";
            string idProducto = "";

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {
                try
                {
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("nombre", ddlProducto.SelectedValue);
                    conn.Open();
                    SqlDataReader leerDB = command.ExecuteReader();

                    if (leerDB.Read())
                    {
                        idProducto = leerDB["id"].ToString();
                        leerDB.Close();
                    }
                    else
                    {
                        leerDB.Close();
                    }
                    conn.Close();

                }
                catch (Exception ex)
                {
                    Label1.ForeColor = Color.Red;
                    Label1.Text = "Se ha producido un error inesperado, volvé a intentarlo más tarde";
                }
            }
            return idProducto;
        }

        public bool validarQueryProducto(string id_cabecera,string id_producto) {
            bool value = true;

            string queryValidar = "SELECT id_producto FROM ventasDetalle WHERE id_producto="+id_producto+" AND id_cabecera="+id_cabecera;

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {
                try
                {
                    SqlCommand commandValidation = new SqlCommand(queryValidar, conn); // CREAMOS EL COMANDO SQL A EJECUTAR
                    conn.Open();
                    SqlDataReader leerbd = commandValidation.ExecuteReader();

                    if (leerbd.Read() == true)
                    {
                        Label1.ForeColor = Color.Red;
                        Label1.Text = "Producto existente, elige otro producto";
                        conn.Close();

                        value = false;
                    }
                }
                catch (Exception ex) {
                    Label1.ForeColor = Color.Red;
                    Label1.Text = "Se ha producido un error inesperado, volvé a intentarlo más tarde";
                }
            }
            return value;
        }


        public string ObtenerPUProducto()
        {
            string query = @"SELECT PU FROM Producto WHERE nombre=@nombre";
            string idProducto = "";

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {
                try
                {
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("nombre", ddlProducto.SelectedValue);
                    conn.Open();
                    SqlDataReader leerDB = command.ExecuteReader();

                    if (leerDB.Read())
                    {
                        idProducto = leerDB["PU"].ToString();
                        leerDB.Close();
                    }
                    else
                    {
                        leerDB.Close();
                    }
                    conn.Close();

                }
                catch (Exception ex)
                {
                    Label1.ForeColor = Color.Red;
                    Label1.Text = "Se ha producido un error inesperado, volvé a intentarlo más tarde";
                }
            }
            return idProducto;
        }
        public void InsertarRegistroVC()
        {
            string queryInsertarVC = @"INSERT INTO VentasCabecera (id_usuario,id_cliente,tituloVenta,estado,fechaVenta,total,descripcion) VALUES (@id_usuario,@id_cliente,@tituloVenta,@estado,@fechaVenta,@total,@descripcion)";

            string IdUsuario = ObtenerIdUsuario();
            string IdCliente = ObtenerIdCliente();


            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {


                SqlCommand commandInsertarVC = new SqlCommand(queryInsertarVC, conn);
                commandInsertarVC.Parameters.AddWithValue("id_usuario", Convert.ToInt32(IdUsuario));
                commandInsertarVC.Parameters.AddWithValue("id_cliente", Convert.ToInt32(IdCliente));
                commandInsertarVC.Parameters.AddWithValue("tituloVenta", TBTituloVenta.Text);
                commandInsertarVC.Parameters.AddWithValue("estado", "En proceso");
                commandInsertarVC.Parameters.AddWithValue("fechaVenta", lblDateTime.Text);
                commandInsertarVC.Parameters.AddWithValue("total",Convert.ToDecimal(0.00));
                commandInsertarVC.Parameters.AddWithValue("descripcion", TBDescripcion.Text);

                conn.Open();//ABRIMOS LA CONEXION
                commandInsertarVC.ExecuteNonQuery();// EJECUTAMOS EL COMANDO DEFINITIVO
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
        public void InsertarRegistroVD()
        {
            

            string idVentaCabecera = ObtenerIdVentaCabecera();
            string idProducto = ObtenerIdProducto();
            string PUProducto = ObtenerPUProducto();
            bool value= validarQueryProducto(idVentaCabecera,idProducto);
            if (value)
            {
                string queryInsertarVD = @"INSERT INTO VentasDetalle (id_cabecera,id_producto,PU,cantidad,descuentos) VALUES (@id_cabecera,@id_producto,@PU,@cantidad,@descuentos)";
                SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                try
                {
                    SqlCommand commandInsertarVD = new SqlCommand(queryInsertarVD, conn2); // CREAMOS EL COMANDO SQL A EJECUTAR
                    commandInsertarVD.Parameters.AddWithValue("id_cabecera", Convert.ToInt32(idVentaCabecera));
                    commandInsertarVD.Parameters.AddWithValue("id_producto", Convert.ToInt32(idProducto));
                    commandInsertarVD.Parameters.AddWithValue("PU", Convert.ToDecimal(PUProducto));
                    commandInsertarVD.Parameters.AddWithValue("cantidad", Convert.ToInt32(TBCantidadProducto.Text));
                    commandInsertarVD.Parameters.AddWithValue("descuentos", Convert.ToDecimal(0.00));
                    conn2.Open();//ABRIMOS LA CONEXION
                    commandInsertarVD.ExecuteNonQuery(); // EJECUTAMOS EL COMANDO DEFINITIVO
                    conn2.Close(); // CERRAMOS LA CONEXION
                    Label1.ForeColor = Color.Green;
                    Label1.Text = "Se agregaron los registros correctamente.";
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
                Label1.Text = "Elija otro producto";
            }

        }
        public void InsertarRegistroProducto()
        {
            string idProducto = ObtenerIdProducto();
            int cantTotal = Convert.ToInt32(TBCantidadDisponible.Text) - Convert.ToInt32(TBCantidadProducto.Text);
            string updateCantidad = @"UPDATE producto SET cantidad=@cantidad WHERE id=@id";

            SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlCommand commandUpdate = new SqlCommand(updateCantidad, conn2); // CREAMOS EL COMANDO SQL A EJECUTAR
                commandUpdate.Parameters.AddWithValue("cantidad",cantTotal);
                commandUpdate.Parameters.AddWithValue("id", idProducto);
                conn2.Open();//ABRIMOS LA CONEXION
                commandUpdate.ExecuteNonQuery(); // EJECUTAMOS EL COMANDO DEFINITIVO
                conn2.Close(); // CERRAMOS LA CONEXION
                Label1.ForeColor = Color.Green;
                Label1.Text = "Se agregaron los registros correctamente.";
            }
            catch (Exception ex)
            {
                Label1.ForeColor = Color.Red;
                Label1.Text = "Se ha producido un error inesperado, volvé a intentarlo más tarde";
            }

        }

        public void MostrarGridView(string query, GridView GridView1, Label Label1)
        {
            try
            {
                SQL.Establecer_Consulta_GridView(query, GridView1, Label1);
            }
            catch (Exception ex)
            {
                Label1.ForeColor = Color.Red;
                Label1.Text = "Se ha producido un error inesperado, comuníquese con su administrador";

            }
        }
        public string CrearEstadoVenta()
        {
            this.estado = "En proceso";

            return estado;
        }

        public void MostrarDetalle()
        {
            string idCabecera = ObtenerIdVentaCabecera();

            string queryDetalle = "SELECT ventasDetalle.id_producto AS ID, producto.nombre AS Producto, ventasDetalle.cantidad AS Cantidad, ventasDetalle.pu AS Precio_Unitario, " +
                "(ventasDetalle.cantidad * ventasDetalle.pu) AS SubTotal " +
                "FROM ventasDetalle " +
                "INNER JOIN producto " +
                "ON ventasDetalle.id_producto = producto.id " +
                "WHERE ventasDetalle.id_cabecera="+idCabecera;

            MostrarGridView(queryDetalle, GridView1, Label1);

            EstablecerTotal(idCabecera);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            lblUsuarioLogueado.Text = Thread.CurrentPrincipal.Identity.Name;
            lblEstado.Text = CrearEstadoVenta();
            BtnCancelar.Visible = false; 

        }

        protected void confirmarEdicion_Click(object sender, EventArgs e)
        {
            string queryInsertar = @"INSERT INTO cliente (nombre,contacto,mail,VIP)
                            VALUES (@nombre,@contacto,@mail,@VIP)";

            string queryValidar = @"SELECT UPPER(nombre) FROM cliente WHERE nombre LIKE UPPER(@nombre)";


            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());// ESTABLECEMOS LA CONEXION

            try
            {
                SqlCommand commandValidation = new SqlCommand(queryValidar, conn); // CREAMOS EL COMANDO SQL A EJECUTAR
                commandValidation.Parameters.AddWithValue("nombre", TBNombreCliente.Text);
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
                        SqlCommand command = new SqlCommand(queryInsertar, conn); // CREAMOS EL COMANDO SQL A EJECUTAR
                        command.Parameters.AddWithValue("nombre", TBNombreCliente.Text);
                        command.Parameters.AddWithValue("contacto", TBContacto.Text);
                        command.Parameters.AddWithValue("mail", TBMail.Text);
                        command.Parameters.AddWithValue("VIP", DropDownList1.SelectedValue);
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

            SqlDataSource3.Update();
        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            BtnCancelar.Visible = true;

            if (ddlProducto.SelectedValue!= "Seleccionar" && ddlCliente.SelectedValue != "Seleccionar")
            {

                InsertarRegistroVD();
                InsertarRegistroProducto();
                GridView1.Visible = true;
                MostrarDetalle();
                
            }
            else
            {
                Label1.ForeColor = Color.Red;
                Label1.Text = "Elija una opción de la lista de clientes y productos";
            }
           

        }

        protected void ddlProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            TBCantidadProducto.Text = "1";

            if (ddlProducto.Items[0].Text.Equals("Seleccionar"))
            {
                ddlProducto.Items.RemoveAt(0);
            }


            TBCantidadDisponible.Text = ObtenerProductoCantidadDisponible();

            RangeValidator1.MinimumValue = "1";
            RangeValidator1.MaximumValue = TBCantidadDisponible.Text;
        }

        protected void ddlCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCliente.Items[0].Text.Equals("Seleccionar"))
            {
                ddlCliente.Items.RemoveAt(0);
            }
        }

        protected void btnCrearVenta_Click(object sender, EventArgs e)
        {
            if (ddlCliente.SelectedValue != "Seleccionar")
            {
                btnAgregarProducto.Enabled = true;
                InsertarRegistroVC();
                btnCrearVenta.Enabled = false;
                ddlCliente.Enabled = false;
            }
            else
            {
                Label1.ForeColor = Color.Red;
                Label1.Text = "Elija una opcion de cliente";
            }

            BtnCancelar.Visible = true;
            
        }

        protected void BtnGuardarVenta_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Ventas/VentaProducto.aspx");
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            string id_cabecera = ObtenerIdVentaCabecera();
            string updateVC = "UPDATE ventasCabecera SET estado='Cancelado' WHERE id_cabecera="+id_cabecera; 

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlCommand command = new SqlCommand(updateVC, conn);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();

                Label1.ForeColor = Color.Green;
                Label1.Text = "Se ha cancelado la venta";

                BtnCancelar.Visible= false;
                btnAgregarProducto.Enabled = false;
                btnCrearVenta.Enabled = true;
                GridView1.Visible = false;

            }
            catch (Exception)
            {
                Label1.ForeColor = Color.Red;
                Label1.Text = "Se ha producido un error inesperado";
            }
            
        }

        protected void BtnCerrarVenta_Click(object sender, EventArgs e)
        {
            string id_cabecera = ObtenerIdVentaCabecera();
            int total = Convert.ToInt32(lblTotal.Text);

            string updateVC = @"UPDATE ventasCabecera SET estado=@estado,total=@total,fechaVenta=@fechaVenta WHERE id_cabecera=" + id_cabecera;

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlCommand command = new SqlCommand(updateVC, conn);
                command.Parameters.AddWithValue("estado","Vendido");
                command.Parameters.AddWithValue("total", total);
                command.Parameters.AddWithValue("fechaVenta", lblDateTime.Text);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();

                Label1.ForeColor = Color.Green;
                Label1.Text = "Se ha cerrado la venta";

                BtnCancelar.Visible = false;
                btnAgregarProducto.Enabled = false;
                btnCrearVenta.Enabled = true;
                GridView1.Visible = false;

            }
            catch (Exception)
            {
                Label1.ForeColor = Color.Red;
                Label1.Text = "Se ha producido un error inesperado";
            }
        }
    }
}