<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="InicioCS.aspx.cs" Inherits="InicioCS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <section class="bienvenidos">

        <header class="encabezado navbar-fixed-top" role="banner" id="encabezado">
            <div class="container">
                <a href="http://www.globalcollegemonterrey.com" class="logo">
                    <img src="images/LogoBlancoSmallH.png" alt="Logo"/>
                </a>

                <nav id="menu-principal" class="collapse">
                    <ul>
                        <li class="active"><a href="InicioCS.aspx" data-scroll>Inicio</a></li>
                        <li><a href="Sucursales.aspx" data-scroll>Sucursales</a></li>
                        <li><a href="Cursos.aspx" data-scroll>Cursos</a></li>
                        <li><a href="Grupos.aspx" data-scroll>Grupos</a></li>
                        <li><a href="Usuarios.aspx" data-scroll>Usuarios</a></li>
                        <li><a href="Login.aspx" data-scroll>Cerrar Sesión</a></li>
                    </ul>
                </nav>

            </div>
        </header>
    </section>



    <section class="Iniciopcs m-x-auto">
          
            <div class="row col-md-12 text-md-center m-x-auto flex-items-xs-center">
                <p class="encabezado2 wow bounceIn">Welcome</p>
            </div>

          <div class="row col-md-8 offset-md-4 m-x-auto bg-info">
                <p class="texto-parrafo text-justify">En esta sección de administración se podran realizar diversas operaciones en las categorias de <strong>Sucursales</strong>, <strong>Cursos</strong>, <strong>Grupos</strong> y  <strong>Usuarios</strong>, las cuales seran brevemente explicadas a continuación.</p>
           </div>
    </section>
</asp:Content>

