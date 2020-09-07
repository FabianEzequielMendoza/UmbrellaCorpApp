<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site1.Master" AutoEventWireup="true" CodeBehind="ModificarMiMail.aspx.cs" Inherits="UmbrellaCorpGestion_Mendoza.Usuarios.ModificarMiMail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container is-desktop">
        <div class="columns is-mobile is-vcentered is-centered has-background-black">
            <div class=" box column is-half">
                <section class="section">
                    <div class="has-text-centered">
                        <h2 class="title">Modificación de Mail</h2>
                        <hr class="has-background-primary"/>
                        <h3 class="is-italic has-text-left">
                            Complete los campos obligatorios para cambiar de mail
                        </h3>
                        <hr style="border-top:1px dashed hsl(171, 100%, 41%)"/>
                    </div>
                    <div class="field">
                        <label class="label">Nuevo Email</label>
                        <div class="control has-icons-right">
                            <asp:TextBox ID="TBMail" CssClass="input" runat="server" placeholder="Ingrese nuevo mail" TextMode="Email"></asp:TextBox>
                            <asp:RegularExpressionValidator runat="server" ErrorMessage="RegularExpressionValidator" Text="Debe colocar un Mail válido" ControlToValidate="TBMail" ForeColor="Red" ValidationExpression="^[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$" EnableTheming="True"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TBMail" ForeColor="Red">Campo requerido</asp:RequiredFieldValidator>
                            <span class="icon is-small is-right">
                                <i class="fa fa-envelope"></i>
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

                    
                </section>
            </div>
        </div>
    </div>



</asp:Content>
