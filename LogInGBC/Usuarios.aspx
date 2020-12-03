<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="Usuarios.aspx.cs" Inherits="Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="bienvenidos">

        <header class="encabezado navbar-fixed-top" role="banner" id="encabezado">
            <div class="container">
                <a href="http://www.globalcollegemonterrey.com" class="logo">
                    <img src="images/LogoBlancoSmallH.png" alt="Logo" />
                </a>

<%--               <button type="button" class="boton-menu hidden-md-up " data-toggle="collapse" data-target="#menu-principal" aria-expanded="false">
                    <i class="fa fa-bars" aria-hidden="true"></i></button>--%>



                <nav id="menu-principal" class="collapse">
                    <ul>
                        <li><a href="InicioCS.aspx" data-scroll>Inicio</a></li>
                        <li><a href="Sucursales.aspx" data-scroll>Sucursales</a></li>
                        <li><a href="Cursos.aspx" data-scroll>Cursos</a></li>
                        <li><a href="Grupos.aspx" data-scroll>Grupos</a></li>
                        <li class="active"><a href="#" data-scroll>Usuarios</a></li>
                         <li><a href="Login.aspx" data-scroll>Cerrar Sesión</a></li>
                    </ul>
                </nav>

            </div>
        </header>
    </section>


    <section class="Usuarios m-x-auto">

        <div class="row col-md-12 text-md-center m-x-auto flex-items-xs-center">
            <p class="encabezado2 wow bounceIn">Usuarios</p>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>

                <div class="row col-md-12 text-md-center m-x-auto flex-items-xs-center m-b-3">
                    <div class="col-md-4 text-md-center text-xs-center">

                        <asp:Label ID="Label4" runat="server" Text="Rol" CssClass="lbl"></asp:Label>
                        <br />
                        <asp:CheckBox ID="chkadmin" runat="server" CssClass=" checkbox-inline m-r-1" Text=" Admin " Font-Bold="False" />
                        <asp:CheckBox ID="chkmaestro" runat="server" CssClass="checkbox-inline m-r-1" Text=" Maestro " />
                        <asp:CheckBox ID="chkalumno" runat="server" CssClass="checkbox-inline" Text=" Alumno " />
                    </div>
                    <div class="col-md-4 text-md-center text-xs-center">
                        <asp:Label ID="Label5" runat="server" Text="Usuario" CssClass="lbl"></asp:Label>
                        <asp:TextBox ID="txtUsuarioU" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
                    </div>
                    <div class="col-md-4 text-md-center text-xs-center">
                        <asp:Label ID="Label6" runat="server" Text="Contraseña" CssClass="lbl"></asp:Label>
                        <asp:TextBox ID="txtContraU" runat="server" CssClass="form-control" MaxLength="40" TextMode="Password"></asp:TextBox>
                    </div>
                </div>

                <div class="row col-md-12 text-md-center m-x-auto flex-items-xs-center m-b-3">
                    <div class="col-md-4 text-md-center text-xs-center">
                        <asp:Label ID="Label1" runat="server" Text="Nombre" CssClass="lbl"></asp:Label>
                        <asp:TextBox ID="txtNombreU" runat="server" CssClass="form-control" MaxLength="35"></asp:TextBox>
                    </div>
                    <div class="col-md-4 text-md-center text-xs-center">
                        <asp:Label ID="Label2" runat="server" Text="Apellido Paterno" CssClass="lbl"></asp:Label>
                        <asp:TextBox ID="txtApellidoPU" runat="server" CssClass="form-control" MaxLength="35"></asp:TextBox>
                    </div>
                    <div class="col-md-4 text-md-center text-xs-center">
                        <asp:Label ID="Label3" runat="server" Text="Apellido Materno" CssClass="lbl"></asp:Label>
                        <asp:TextBox ID="txtApellidoMU" runat="server" CssClass="form-control" MaxLength="35"></asp:TextBox>
                    </div>
                </div>


                <div class="row col-md-12 text-md-center m-x-auto flex-items-xs-center m-b-3">
                    <asp:Button ID="btnAddUsr" runat="server" Text="Agregar" CssClass="btn btn-primary btn-block col-sm-12 col-md-3 m-t-1" OnClick="btnAddUsr_Click" />
                    <div class="col-md-1 hidden-xs-down"></div>
                    <asp:Button ID="btnSrchUsr" runat="server" Text="Buscar" CssClass="btn btn-primary btn-block col-sm-12 col-md-3 m-t-1" OnClick="btnSrchUsr_Click" />
                    <div class="col-md-1 hidden-xs-down"></div>
                    <asp:Button ID="btnModUsr" runat="server" Text="Modificar" CssClass="btn btn-primary btn-block col-sm-12 col-md-3 m-t-1" OnClick="btnModUsr_Click" />
                </div>

                <div class="row col-md-12 text-md-center m-x-auto flex-items-xs-center m-t-3" style="min-height: 30vh;" id="dgvgpo">
                    <asp:GridView
                        ID="dgvUsr"
                        runat="server"
                        AllowPaging="True"
                        OnPageIndexChanging="dgvUsr_PageIndexChanging"
                        OnRowDataBound="dgvUsr_RowDataBound"
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

