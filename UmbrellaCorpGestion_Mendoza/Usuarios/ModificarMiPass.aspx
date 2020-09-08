<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site1.Master" AutoEventWireup="true" CodeBehind="ModificarMiPass.aspx.cs" Inherits="UmbrellaCorpGestion_Mendoza.Usuarios.ModificarMiPass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="container is-desktop">
        <div class="columns is-mobile is-vcentered is-centered has-background-black">
            <div class=" box column is-half">
                <section class="section">
                    <div class="has-text-centered">
                        <h2 class="title">Cambio de Contraseña</h2>
                        <hr class="has-background-primary"/>
                        <h3 class="is-italic has-text-left">
                            Coloque la contraseña actual y la nueva
                        </h3>
                        <hr style="border-top:1px dashed hsl(171, 100%, 41%)"/>
                    </div>
                    <div class="field">
                        <label class="label">Contraseña Actual:</label>
                        <div class="control has-icons-right">
                            <asp:TextBox ID="TBContraseniaActual" CssClass="input" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TBContraseniaActual" ForeColor="Red">Campo requerido</asp:RequiredFieldValidator>
                            <span class="icon is-small is-right">
                                <i class="fa fa-key"></i>
                            </span>
                        </div>
                    </div>

                    <div class="field">
                        <label class="label">Nueva Contraseña:</label>
                        <div class="control has-icons-right">
                            <asp:TextBox ID="TBNuevaContrasenia" CssClass="input" runat="server" TextMode="Password" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TBNuevaContrasenia" ForeColor="Red">Campo requerido</asp:RequiredFieldValidator>
                            <span class="icon is-small is-right">
                                <i class="fa fa-key"></i>
                            </span>
                        </div>
                    </div>

                    <div class="field">
                        <label class="label">Repetir Contraseña:</label>
                        <div class="control has-icons-right">
                            <asp:TextBox ID="TBRepetirContrasenia" CssClass="input" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TBRepetirContrasenia" ForeColor="Red">Campo requerido</asp:RequiredFieldValidator>
                            <span class="icon is-small is-right">
                                <i class="fa fa-key"></i>
                            </span>
                        </div>
                    </div>


                    <div class="field is-grouped is-grouped-centered">
                        <asp:Button class="button is-medium is-vcentered is-primary mr-4" ID="BtnConfirmar" runat="server" CausesValidation="true" Text="Aceptar" OnClick="BtnConfirmar_Click"  />
                        <asp:Button class="button is-medium is-vcentered is-danger ml-4" ID="BtnCancerlar" runat="server" CausesValidation="false" Text="Cancelar"  PostBackUrl="~/index.aspx" />
                    </div>
                    
                    <div class="has-text-danger-dark has-text-centered">
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    </div>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
                    
                </section>
            </div>
        </div>
    </div>




</asp:Content>
