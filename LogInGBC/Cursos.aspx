<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="Cursos.aspx.cs" Inherits="Cursos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        hr {
            width: 80%;
            height: 8px;
            margin-left: auto;
            margin-right: auto;
            background-color: #e74c3c;
            color: #e74c3c;
            border: 0 none;
            margin-top: 5px;
            margin-bottom: 5px;
            border-radius: 5px;
        }
    </style>    
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
                        <li class="active"><a href="#" data-scroll>Cursos</a></li>
                        <li><a href="Grupos.aspx" data-scroll>Grupos</a></li>
                        <li><a href="Usuarios.aspx" data-scroll>Usuarios</a></li>
                         <li><a href="Login.aspx" data-scroll>Cerrar Sesión</a></li>
                    </ul>
                </nav>

            </div>
        </header>
    </section>

    <section class="Cursos m-x-auto">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>

        <div class="row col-md-12 text-md-center m-x-auto flex-items-xs-center">
            <p class="encabezado2 wow bounceIn">Cursos</p>
        </div>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="row col-md-12 text-md-center m-x-auto flex-items-xs-center m-b-3">
                    <div class="col-md-4 text-md-center text-xs-center">
                        <asp:Label ID="Label1" runat="server" Text="Nombre:" CssClass="lbl"></asp:Label>
                        <asp:TextBox ID="txtNombreCur" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                    </div>
                    <div class="col-md-4 text-md-center text-xs-center">
                        <asp:Label ID="Label2" runat="server" Text="Categoria:" CssClass="lbl"></asp:Label>
                        <asp:DropDownList ID="ddlCategoriaCur" runat="server" CssClass="btn btn-secondary btn-block" Height="38px">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-4 text-md-center text-xs-center">
                        <asp:Label ID="Label3" runat="server" Text="Duración (Meses)" CssClass="lbl"></asp:Label>
                        <asp:TextBox ID="txtDuracionCur" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox>
                    </div>
                </div>

                <div class="row col-md-12 text-md-center m-x-auto flex-items-xs-center m-b-3">
                    <div class="col-md-2 text-md-center text-xs-center">
                        <asp:Label ID="Label4" runat="server" Text="Precio" CssClass="lbl"></asp:Label>
                        <asp:TextBox ID="txtPrecioCur" runat="server" CssClass="form-control" MaxLength="11"></asp:TextBox>
                    </div>
                    <div class="col-md-4 text-md-center text-xs-center">
                        <asp:Label ID="Label6" runat="server" Text="Descripción" CssClass="lbl"></asp:Label>
                        <asp:TextBox ID="txtDesCur" runat="server" CssClass="form-control" MaxLength="150"></asp:TextBox>
                    </div>

                    <div class="col-md-3 text-md-center text-xs-center">
                        <asp:Label ID="Label5" runat="server" Text="Selección Horario" CssClass="lbl"></asp:Label>
                        <asp:DropDownList ID="ddlHorarioCur" runat="server" CssClass="btn btn-secondary btn-block" Height="38px">

                            <asp:ListItem Value="0" Selected="True">No</asp:ListItem>

                            <asp:ListItem Value="1">Si</asp:ListItem>

                        </asp:DropDownList>
                    </div>
                    <div class="col-md-3 text-md-center text-xs-center">
                        <asp:Label ID="Label7" runat="server" Text="Cantidad Alumnos" CssClass="lbl"></asp:Label>
                        <asp:DropDownList ID="ddlCantidadCur" runat="server" CssClass="btn btn-secondary btn-block" Height="38px">

                            <asp:ListItem Value="0" Selected="True">No</asp:ListItem>

                            <asp:ListItem Value="1">Si</asp:ListItem>

                        </asp:DropDownList>
                    </div>
                </div>

                <div class="row col-md-12 text-md-center m-x-auto flex-items-xs-center m-b-3">
                    <asp:Button ID="btnAddCur" runat="server" Text="Agregar" CssClass="btn btn-primary btn-block col-sm-12 col-md-3 m-t-1" OnClick="btnAddCur_Click" />
                    <div class="col-md-1 hidden-xs-down"></div>
                    <asp:Button ID="btnSrchCur" runat="server" Text="Buscar" CssClass="btn btn-primary btn-block col-sm-12 col-md-3 m-t-1" OnClick="btnSrchCur_Click" />
                    <div class="col-md-1 hidden-xs-down"></div>
                    <asp:Button ID="btnModCur" runat="server" Text="Modificar" CssClass="btn btn-primary btn-block col-sm-12 col-md-3 m-t-1" OnClick="btnModCur_Click" />
                </div>

                <div class="row col-xs-12 col-md-12 text-md-center m-x-auto flex-items-xs-center m-b-2" style="min-height: 30vh;" id="dgvcursos">

                    <asp:GridView
                        ID="dgvCur"
                        runat="server"
                        AllowPaging="True"
                        OnPageIndexChanging="dgvCur_PageIndexChanging"
                        OnRowDataBound="dgvCur_RowDataBound"
                        CssClass="table table-bordered bs-table col-xs-12">

                        <HeaderStyle BackColor="#22a6b3" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#ffffcc" />
                        <PagerSettings Mode="NumericFirstLast" />
                        <PagerStyle HorizontalAlign="Center" BorderStyle="Dotted" />
                        <RowStyle Width="100%" />
                    </asp:GridView>
                </div>






                <!--Seccion de niveles-->
                <div class="row col-md-12 text-md-center m-x-auto flex-items-xs-center">
                    <p class="encabezado2 wow bounceIn">Niveles</p>
                </div>
                <div class="row col-md-12 text-md-center m-x-auto flex-items-xs-center m-b-3">
                    <div class="col-md-2 text-md-center text-xs-center">
                        <asp:Label ID="Label8" runat="server" Text="Clave" CssClass="lbl"></asp:Label>
                        <asp:TextBox ID="txtclavelvl" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                    </div>
                    <div class="col-md-3 text-md-center text-xs-center">
                        <asp:Label ID="Label9" runat="server" Text="Nombre:" CssClass="lbl"></asp:Label>
                        <asp:TextBox ID="txtnombrelvl" runat="server" CssClass="form-control" MaxLength="15"></asp:TextBox>
                    </div>
                    <div class="col-md-3 text-md-center text-xs-center">
                        <asp:Label ID="Label10" runat="server" Text="Link" CssClass="lbl"></asp:Label>
                        <asp:TextBox ID="txtlinklvl" runat="server" CssClass="form-control" MaxLength="2000"></asp:TextBox>
                    </div>
                    <div class="col-md-3 text-md-center text-xs-center">
                        <asp:Label ID="Label11" runat="server" Text="Curso" CssClass="lbl"></asp:Label>
                        <asp:DropDownList ID="ddlnivelcurso" runat="server" CssClass="btn btn-secondary btn-block" Height="38px"></asp:DropDownList>
                    </div>
                </div>

                <div class="row col-md-12 text-md-center m-x-auto flex-items-xs-center m-b-3">
                    <asp:Button ID="btnAddlvl" runat="server" Text="Agregar" CssClass="btn btn-primary btn-block col-sm-12 col-md-3 m-t-1" OnClick="btnAddlvl_Click" />
                    <div class="col-md-1 hidden-xs-down"></div>
                    <asp:Button ID="btnSrchlvl" runat="server" Text="Buscar" CssClass="btn btn-primary btn-block col-sm-12 col-md-3 m-t-1" OnClick="btnSrchlvl_Click" />
                    <div class="col-md-1 hidden-xs-down"></div>
                    <asp:Button ID="btnModlvl" runat="server" Text="Modificar" CssClass="btn btn-primary btn-block col-sm-12 col-md-3 m-t-1" OnClick="btnModlvl_Click" />

                </div>

                <div class="row col-xs-12  col-md-12 text-md-center m-x-auto flex-items-xs-center m-b-2" style="min-height: 30vh;" id="dgvcursos">
                    <asp:GridView
                        ID="dgvniveles"
                        runat="server"
                        AllowPaging="True"
                        OnPageIndexChanging="dgvniveles_PageIndexChanging"
                        CssClass="table table-bordered bs-table col-xs-12" PageSize="10">

                        <HeaderStyle BackColor="#22a6b3" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#ffffcc" />
                        <PagerSettings Mode="NumericFirstLast" />
                        <PagerStyle HorizontalAlign="Center" BorderStyle="Dotted" />
                    </asp:GridView>
                </div>


                <!-- <hr class="jumbotron-hr m-t-3 m-b-3" id="sepc1"/>-->
                <!--Seccion de categoria-->
                <div class="row col-md-12 text-md-center m-x-auto flex-items-xs-center m-t-1">
                    <p class="encabezado2 wow bounceIn">Categorias</p>
                </div>

                <div class="row col-md-12 text-md-center m-x-auto flex-items-xs-center m-b-3">
                    <div class="col-xs-12 col-md-6 text-md-center text-xs-center">
                        <asp:Label ID="lblcat" runat="server" Text="Nombre" CssClass="lbl"></asp:Label>
                        <asp:TextBox ID="txtnombrecat" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                    </div>
                </div>

                <div class="row col-md-12 text-md-center m-x-auto flex-items-xs-center">
                    <asp:Button ID="btnAddCat" runat="server" Text="Agregar" CssClass="btn btn-primary btn-block col-sm-12 col-md-3 m-t-1" OnClick="btnAddCat_Click" />
                    <div class="col-md-1 hidden-xs-down"></div>
                    <asp:Button ID="btnSrchCat" runat="server" Text="Buscar" CssClass="btn btn-primary btn-block col-sm-12 col-md-3 m-t-1" OnClick="btnSrchCat_Click" />
                    <div class="col-md-1 hidden-xs-down"></div>
                    <asp:Button ID="btnModCat" runat="server" Text="Modificar" CssClass="btn btn-primary btn-block col-sm-12 col-md-3 m-t-1" OnClick="btnModCat_Click" />
                </div>

                <div class="row col-xs-12 col-md-12 text-md-center m-x-auto flex-items-xs-center m-t-2" style="min-height: 30vh;" id="dgvcategoriascur">


                    <asp:GridView
                        ID="dgvCategoriasCur"
                        runat="server"
                        AllowPaging="True"
                        OnPageIndexChanging="dgvCategoriasCur_PageIndexChanging"
                        OnRowDataBound="dgvCategoriasCur_RowDataBound"
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

