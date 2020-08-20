<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site1.Master" AutoEventWireup="true" CodeBehind="alta-usuarios.aspx.cs" Inherits="UmbrellaCorpGestion_Mendoza.Usuarios.alta_usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container is-desktop">
        <div class="columns is-mobile is-vcentered is-centered has-background-black">
            <div class=" box column is-half">
                <section class="section">
                    <div class="has-text-centered">
                        <h2 class="title">Alta de Usuarios</h2>
                        <hr class="has-background-primary"/>
                        <h3 class="is-italic has-text-left">
                            Complete los campos obligatorios para crear un nuevo usuario
                        </h3>
                        <hr style="border-top:1px dashed hsl(171, 100%, 41%)"/>
                    </div>
                    <div class="field">
                        <label class="label">Nombre de usuario</label>
                        <div class="control has-icons-right">
                            <asp:TextBox class="input" type="text" ID="TBUsuario" runat="server"  ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="" ControlToValidate="TBUsuario" ForeColor="Red" SetFocusOnError="True">* Nombre de usuario requerido</asp:RequiredFieldValidator>
                            <span class="icon is-small is-right">

                                <i class="fa fa-user"></i>
                            </span>
                        </div>
                    </div>

                    <div class="field">
                        <label class="label">Contraseña</label>
                        <div class="control has-icons-right">
                            <asp:TextBox class="input" ID="TBPass" type="password" runat="server" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="" ControlToValidate="TBPass" ForeColor="Red" SetFocusOnError="true">* Contraseña requerida</asp:RequiredFieldValidator>
                            <span class="icon is-small is-right">
                                <i class="fa fa-key"></i>
                            </span>
                        </div>
                    </div>

                    <div class="field">
                        <label class="label">Confirmar contraseña</label>
                        <div class="control has-icons-right">
                            <asp:TextBox class="input" ID="TBVerificar" type="password" runat="server" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="" ControlToValidate="TBVerificar" ForeColor="Red" SetFocusOnError="true">* Verificar contraseña requerida</asp:RequiredFieldValidator>
                            <span class="icon is-small is-right">
                                <i class="fa fa-key"></i>
                            </span>
                        </div>
                    </div>

                    <div class="field">
                        <label class="label">Mail</label>
                        <div class="control has-icons-right">
                            <asp:TextBox class="input" ID="TBMail" type="email" runat="server"  ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="" ForeColor="Red" ControlToValidate="TBMail" SetFocusOnError="true">* Mail requerido</asp:RequiredFieldValidator>
                            <span class="icon is-small is-right">
                                <i class="fa fa-envelope"></i>
                            </span>
                        </div>
                    </div>

                    <div class="field is-grouped is-grouped-centered">

                        <asp:Button class="button is-medium is-vcentered is-primary mr-4" ID="BtnEntrar" runat="server" Text="Aceptar" CausesValidation="true" OnClick="BtnEntrar_Click"  />
                        <asp:Button class="button is-medium is-vcentered is-danger ml-4" ID="BtnCancerlar" runat="server" Text="Cancelar" CausesValidation="false" OnClick="BtnCancerlar_Click" PostBackUrl="~/index.aspx" />
                    </div>
                    
                    <div class="has-text-danger-dark has-text-centered">
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    </div>

                    
                </section>
            </div>
        </div>
    </div>
    
</asp:Content>
