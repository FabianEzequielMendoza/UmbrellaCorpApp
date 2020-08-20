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
                            <asp:Button class="button is-primary" ID="BtnBuscar" runat="server" Text="Buscar" OnClick="BtnBuscar_Click" />
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
                        <asp:GridView class="has-text-left " ID="GridView1" runat="server">
                            <Columns>
                                <asp:CommandField InsertText="" NewText="" SelectText="&gt;&gt;" ShowSelectButton="True" UpdateText="" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="has-text-danger-dark has-text-centered">
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </div>
                <div class="columns my-3">
                    <div class="column has-text-centered">
                        <div class="field control">
                            <asp:Button Class="button is-medium is-danger " ID="BtnCancelar" runat="server" Text="Cancelar" PostBackUrl="~/index.aspx" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
