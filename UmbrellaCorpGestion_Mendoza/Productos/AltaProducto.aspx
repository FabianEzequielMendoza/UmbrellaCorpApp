<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site1.Master" AutoEventWireup="true" CodeBehind="AltaProducto.aspx.cs" Inherits="UmbrellaCorpGestion_Mendoza.Productos.AltaProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container is-desktop">
        <div class="columns is-mobile is-vcentered is-centered has-background-black">
            <div class=" box column is-half">
                <section class="section">
                    <div class="has-text-centered">
                        <h2 class="title">Generación de Producto</h2>
                        <hr class="has-background-primary"/>
                        <h3 class="is-italic has-text-left">
                            Complete los campos obligatorios para dar de alta los productos
                        </h3>
                        <hr style="border-top:1px dashed hsl(171, 100%, 41%)"/>
                    </div>
                    <div class="field">
                        <asp:Label CssClass="label" ID="Label2" runat="server" Text="Nombre de Producto:"></asp:Label>
                        <div class="control">
                            <asp:TextBox CssClass="input" ID="TBNombreP"  runat="server"  ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="" ControlToValidate="TBNombreP" ForeColor="Red" SetFocusOnError="True">* Campo requerido</asp:RequiredFieldValidator>
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
                            <asp:Label CssClass="label" ID="Label4" runat="server" Text="Nombre de Materia Prima:"></asp:Label>
                            <span class="select">
                                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="nombre" DataValueField="nombre" AppendDataBoundItems="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True" style="left: 0px; top: 0px">
                                    <asp:ListItem>Seleccionar</asp:ListItem>
                                </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT nombre FROM MateriaPrima WHERE (activo = 'True')"></asp:SqlDataSource>
                            </span>
                            
                        </div>
                        
                    </div>

                    <div class="field" id="camposDeBase" runat="server" style="border:3px solid black;padding:5px;">
                        <asp:Label CssClass="label" ID="Label8" runat="server" Text="PU:"></asp:Label>
                        <div class="control">
                            <asp:TextBox CssClass="input" ID="TBPU"  runat="server" AutoPostBack="True" ReadOnly="True"  ></asp:TextBox>
                        </div>

                        <asp:Label CssClass="label" ID="Label9" runat="server" Text="Cantidad:"></asp:Label>
                        <div class="control">
                            <asp:TextBox CssClass="input" ID="TBCantidadMat"  runat="server" AutoPostBack="True" ReadOnly="True"  ></asp:TextBox>
                        </div>

                        <asp:Label CssClass="label" ID="Label10" runat="server" Text="Proveedor:"></asp:Label>
                        <div class="control">
                            <asp:TextBox CssClass="input" ID="TBProveedor"  runat="server" AutoPostBack="True" ReadOnly="True"  ></asp:TextBox>
                        </div>
                        <asp:TextBox ID="TBID" runat="server" Visible="False"></asp:TextBox>
                    </div>

                    <div class="field">
                        <asp:Label CssClass="label" ID="Label5" runat="server" Text="Cantidad de MP a solicitar:"></asp:Label>
                        <div class="control">
                            <asp:TextBox CssClass="input" ID="TBCantidadSol" runat="server" TextMode="Number"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="" ControlToValidate="TBCantidadSol" ForeColor="Red" SetFocusOnError="True">* Campo requerido</asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="field">
                        <asp:Label CssClass="label" ID="Label6" runat="server" Text="Cantidad de Producto:"></asp:Label>
                        <div class="control">
                            <asp:TextBox CssClass="input" ID="TBCantidadProducto" runat="server" TextMode="Number"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="" ControlToValidate="TBCantidadProducto" ForeColor="Red" SetFocusOnError="True">* Campo requerido</asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="field">
                        <asp:Label CssClass="label" ID="Label11" runat="server" Text="PU de Producto:"></asp:Label>
                        <div class="control">
                            <asp:TextBox CssClass="input" ID="TBPUProducto" runat="server" TextMode="Number"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="" ControlToValidate="TBPUProducto" ForeColor="Red" SetFocusOnError="True">* Campo requerido</asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="field is-grouped is-grouped-centered">

                        <asp:Button class="button is-medium is-vcentered is-primary mr-4" ID="BtnGenerar" runat="server" Text="Generar" CausesValidation="true" OnClick="BtnGenerar_Click"   />
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
