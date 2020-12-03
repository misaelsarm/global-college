<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="Sucursales.aspx.cs" Inherits="Sucursales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="bienvenidos">

        <header class="encabezado navbar-fixed-top" role="banner" id="encabezado">
            <div class="container">
                <a href="http://www.globalcollegemonterrey.com" class="logo">
                    <img src="images/LogoBlancoSmallH.png" alt="Logo">
                </a>




                <nav id="menu-principal" class="collapse">
                    <ul>
                        <li><a href="InicioCS.aspx" data-scroll>Inicio</a></li>
                        <li class="active"><a href="#" data-scroll>Sucursales</a></li>
                        <li><a href="Cursos.aspx" data-scroll>Cursos</a></li>
                        <li><a href="Grupos.aspx" data-scroll>Grupos</a></li>
                        <li><a href="Usuarios.aspx" data-scroll>Usuarios</a></li>
                        <li><a href="Login.aspx" data-scroll>Cerrar Sesión</a></li>
                    </ul>
                </nav>

            </div>
        </header>
    </section>



    <section class="SucursalesInfo m-x-auto">

        <div class="row col-md-12 text-md-center m-x-auto flex-items-xs-center">
            <p class="encabezado2 wow bounceIn">Sucursales</p>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>

                <div class="row col-md-12 text-md-center m-x-auto flex-items-xs-center m-b-3">
                    <div class="col-md-4 text-md-center text-xs-center">
                        <asp:Label ID="Label1" runat="server" Text="Nombre" CssClass="lbl"></asp:Label>
                        <asp:TextBox ID="txtNombreSuc" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                    </div>
                    <div class="col-md-6 text-md-center text-xs-center">
                        <asp:Label ID="Label2" runat="server" Text="Dirección" CssClass="lbl"></asp:Label>
                        <asp:TextBox ID="txtDireSuc" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2 text-md-center text-xs-center">
                        <asp:Label ID="Label3" runat="server" Text="Estatus" CssClass="lbl"></asp:Label>
                        <asp:DropDownList ID="ddlEstatusSuc" runat="server" CssClass="btn btn-secondary btn-block" Height="38px">
                            <asp:ListItem Value="0" Selected="True">Inactivo</asp:ListItem>
                            <asp:ListItem Value="1">Activo</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>


                <div class="row col-md-12 text-md-center m-x-auto flex-items-xs-center m-b-3">
                    <asp:Button ID="btnAddSuc" runat="server" Text="Agregar" CssClass="btn btn-primary btn-block col-sm-12 col-md-3 m-t-1" OnClick="btnAddSuc_Click" OnClientClick="" />
                    <div class="col-md-1 hidden-xs-down"></div>
                    <asp:Button ID="btnSrchSuc" runat="server" Text="Buscar" CssClass="btn btn-primary btn-block col-sm-12 col-md-3 m-t-1" OnClick="btnSrchSuc_Click" />
                    <div class="col-md-1 hidden-xs-down"></div>
                    <asp:Button ID="btnModSuc" runat="server" Text="Modificar" CssClass="btn btn-primary btn-block col-sm-12 col-md-3 m-t-1" OnClick="btnModSuc_Click" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <div class="row col-md-12 text-md-center m-x-auto flex-items-xs-center m-t-3" style="min-height: 30vh;" id="dgvsuc">
                    <asp:GridView
                        ID="dgvSucursales"
                        runat="server"
                        AllowPaging="True"
                        OnPageIndexChanging="dgvSucursales_PageIndexChanging"
                        OnRowDataBound="dgvSucursales_RowDataBound"
                        CssClass="table table-bordered bs-table col-xs-12">

                        <HeaderStyle BackColor="#22a6b3" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#ffffcc" />
                        <PagerSettings Mode="NumericFirstLast" />
                        <PagerStyle HorizontalAlign="Center" BorderStyle="Dotted" />
                    </asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>





    </section>
</asp:Content>

