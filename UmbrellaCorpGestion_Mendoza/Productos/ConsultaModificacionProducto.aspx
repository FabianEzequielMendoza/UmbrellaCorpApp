<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site1.Master" AutoEventWireup="true" CodeBehind="ConsultaModificacionProducto.aspx.cs" Inherits="UmbrellaCorpGestion_Mendoza.Productos.ConsultaModificacionProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container is-desktop">
        <div class="columns is-mobile is-vcentered is-centered has-background-black">
            <div class=" box column is-half">
                <section class="section">
                    <div class="has-text-centered">
                        <h2 class="title">Consulta y Modificación de Producto</h2>
                        <hr class="has-background-primary" />
                        <h3 class="is-italic has-text-left">Realice una búsqueda por nombre de Producto y véalo en la tabla de consulta
                        </h3>
                        <hr style="border-top: 1px dashed hsl(171, 100%, 41%)" />
                    </div>
                    <div class="field has-addons is-centered">
                        <p class="control">
                            <span class="select">
                                <asp:DropDownList ID="DropDownList1" runat="server" CausesValidation="false" AutoPostBack="True">
                                    <asp:ListItem>Nombre de Producto</asp:ListItem>
                                </asp:DropDownList>
                            </span>
                        </p>
                        <p class="control is-expanded">
                            <asp:TextBox class="input" type="text" ID="TBNombreABuscar" runat="server"></asp:TextBox>
                        </p>
                        <p class="control">
                            <asp:Button class="button is-info is-outlined" ID="BtnBuscar" runat="server" Text="Buscar" CausesValidation="false" onclick="BtnBuscar_Click"/>
                        </p>
                    </div>
                </section>

                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" OnClick="LinkButton1_Click">Ir a Productos inactivos</asp:LinkButton>

                <div class="table-container ml-4">
                    <div class="table is-bordered is-striped is-narrow is-hoverable ">
                        <asp:GridView class="has-text-left " ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataKeyNames="ID,Nombre_Materia,Precio,Cantidad" >
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField SelectText="⪼⪼⪼" ShowSelectButton="True" />
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <EmptyDataRowStyle Wrap="True" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="white" Font-Bold="True" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                    </div>
                </div>
                <br />

                <div class="buttons is-centered">

                    <asp:Button ID="BtnInactivar" runat="server" CssClass="button is-info is-outlined" Text="Inactivar" Visible="False" CausesValidation="false" OnClick="BtnInactivar_Click" />
                    <button type="button" id="BtnEditarProducto" runat="server" class="button is-info is-outlined" visible="False" causesvalidation="false" onclick="javascript:EditarProducto()" >Editar Producto</button>
                    <button type="button" id="BtnModificarPrecio" runat="server" class="button is-info is-outlined" visible="False" causesvalidation="false" onclick="javascript:ModificarPrecio()" >Modificar Precio</button>
                    <button type="button" id="BtnModificarCantidad" runat="server" class="button is-info is-outlined" visible="False" causesvalidation="false" onclick="javascript:ModificarCantidad()" >Modificar Cantidad</button>
                </div>

                <div class="has-text-danger-dark has-text-centered">
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </div>

                <div class="columns my-3">
                    <div class="column has-text-centered">
                        <div class="field control">
                            <asp:Button Class="button is-medium is-danger " ID="BtnCancelar" runat="server" Text="Cancelar" CausesValidation="false" PostBackUrl="~/index.aspx" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal" id="modalEditarProducto">
        <div class="modal-background"></div>
        <div class="modal-card">
            <header class="modal-card-head">
                <p class="modal-card-title">Editar Producto</p>
                <button class="delete" aria-label="close"></button>
            </header>
            <section class="modal-card-body">
                <div class="is-centered px-3 pb-3" style="background-color: white;">
                    <asp:Label ID="Label2" runat="server" Text="Nombre de Producto Actual"></asp:Label>
                    <asp:TextBox ID="TBNombrePActual1" CssClass="input" runat="server" ReadOnly="True"></asp:TextBox>
                    <asp:Label ID="Label3" runat="server" Text="Nuevo nombre de Producto"></asp:Label>
                    <asp:TextBox ID="TBNombrePNuevo" CssClass="input" runat="server" placeholder="Ingrese nombre"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredNombreP" runat="server" ErrorMessage="" ControlToValidate="TBNombrePNuevo" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ValidationGroup="producto">Campo requerido</asp:RequiredFieldValidator>
                    <asp:Label ID="Label4" runat="server" Text="Nueva Descripción"></asp:Label>
                    <asp:TextBox ID="TBDescNueva" CssClass="input" runat="server" placeholder="Ingrese descripción"></asp:TextBox>
                    <asp:Label ID="Label5" runat="server" Text="Nuevo nombre de Proveedor"></asp:Label>
                   
                </div>
            </section>
            <footer class="modal-card-foot">
                <asp:Button ID="confirmarEdicion" CssClass="button is-success" runat="server" Text="Confirmar" CausesValidation="true" ValidationGroup="producto" onclick="confirmarEdicion_Click"/>
                <asp:Button ID="cancelarEdicion" CssClass="button is-danger" runat="server" Text="Cancelar" CausesValidation="false" />
            </footer>
        </div>
    </div>

    <div class="modal" id="modalModificarPrecio">
        <div class="modal-background"></div>
        <div class="modal-card">
            <header class="modal-card-head">
                <p class="modal-card-title">Modificar Precio</p>
                <button class="delete" aria-label="close"></button>
            </header>
            <section class="modal-card-body">
                <div class="is-centered px-3 pb-3" style="background-color: white;">
                    <asp:Label ID="Label8" runat="server" Text="Nombre de Producto actual"></asp:Label>
                    <asp:TextBox ID="TBNombrePActual2" CssClass="input" runat="server" ReadOnly="True"></asp:TextBox>
                    <asp:Label ID="Label6" runat="server" Text="Precio Actual"></asp:Label>
                    <asp:TextBox ID="TBPrecioActual" CssClass="input" runat="server" ReadOnly="True"></asp:TextBox>
                    <asp:Label ID="Label7" runat="server" Text="Nuevo Precio"></asp:Label>
                    <asp:TextBox ID="TBPrecioNuevo" CssClass="input" runat="server" placeholder="Ingrese precio" TextMode="Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredPrecio" runat="server" ErrorMessage="" ControlToValidate="TBPrecioNuevo" ValidationGroup="precio" ForeColor="Red" SetFocusOnError="true">Campo requerido</asp:RequiredFieldValidator>

                </div>
            </section>
            <footer class="modal-card-foot">
                <asp:Button ID="confirmarModificarPrecio" CssClass="button is-success" runat="server" Text="Confirmar" ValidationGroup="precio" CausesValidation="true"  onclick="confirmarModificarPrecio_Click"/>
                <asp:Button ID="cancelarModificarPrecio" CssClass="button is-danger" runat="server" Text="Cancelar" CausesValidation="false" />
            </footer>
        </div>
    </div>

    <div class="modal" id="modalModificarCantidad">
        <div class="modal-background"></div>
        <div class="modal-card">
            <header class="modal-card-head">
                <p class="modal-card-title">Modificar Cantidad</p>
                <button class="delete" aria-label="close"></button>
            </header>
            <section class="modal-card-body">
                <div class="is-centered px-3 pb-3" style="background-color: white;">
                    <asp:Label ID="Label9" runat="server" Text="Nombre Producto actual"></asp:Label>
                    <asp:TextBox ID="TBNombrePActual3" CssClass="input" runat="server" ReadOnly="True"></asp:TextBox>
                    <asp:Label ID="Label10" runat="server" Text="Cantidad Actual"></asp:Label>
                    <asp:TextBox ID="TBCantidadActual" CssClass="input" runat="server" ReadOnly="True"></asp:TextBox>
                    <asp:Label ID="Label11" runat="server" Text="Nueva Cantidad"></asp:Label>
                    <asp:TextBox ID="TBCantidadNueva" CssClass="input" runat="server" placeholder="Ingrese cantidad" TextMode="Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredCantidad" runat="server" ErrorMessage="" ControlToValidate="TBCantidadNueva" ValidationGroup="cantidad" ForeColor="Red" SetFocusOnError="true">Campo requerido</asp:RequiredFieldValidator>

                </div>
            </section>
            <footer class="modal-card-foot">
                <asp:Button ID="confirmarModificarCantidad" CssClass="button is-success" runat="server" Text="Confirmar" ValidationGroup="cantidad" CausesValidation="true" onclick="confirmarModificarCantidad_Click" />
                <asp:Button ID="cancelarModificarCantidad" CssClass="button is-danger" runat="server" Text="Cancelar" CausesValidation="false" />
            </footer>
        </div>
    </div>



    <script type="text/javascript">
        function EditarProducto() {
            var elemento = document.querySelectorAll("#modalEditarProducto");
            for (var i = 0; i < elemento.length; i++) {
                elemento[i].classList.toggle("is-active");
            }
        }
    </script>

    <script type="text/javascript">
        function ModificarPrecio() {
            var elemento = document.querySelectorAll("#modalModificarPrecio");
            for (var i = 0; i < elemento.length; i++) {
                elemento[i].classList.toggle("is-active");
            }
        }
    </script>

    <script type="text/javascript">
        function ModificarCantidad() {
            var elemento = document.querySelectorAll("#modalModificarCantidad");
            for (var i = 0; i < elemento.length; i++) {
                elemento[i].classList.toggle("is-active");
            }
        }
    </script>
</asp:Content>
