<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site1.Master" AutoEventWireup="true" CodeBehind="AltaMateriaPrima.aspx.cs" Inherits="UmbrellaCorpGestion_Mendoza.MaterialProveedores.AltaMateriaPrima" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container is-desktop">
        <div class="columns is-mobile is-vcentered is-centered has-background-black">
            <div class=" box column is-half">
                <section class="section">
                    <div class="has-text-centered">
                        <h2 class="title">Alta de Materiales</h2>
                        <hr class="has-background-primary"/>
                        <h3 class="is-italic has-text-left">
                            Complete los campos obligatorios para dar de alta lo materiales
                        </h3>
                        <hr style="border-top:1px dashed hsl(171, 100%, 41%)"/>
                    </div>
                    <div class="field">
                        <asp:Label CssClass="label" ID="Label2" runat="server" Text="Nombre de Materia Prima:"></asp:Label>
                        <div class="control">
                            <asp:TextBox CssClass="input" ID="TBNombreMP"  runat="server"  ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="" ControlToValidate="TBNombreMP" ForeColor="Red" SetFocusOnError="True">* Campo requerido</asp:RequiredFieldValidator>
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
                            <asp:Label CssClass="label" ID="Label4" runat="server" Text="Proveedor:"></asp:Label>
                            <span class="select">
                                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="razonSocial" DataValueField="razonSocial">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [razonSocial] FROM [Proveedores] WHERE (([activo] = @activo) AND ([certificado] = @certificado))">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="True" Name="activo" Type="Boolean" />
                                        <asp:Parameter DefaultValue="True" Name="certificado" Type="Boolean" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </span>
                            
                        </div>
                        
                    </div>

                    <div class="field">
                        <asp:Label CssClass="label" ID="Label5" runat="server" Text="Precio Unitario:"></asp:Label>
                        <div class="control">
                            <asp:TextBox CssClass="input" ID="TBPrecio" runat="server" TextMode="Number"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="" ControlToValidate="TBPrecio" ForeColor="Red" SetFocusOnError="True">* Campo requerido</asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="field">
                        <asp:Label CssClass="label" ID="Label6" runat="server" Text="Moneda:"></asp:Label>
                        <div class="control">
                            <span class="select">
                                 <asp:DropDownList CssClass="dropdown" ID="DropDownList2" runat="server">
                                <asp:ListItem>USD</asp:ListItem>
                                <asp:ListItem>ARS</asp:ListItem>
                                <asp:ListItem>LIBRA</asp:ListItem>
                                <asp:ListItem>EUR</asp:ListItem>
                                </asp:DropDownList>                           
                            </span>
                           
                        </div>
                    </div>

                     <div class="field">
                        <asp:Label CssClass="label" ID="Label7" runat="server" Text="Cantidad:"></asp:Label>
                        <div class="control">
                            <asp:TextBox CssClass="input" ID="TBCantidad" runat="server" TextMode="Number"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="" ControlToValidate="TBCantidad" ForeColor="Red" SetFocusOnError="True">* Campo requerido</asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="field is-grouped is-grouped-centered">

                        <asp:Button class="button is-medium is-vcentered is-primary mr-4" ID="BtnGenerar" runat="server" Text="Registrar" CausesValidation="true" OnClick="BtnGenerar_Click"  />
                        <asp:Button class="button is-medium is-vcentered is-danger ml-4" ID="BtnCancerlar" runat="server" Text="Cancelar" CausesValidation="false" PostBackUrl="~/index.aspx"  />
                    </div>
                    
                    <div class="has-text-danger-dark has-text-centered">
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    </div>
    
                </section>
            </div>
        </div>
    </div>

</asp:Content>
