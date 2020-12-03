<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="Grupos.aspx.cs" Inherits="Grupos" %>

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
                        <li><a href="Sucursales.aspx" data-scroll>Sucursales</a></li>
                        <li><a href="Cursos.aspx" data-scroll>Cursos</a></li>
                        <li class="active"><a href="#" data-scroll>Grupos</a></li>
                        <li><a href="Usuarios.aspx" data-scroll>Usuarios</a></li>
                          <li><a href="Login.aspx" data-scroll>Cerrar Sesión</a></li>
                    </ul>
                </nav>

            </div>
        </header>
    </section>

    <section class="Grupos m-x-auto">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>

        <div class="row col-md-12 text-md-center m-x-auto flex-items-xs-center">
            <p class="encabezado2 wow bounceIn">Grupos</p>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="row col-md-12 text-md-center m-x-auto flex-items-xs-center m-b-3">
                    <div class="col-md-4 text-md-center text-xs-center">
                        <asp:Label ID="Label2" runat="server" Text="Clave de Grupo" CssClass="lbl"></asp:Label>
                        <asp:TextBox ID="txtApodoGpo" runat="server" CssClass="form-control" MaxLength="15"></asp:TextBox>
                    </div>
                    <div class="col-md-4 text-md-center text-xs-center">
                        <asp:Label ID="Label1" runat="server" Text="Sucursal" CssClass="lbl"></asp:Label>
                        <asp:DropDownList ID="ddlSucursalCarga" runat="server" CssClass="btn btn-secondary btn-block" Height="38px"></asp:DropDownList>
                    </div>
                    <div class="col-md-4 text-md-center text-xs-center">
                        <asp:Label ID="Label3" runat="server" Text="Nivel" CssClass="lbl"></asp:Label>
                        <asp:DropDownList ID="ddlNivelesCurso" runat="server" CssClass="btn btn-secondary btn-block" Height="38px"></asp:DropDownList>
                    </div>
                </div>

                <div class="row col-md-12 text-md-center m-x-auto flex-items-xs-center m-b-3">
                    <asp:Button ID="btnAddGpo" runat="server" Text="Agregar" CssClass="btn btn-primary btn-block col-sm-12 col-md-3 m-t-1" OnClick="btnAddGpo_Click" />
                    <div class="col-md-1 hidden-xs-down"></div>
                    <asp:Button ID="btnSrchGpo" runat="server" Text="Buscar" CssClass="btn btn-primary btn-block col-sm-12 col-md-3 m-t-1" OnClick="btnSrchGpo_Click" />
                    <div class="col-md-1 hidden-xs-down"></div>
                    <asp:Button ID="btnModGpo" runat="server" Text="Modificar" CssClass="btn btn-primary btn-block col-sm-12 col-md-3 m-t-1" OnClick="btnModGpo_Click" />
                </div>

                <div class="row col-md-12 text-md-center m-x-auto flex-items-xs-center m-t-3 m-b-3" style="min-height: 30vh;" id="dgvgpo">

                    <asp:GridView
                        ID="dgvGpo"
                        runat="server"
                        AllowPaging="True"
                        OnPageIndexChanging="dgvGpo_PageIndexChanging"
                        OnRowDataBound="dgvGpo_RowDataBound"
                        CssClass="table table-bordered bs-table col-xs-12">

                        <HeaderStyle BackColor="#22a6b3" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#ffffcc" />
                        <PagerSettings Mode="NumericFirstLast" />
                        <PagerStyle HorizontalAlign="Center" BorderStyle="Dotted" />
                    </asp:GridView>
                </div>

                <!--Grupo alumnos-->
                <div class="row col-md-12 text-md-center m-x-auto flex-items-xs-center m-t-3">
                    <p class="encabezado2 wow bounceIn text-md-center">Grupos de Alumnos</p>
                </div>
                <div class="row col-md-12 text-md-center m-x-auto flex-items-xs-center m-b-3">
                    <div class="col-md-4 text-md-center text-xs-center">
                        <asp:Label ID="Label6" runat="server" Text="Grupo" CssClass="lbl"></asp:Label>
                        <asp:DropDownList ID="ddlgpoa" runat="server" CssClass="btn btn-secondary btn-block" Height="38px"></asp:DropDownList>
                    </div>
                    <div class="col-md-4 text-md-center text-xs-center">
                        <asp:Label ID="Label4" runat="server" Text="Usuario de Alumno" CssClass="lbl"></asp:Label>
                        <asp:TextBox ID="txtgpouser" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
                    </div>
                    <div class="col-md-4 text-md-center text-xs-center">
                        <asp:Label ID="Label5" runat="server" Text="Activo" CssClass="lbl"></asp:Label>
                        <asp:DropDownList ID="ddlactividadalumno" runat="server" CssClass="btn btn-secondary btn-block" Height="38px">
                            <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                            <asp:ListItem Value="1">Si</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="row col-md-12 text-md-center m-x-auto flex-items-xs-center m-b-3">
                    <asp:Button ID="btnaddgpoa" runat="server" Text="Agregar" CssClass="btn btn-primary btn-block col-sm-12 col-md-3 m-t-1" OnClick="btnaddgpoa_Click" />
                    <div class="col-md-1 hidden-xs-down"></div>
                    <asp:Button ID="btnsrchgpoa" runat="server" Text="Buscar" CssClass="btn btn-primary btn-block col-sm-12 col-md-3 m-t-1" OnClick="btnsrchgpoa_Click" />
                    <div class="col-md-1 hidden-xs-down"></div>
                    <asp:Button ID="btnmodgpoa" runat="server" Text="Modificar" CssClass="btn btn-primary btn-block col-sm-12 col-md-3 m-t-1" OnClick="btnmodgpoa_Click" />
                </div>

                <div class="row col-md-12 text-md-center m-x-auto flex-items-xs-center m-t-3 m-b-3" style="min-height: 30vh;">
                    <asp:GridView
                        ID="dgvgpoa"
                        runat="server"
                        AllowPaging="True"
                        OnPageIndexChanging="dgvgpoa_PageIndexChanging"
                        CssClass="table table-bordered bs-table col-xs-12">

                        <HeaderStyle BackColor="#22a6b3" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#ffffcc" />
                        <PagerSettings Mode="NumericFirstLast" />
                        <PagerStyle HorizontalAlign="Center" BorderStyle="Dotted" />
                    </asp:GridView>


                    <!--Grupo maestros-->
                    <div class="row col-md-12 text-md-center m-x-auto flex-items-xs-center m-t-3">
                        <p class="encabezado2 wow bounceIn text-md-center">Grupos de Maestros</p>
                    </div>
                    <div class="row col-md-12 text-md-center m-x-auto flex-items-xs-center m-b-3">
                        <div class="col-md-4 text-md-center text-xs-center">
                            <asp:Label ID="Label7" runat="server" Text="Grupo" CssClass="lbl"></asp:Label>
                            <asp:DropDownList ID="ddlgpom" runat="server" CssClass="btn btn-secondary btn-block" Height="38px"></asp:DropDownList>
                        </div>
                        <div class="col-md-4 text-md-center text-xs-center">
                            <asp:Label ID="Label8" runat="server" Text="Usuario de Maestro" CssClass="lbl"></asp:Label>
                            <asp:TextBox ID="txtgpousrm" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
                        </div>
                        <div class="col-md-4 text-md-center text-xs-center">
                            <asp:Label ID="Label9" runat="server" Text="Activo" CssClass="lbl"></asp:Label>
                            <asp:DropDownList ID="ddlactividadmaestro" runat="server" CssClass="btn btn-secondary btn-block" Height="38px">
                                <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                                <asp:ListItem Value="1">Si</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="row col-md-12 text-md-center m-x-auto flex-items-xs-center m-b-3">
                        <asp:Button ID="btnaddgpom" runat="server" Text="Agregar" CssClass="btn btn-primary btn-block col-sm-12 col-md-3 m-t-1" OnClick="btnaddgpom_Click" />
                        <div class="col-md-1 hidden-xs-down"></div>
                        <asp:Button ID="btnsrchgpom" runat="server" Text="Buscar" CssClass="btn btn-primary btn-block col-sm-12 col-md-3 m-t-1" OnClick="btnsrchgpom_Click" />
                        <div class="col-md-1 hidden-xs-down"></div>
                        <asp:Button ID="btnmodgpom" runat="server" Text="Modificar" CssClass="btn btn-primary btn-block col-sm-12 col-md-3 m-t-1" OnClick="btnmodgpom_Click" />
                    </div>

                    <div class="row col-md-12 text-md-center m-x-auto flex-items-xs-center m-t-3" style="min-height: 30vh;">
                        <asp:GridView
                            ID="dgvgpom"
                            runat="server"
                            AllowPaging="True"
                            OnPageIndexChanging="dgvgpom_PageIndexChanging"
                            CssClass="table table-bordered bs-table col-xs-12">

                            <HeaderStyle BackColor="#22a6b3" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#ffffcc" />
                            <PagerSettings Mode="NumericFirstLast" />
                            <PagerStyle HorizontalAlign="Center" BorderStyle="Dotted" />
                        </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </section>

</asp:Content>

