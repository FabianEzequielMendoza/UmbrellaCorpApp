<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site1.Master" AutoEventWireup="true" CodeBehind="consulta-usuarios.aspx.cs" Inherits="UmbrellaCorpGestion_Mendoza.Usuarios.consultas_usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container is-desktop">
        <div class="columns is-mobile is-vcentered is-centered has-background-black">
            <div class=" box column is-half">
                <section class="section">
                    <div class="has-text-centered">
                        <h2 class="title">Consulta de usuarios</h2>
                        <hr class="has-background-primary" />
                        <h3 class="is-italic has-text-left">Realice una búsqueda por id o username y véalo en la tabla de consulta
                        </h3>
                        <hr style="border-top: 1px dashed hsl(171, 100%, 41%)" />
                    </div>
                    <div class="field has-addons is-centered">
                        <p class="control">
                            <span class="select">
                                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                                    <asp:ListItem>Username</asp:ListItem>
                                    <asp:ListItem>Id</asp:ListItem>
                                </asp:DropDownList>
                            </span>
                        </p>
                        <p class="control is-expanded">
                            <asp:TextBox class="input" type="text" ID="TextBox1" runat="server"></asp:TextBox>
                        </p>
                        <p class="control">
                            <asp:Button class="button is-info is-outlined" ID="BtnBuscar" runat="server" Text="Buscar" CausesValidation="false" OnClick="BtnBuscar_Click" />
                        </p>
                    </div>
                    <div class="control">
                        <label class="checkbox">
                            <asp:CheckBox ID="CheckBox1" runat="server" Text=" Activo" Checked="True" />
                        </label>

                        <label class="checkbox">
                            <asp:CheckBox ID="CheckBox2" runat="server" Text=" Inactivo" />
                        </label>
                    </div>

                </section>
                <div class="table-container ml-4">
                    <div class="table is-bordered is-striped is-narrow is-hoverable ">
                        <asp:GridView class="has-text-left " ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField SelectText="⪼⪼⪼" ShowSelectButton="True" />
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="white" Font-Bold="True"  />
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
                  
                    <button type="button" id="BtnDesvincular" runat="server" Class="button is-info is-outlined" visible="False" onclick = "javascript:DesvincularUsuario()">Desvincular</button>
                    <button type="button" id="BtnRestablecerCont" runat="server" Class="button is-info is-outlined" visible="False" onclick = "javascript:RestablecerContrasenia()" >Restablecer contraseña</button>
                    <button type="button" id="BtnModificarMail" runat="server" Class="button is-info is-outlined" visible="False" onclick = "javascript:ModificarMail()">Modificar mail del usuario</button>
                    
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


    <div class="modalDesvinculacion modal" id="modalDesvinculacion" >
        <div class="modal-background"></div>
        <div class="modal-card">
            <header class="modal-card-head">
                <p class="modal-card-title">Desvinculación de recurso</p>
                <button class="delete" aria-label="close"></button>
            </header>
            <section class="modal-card-body">
                ¿Estás seguro que quieres desvincular a este usuario?
            </section>
            <div class="is-centered px-3 pb-3" style="background-color:white;">
                <asp:TextBox ID="motivoDesv" CssClass="input " runat="server" placeholder="Ingrese motivo de desvinculacion"></asp:TextBox>
            </div>
            
            <footer class="modal-card-foot">
                <asp:Button ID="confirmarDesvinculacion" runat="server" CssClass="button is-success" Text="Confirmar" OnClick="ConfirmarDesvinculacion_Click" />
                <asp:Button ID="cancelarDesvinculacion" CssClass="button is-danger" runat="server" Text="Cancelar" OnClick="cancelarDesvinculacion_Click" />
            </footer>
        </div>
    </div>

    <div class="modal" id="modalRestablecerContrasenia" >
        <div class="modal-background"></div>
        <div class="modal-card">
            <header class="modal-card-head">
                <p class="modal-card-title">Restablecimiento de contraseña</p>
                <button class="delete" aria-label="close"></button>
            </header>
            <section class="modal-card-body">
                ¿Estás seguro que quieres restablecer la contraseña a este usuario?
            </section>
            <footer class="modal-card-foot">
                <asp:Button ID="confirmarContrasenia" CssClass="button is-success" runat="server" Text="Confirmar" OnClick="ConfirmarContrasenia_Click" />
                <asp:Button ID="cancelarContrasenia" CssClass="button is-danger" runat="server" Text="Cancelar" OnClick="cancelarContrasenia_Click" />
            </footer>
        </div>
    </div>

    <div class="modal" id="modalModificarMail" >
        <div class="modal-background"></div>
        <div class="modal-card">
            <header class="modal-card-head">
                <p class="modal-card-title">Cambio de mail</p>
                <button class="delete" aria-label="close"></button>
            </header>
            <section class="modal-card-body">
                 <div class="is-centered px-3 pb-3" style="background-color:white;">
                     <asp:TextBox ID="setMail" CssClass="input" runat="server" placeholder="Ingrese nuevo mail" TextMode="Email"></asp:TextBox>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="RegularExpressionValidator" Text="Debe colocar un Mail válido" ControlToValidate="setMail" ForeColor="Red" ValidationExpression="^[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$"></asp:RegularExpressionValidator>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="setMail" ForeColor="Red">Campo obligatorio</asp:RequiredFieldValidator>
                 </div>
            </section>
            <footer class="modal-card-foot">
                <asp:Button ID="confirmarMail" CssClass="button is-success" runat="server" Text="Confirmar" CausesValidation="true" OnClick="ConfirmarMail_Click"/>
                <asp:Button ID="cancelarMail" CssClass="button is-danger" runat="server" Text="Cancelar" CausesValidation="false" OnClick="cancelarMail_Click" />
            </footer>
        </div>
    </div>

    <script type="text/javascript">
        function DesvincularUsuario() {
            var elemento = document.querySelectorAll("#modalDesvinculacion");
            for (var i = 0; i < elemento.length; i++) {
                elemento[i].classList.toggle("is-active");
            }
        }
    </script>

    <script type="text/javascript">
        function ModificarMail() {
            var elemento = document.querySelectorAll("#modalModificarMail");
            for (var i = 0; i < elemento.length; i++) {
                elemento[i].classList.toggle("is-active");
            }
        }
    </script>

    <script type="text/javascript">
        function RestablecerContrasenia() {
            var elemento = document.querySelectorAll("#modalRestablecerContrasenia");
            for (var i = 0; i < elemento.length; i++) {
                elemento[i].classList.toggle("is-active");
            }
        }
    </script>

</asp:Content>
 