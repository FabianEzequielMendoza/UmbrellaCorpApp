<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site1.Master" AutoEventWireup="true" CodeBehind="VentaProducto.aspx.cs" Inherits="UmbrellaCorpGestion_Mendoza.Ventas.VentaProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container is-desktop">
        <div class="columns is-mobile is-vcentered is-centered has-background-black">
            <div class=" box column is-half">
                <section class="section">
                    <div class="has-text-centered">
                        <h2 class="title">Venta de Producto</h2>
                        <hr class="has-background-primary" />
                        <h3 class="is-italic has-text-left">Gestione la venta de los productos de Umbrella
                        </h3>
                        <hr style="border-top: 1px dashed hsl(171, 100%, 41%)" />
                    </div>

                    <div class="field">
                        <div class="is-block">
                            <asp:Label CssClass="label is-inline-flex" ID="Label12" runat="server" Text="Fecha: "></asp:Label>
                            <asp:Label CssClass="" ID="lblDateTime" runat="server" Text="s"></asp:Label>
                            <span>- </span>
                            <asp:Label CssClass="label is-inline-flex" ID="Label14" runat="server" Text="Estado: "></asp:Label>
                            <asp:Label CssClass="" ID="lblEstado" runat="server" Text="s"></asp:Label>
                        </div>
                        <div class="is-block">
                            <asp:Label CssClass="label is-inline-flex" ID="Label7" runat="server" Text="Vendedor: "></asp:Label>
                            <asp:Label CssClass="" ID="lblUsuarioLogueado" runat="server" Text="s"></asp:Label>
                        </div>

                    </div>

                    <div class="field">
                        <asp:Label CssClass="label" ID="Label2" runat="server" Text="Título de la Venta:"></asp:Label>
                        <div class="control">
                            <asp:TextBox CssClass="input" ID="TBTituloVenta" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="" ValidationGroup="tituloVenta" ControlToValidate="TBTituloVenta" ForeColor="Red" SetFocusOnError="True">* Campo requerido</asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="field">
                        <asp:Label CssClass="label" ID="Label3" runat="server" Text="Descripción:"></asp:Label>
                        <div class="control">
                            <asp:TextBox CssClass="input" ID="TBDescripcion" runat="server" TextMode="MultiLine" Height="100px"></asp:TextBox>
                        </div>
                    </div>

                    <div class="field">

                        <div class="control">
                            <asp:Label CssClass="label" ID="Label4" runat="server" Text="Cliente:"></asp:Label>
                            <span class="select">
                                <asp:DropDownList ID="ddlCliente" runat="server" DataSourceID="SqlDataSource3" DataTextField="nombre" DataValueField="nombre" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddlCliente_SelectedIndexChanged">
                                    <asp:ListItem>Seleccionar</asp:ListItem>
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [nombre] FROM [cliente]"></asp:SqlDataSource>
                            </span>
                            <span>
                                <a href="#" class="pl-3" onclick="javascript:CrearCliente()">Crear Cliente</a>
                            </span>
                            

                        </div>

                    </div>

                    <div class="field">

                        <div class="control">
                           
                            <asp:Button ID="btnCrearVenta" runat="server" Text="Crear Venta" OnClick="btnCrearVenta_Click"  />

                        </div>

                    </div>


                    <div class="field">

                        <div class="control">
                            <asp:Label CssClass="label" ID="Label13" runat="server" Text="Producto:"></asp:Label>
                            <span class="select">
                                <asp:DropDownList ID="ddlProducto" runat="server" DataSourceID="SqlDataSource4" DataTextField="nombre" DataValueField="nombre" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlProducto_SelectedIndexChanged" AutoPostBack="True">
                                    <asp:ListItem>Seleccionar</asp:ListItem>
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [nombre] FROM [Producto]"></asp:SqlDataSource>
                            </span>
                            <span>
                                <asp:Button ID="btnAgregarProducto" runat="server" CssClass="is-outlined is-info button ml-3" OnClick="btnAgregarProducto_Click" Text="Agregar Producto" Enabled="False"/>
                            </span>

                        </div>

                    </div>

                    <div class="field">

                        <div class="control">
                            <asp:Label CssClass="label" ID="Label10" runat="server" Text="Cantidad Disponible:"></asp:Label>
                            <span>
                                <asp:TextBox ID="TBCantidadDisponible" CssClass="input" runat="server" ReadOnly="True"></asp:TextBox></span>
                            <asp:Label CssClass="label" ID="Label11" runat="server" Text="Cantidad:"></asp:Label>
                            <span>
                                <asp:TextBox ID="TBCantidadProducto" CssClass="input" runat="server" TextMode="Number" min="1"></asp:TextBox></span>
                                <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="La cantidad solicitada supera a la disponible" ControlToValidate="TBCantidadProducto" ForeColor="Red"></asp:RangeValidator>
                        </div>

                    </div>
                    <div>
                        <asp:Label ID="lblDetallePedido" CssClass="label" runat="server" Text="Detalle del Pedido"></asp:Label>
                    </div>

                    <div class="table-container ml-4">
                        <div class="table is-bordered is-striped is-narrow is-hoverable ">
                            <asp:GridView class="has-text-left " ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
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

                    <div class="is-block py-3">
                        <asp:Label ID="Label123" CssClass="label is-inline-flex" runat="server" Text="TOTAL: "></asp:Label>
                        <asp:Label ID="lblTotal" runat="server"></asp:Label>
                    </div>
                </section>

                <div class="field is-grouped is-grouped-centered">

                    <asp:Button class="button is-medium is-vcentered is-info ml-4" ID="BtnCerrarVenta" ValidationGroup="tituloVenta" runat="server" Text="Cerrar Venta" CausesValidation="true" OnClick="BtnCerrarVenta_Click" />
                    <asp:Button class="button is-medium is-vcentered is-info ml-4" ID="BtnGuardarVenta" runat="server" Text="Guardar Venta" CausesValidation="false" OnClick="BtnGuardarVenta_Click" />
                    <asp:Button class="button is-medium is-vcentered is-info ml-4" ID="BtnCancelar" runat="server" Text="Cancelar" CausesValidation="false" PostBackUrl="~/index.aspx" OnClick="BtnCancelar_Click" />
                </div>

                <div class="has-text-danger-dark has-text-centered">
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </div>

            </div>
        </div>
    </div>

    <div class="modal" id="modalCrearCliente">
        <div class="modal-background"></div>
        <div class="modal-card">
            <header class="modal-card-head">
                <p class="modal-card-title">Crear Cliente</p>
                <button class="delete" aria-label="close"></button>
            </header>
            <section class="modal-card-body">
                <div class="is-centered px-3 pb-3" style="background-color: white;">
                    <asp:Label ID="Label5" runat="server" CssClass="label" Text="Nombre de Cliente"></asp:Label>
                    <asp:TextBox ID="TBNombreCliente" CssClass="input" runat="server" placeholder="Ingrese nombre"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredNombreP" runat="server" ErrorMessage="" ControlToValidate="TBNombreCliente" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ValidationGroup="cliente">Campo requerido</asp:RequiredFieldValidator>
                    <asp:Label ID="Label6" runat="server" CssClass="label pt-3" Text="Contacto"></asp:Label>
                    <asp:TextBox ID="TBContacto" CssClass="input" runat="server" placeholder="Ingrese contacto"></asp:TextBox>
                    <asp:Label ID="Label8" runat="server" CssClass="label pt-3" Text="Mail"></asp:Label>
                    <asp:TextBox ID="TBMail" CssClass="input" runat="server" placeholder="Ingrese mail"></asp:TextBox>
                    <div class="control pt-5">
                        <asp:Label ID="Label9" runat="server" CssClass="label pt-3 is-inline-flex" Text="VIP"></asp:Label>
                        <span class="select">
                            <asp:DropDownList ID="DropDownList1" CssClass="ml-3" CausesValidation="false" runat="server">
                                <asp:ListItem Selected="True">True</asp:ListItem>
                                <asp:ListItem>False</asp:ListItem>
                            </asp:DropDownList>
                        </span>
                    </div>

                </div>
            </section>
            <footer class="modal-card-foot">
                <asp:Button ID="confirmarEdicion" CssClass="button is-success" runat="server" Text="Confirmar" OnClick="confirmarEdicion_Click" CausesValidation="true" ValidationGroup="cliente" />
                <asp:Button ID="cancelarEdicion" CssClass="button is-danger" runat="server" Text="Cancelar" CausesValidation="false" />
            </footer>
        </div>
    </div>

    <script type="text/javascript">
        function CrearCliente() {
            var elemento = document.querySelectorAll("#modalCrearCliente");
            for (var i = 0; i < elemento.length; i++) {
                elemento[i].classList.toggle("is-active");
            }
        }
    </script>

</asp:Content>
