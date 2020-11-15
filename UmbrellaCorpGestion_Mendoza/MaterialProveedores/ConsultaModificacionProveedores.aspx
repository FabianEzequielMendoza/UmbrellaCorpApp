<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site1.Master" AutoEventWireup="true" CodeBehind="ConsultaModificacionProveedores.aspx.cs" Inherits="UmbrellaCorpGestion_Mendoza.MaterialProveedores.ConsultaModificacionProveedroes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container is-desktop">
        <div class="columns is-mobile is-vcentered is-centered has-background-black">
            <div class=" box column is-half">
                <section class="section">
                    <div class="has-text-centered">
                        <h2 class="title">Consulta y Modificación de Proveedores</h2>
                        <hr class="has-background-primary" />
                        <h3 class="is-italic has-text-left">Realice una búsqueda por nombre de proveedor o CUIT y véalo en la tabla de consulta
                        </h3>
                        <hr style="border-top: 1px dashed hsl(171, 100%, 41%)" />
                    </div>
                    <div class="field has-addons is-centered">
                        <p class="control">
                            <span class="select">
                                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                                    <asp:ListItem>Razon Social</asp:ListItem>
                                    <asp:ListItem>CUIT</asp:ListItem>
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
                            <asp:CheckBox ID="CheckBox1" runat="server" Text=" Certificados" Checked="True" />
                        </label>

                        <label class="checkbox">
                            <asp:CheckBox ID="CheckBox2" runat="server" Text=" No Certificados" />
                        </label>
                    </div>
                </section>
           
                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" OnClick="LinkButton1_Click">Ir a Proveedores Inactivos</asp:LinkButton>
                    
                <div class="table-container ml-4">
                    <div class="table is-bordered is-striped is-narrow is-hoverable ">
                        <asp:GridView class="has-text-left " ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" DataKeyNames="ID,Razon_Social">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField SelectText="⪼⪼⪼" ShowSelectButton="True" />
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <EmptyDataRowStyle Wrap="True" />
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
                  
                    <asp:Button ID="BtnInactivar" runat="server" CssClass="button is-info is-outlined" Text="Inactivar" Visible="False" OnClick="BtnInactivar_Click" CausesValidation="False" />
                    <button type="button" id="BtnEditarProveedor" runat="server" Class="button is-info is-outlined" visible="False" onclick = "javascript:EditarProveedor()" causesvalidation="False">Editar Proveedor</button> 
                    
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
    <div class="modal" id="modalEditarProveedor" >
        <div class="modal-background"></div>
        <div class="modal-card">
            <header class="modal-card-head">
                <p class="modal-card-title">Editar Proveedor</p>
                <button class="delete" aria-label="close"></button>
            </header>
            <section class="modal-card-body">
                 <div class="is-centered px-3 pb-3" style="background-color:white;">
                     <asp:Label ID="Label2" runat="server" Text="Razon Social"></asp:Label>
                     <asp:TextBox ID="TBRazonSocial" CssClass="input" runat="server" Enabled="True" ReadOnly="True"></asp:TextBox>
                     <asp:Label ID="Label3" runat="server" Text="CUIT"></asp:Label>
                     <asp:TextBox ID="TBCuit" CssClass="input" runat="server" placeholder="Ingrese nuevo CUIT"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="" ControlToValidate="TBCuit" ForeColor="Red" SetFocusOnError="true">Campo requerido</asp:RequiredFieldValidator>
                     <div>
                        <asp:RadioButton ID="RadioButton1" Text="Certificado" runat="server" CssClass="radio"  GroupName="Estado de certificado" Checked="True" />
                        <asp:RadioButton ID="RadioButton2" Text="No certificado" runat="server" CssClass="radio" GroupName="Estado de certificado" />
                     </div>
                 </div>
            </section>
            <footer class="modal-card-foot">
                <asp:Button ID="confirmarEdicion" CssClass="button is-success" runat="server" Text="Confirmar" CausesValidation="true" onclick="confirmarEdicion_Click"/>
                <asp:Button ID="cancelarEdicion" CssClass="button is-danger" runat="server" Text="Cancelar" CausesValidation="false"  />
            </footer>
        </div>
    </div>

    <script type="text/javascript">
        function EditarProveedor() {
            var elemento = document.querySelectorAll("#modalEditarProveedor");
            for (var i = 0; i < elemento.length; i++) {
                elemento[i].classList.toggle("is-active");
            }
        }
    </script>

  
</asp:Content>
