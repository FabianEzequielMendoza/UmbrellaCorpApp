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
    <div class="columns is-vcentered">
        <div class="login column is-4">
            <section class="section">
                <div class="has-text-centered">
                    <img class="login-logo" src="Imagenes/umbrellaLogo.svg.png" />
                </div>
                <form runat="server" id="frmLogin">
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
                        <asp:LinkButton class="has-text-danger" ID="recuPass" runat="server">¿No recuerdas la contraseña? Entrá aquí!</asp:LinkButton>
                    </div>
                </form>
            </section>
        </div>
        <div id="particles-js" class="interactive-bg column is-8">
        </div>
    </div>
    <script src="Assets/Js/Main.js"></script>
    <script src="Assets/Js/particles.js"></script>
</body>
</html>
