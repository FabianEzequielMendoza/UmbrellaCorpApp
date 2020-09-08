<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="UmbrellaCorpGestion_Mendoza.login" %>

<!DOCTYPE html>

<html>
  <head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="icon" href="assets/img/logo_r_resumme.png" type="image/x-icon" />
    <title>Log In</title>
    <script src="assets/js/particles.js"></script>
    <script src="assets/js/main.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <link href="Assets/Css/bulma.min.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1, user-scalable=0">
    <link href="Assets/Css/main.css" rel="stylesheet" />
  </head>
<body>
    <form runat="server" id="frmLogin" style="height: 100vh">
        <div class="columns is-vcentered">
            <div class="login column is-4">
                <section class="section">
                    <div class="has-text-centered">
                        <img class="login-logo" src="Imagenes/umbrellaLogo.svg.png" />
                    </div>

                    <div class="field">
                        <label class="label">Nombre de usuario</label>
                        <div class="control has-icons-right">
                            <asp:TextBox class="input" type="text" ID="TBUsuario" runat="server"></asp:TextBox>
                            <span class="icon is-small is-right">
                                <i class="fa fa-user"></i>
                            </span>
                        </div>
                    </div>

                    <div class="field">
                        <label class="label">Contraseña</label>
                        <div class="control has-icons-right">
                            <asp:TextBox class="input" ID="TBPass" type="password" runat="server"></asp:TextBox>
                            <span class="icon is-small is-right">
                                <i class="fa fa-key"></i>
                            </span>
                        </div>
                    </div>
                    <div class="has-text-centered">
                        <asp:Button class="button is-vcentered is-danger is-outlined" ID="BtnEntrar" runat="server" Text="Entrar" OnClick="BtnEntrar_Click" CausesValidation="False" />
                    </div>
                    <div class="has-text-danger-dark has-text-centered">
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="has-text-centered">
                        <a onclick="javascript:RestablecerContrasenia()" href="#"><span style="color:darkred">¿No recuerdas la contraseña? Entrá aquí!</span></a>
                    </div>
                </section>
            </div>
            <div id="particles-js" class="interactive-bg column is-8">
            </div>
        </div>

        <div class="modal" id="modalRestablecerContrasenia">
            <div class="modal-background"></div>
            <div class="modal-card">
                <header class="modal-card-head">
                    <p class="modal-card-title">Recuperar Contraseña</p>
                    <button class="delete" aria-label="close"></button>
                </header>
                <section class="modal-card-body ">
                    <div class="is-centered px-3 pb-3 mt-4" style="background-color: white;">
                        <label class="label">Ingrese nombre de usuario</label>
                        <asp:TextBox ID="TBUsername" CssClass="input mt-2" runat="server" placeholder="Nombre usuario"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TBUsername" ForeColor="Red">Campo obligatorio</asp:RequiredFieldValidator>
                    </div>
                </section>
                <footer class="modal-card-foot">
                    <asp:Button ID="confirmarUsuario" CssClass="button is-success" runat="server" Text="Confirmar" CausesValidation="true" OnClick="ConfirmarUsuario_Click" />
                    <asp:Button ID="cancelar" CssClass="button is-danger" runat="server" Text="Cancelar" CausesValidation="false" PostBackUrl="~/login.aspx" />
                </footer>
            </div>
        </div>
        <asp:GridView ID="GridView1" runat="server" Visible="False"></asp:GridView>
   <script type="text/javascript">
        function RestablecerContrasenia() {
            var elemento = document.querySelectorAll("#modalRestablecerContrasenia");
            for (var i = 0; i < elemento.length; i++) {
                elemento[i].classList.toggle("is-active");
            }
        }
   </script>

    <script src="Assets/Js/Main.js"></script>
    <script src="Assets/Js/particles.js"></script>
    </form>
   </body>
</html>
