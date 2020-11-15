<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site1.Master" AutoEventWireup="true" CodeBehind="VentasCanceladas.aspx.cs" Inherits="UmbrellaCorpGestion_Mendoza.Ventas.VentasCanceladas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container is-desktop">
        <div class="columns is-mobile is-vcentered is-centered has-background-black">
            <div class=" box column is-half">
                <section class="section">
                    <div class="has-text-centered">
                        <h2 class="title">Ventas canceladas</h2>
                        <hr class="has-background-primary" />
                        <h3 class="is-italic has-text-left">Lista de ventas canceladas</h3>
                        <hr style="border-top: 1px dashed hsl(171, 100%, 41%)" />
                    </div>                  
                </section>
                <div class="table-container ml-4">
                    <div class="table is-bordered is-striped is-narrow is-hoverable ">
                        <asp:GridView class="has-text-left " ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"  DataKeyNames="ID">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField SelectText="⪼⪼⪼" ShowSelectButton="True" />
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
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
</asp:Content>
