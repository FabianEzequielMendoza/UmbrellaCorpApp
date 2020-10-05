<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site1.Master" AutoEventWireup="true" CodeBehind="AltaProveedores.aspx.cs" Inherits="UmbrellaCorpGestion_Mendoza.MaterialProveedores.AltaProveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container is-desktop">
        <div class="columns is-mobile is-vcentered is-centered has-background-black">
            <div class=" box column is-half">
                <section class="section">
                    <div class="has-text-centered">
                        <h2 class="title">Alta de Proveedores</h2>
                        <hr class="has-background-primary"/>
                        <h3 class="is-italic has-text-left">
                            Complete los campos obligatorios para registrar a un proveedor
                        </h3>
                        <hr style="border-top:1px dashed hsl(171, 100%, 41%)"/>
                    </div>
                    <div class="field">
                        <label class="label">Razon Social:</label>
                        <div class="control">
                            <asp:TextBox class="input" ID="TBRazonSocial" type="number" runat="server"  ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="" ControlToValidate="TBRazonSocial" ForeColor="Red" SetFocusOnError="True">* Campo requerido</asp:RequiredFieldValidator>

                        </div>
                    </div>

                    <div class="field">
                        <label class="label">CUIT</label>
                        <div class="control">
                            <asp:TextBox class="input" ID="TBCuit" type="number" runat="server" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="" ControlToValidate="TBCuit" ForeColor="Red" SetFocusOnError="true">* Campo requerido</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    
                    <div class="field">
                        <asp:CheckBox ID="chkCertificado" runat="server" text=" Esta Certificado?"/>
                    </div>

                    <div class="field is-grouped is-grouped-centered">

                        <asp:Button class="button is-medium is-vcentered is-primary mr-4" ID="BtnRegistrar" runat="server" Text="Registrar" CausesValidation="true" OnClick="BtnRegistrar_Click"  />
                        <asp:Button class="button is-medium is-vcentered is-danger ml-4" ID="BtnCancerlar" runat="server" Text="Cancelar" CausesValidation="false" PostBackUrl="~/index.aspx" OnClick="BtnCancerlar_Click" />
                    </div>
                    
                    <div class="has-text-danger-dark has-text-centered">
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    </div>

                    
                </section>
            </div>
        </div>
    </div>




</asp:Content>
