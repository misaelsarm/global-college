<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cotizador.aspx.cs" Inherits="Cotizador"  %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GLOBAL COLLEGE MONTERREY | QUOTATION</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta http-equiv="x-ua-compatible" content="ie=edge">
    <link rel="shortcut icon" type="image/x-icon" href="favicon.png">
    <!-- Required meta tags always come first -->
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta http-equiv="x-ua-compatible" content="ie=edge">
    <link rel="shortcut icon" type="image/x-icon" href="images/favicon.png">

    <!-- Cargando fuentes -->
    <link href='https://fonts.googleapis.com/css?family=Open+Sans:400,700,700italic' rel='stylesheet' type='text/css'>

    <!-- Cargando iconos -->
    <link href='css/font-awesome.min.css' rel='stylesheet' type='text/css'>

    <!-- Carga de Galeria de imágenes -->
    <link rel="stylesheet" href="css/owl.carousel.min.css">

    <!-- Carga de archivos css -->
    <link rel="stylesheet" href="css/bootstrap.css">
    <link rel="stylesheet" href="css/animate.min.css">
    <link rel="stylesheet" href="css/estilos.css">
</head>
<body class="paginas-internas">
    <section class="bienvenidosc">

        <header class="encabezado navbar-fixed-top" role="banner" id="encabezado">
            <div class="container">
                <a href="../Index.html" class="logo">
                    <img src="images/LogoBlancoSmallH.png" alt="Logo">
                </a>


                <nav id="menu-principal" class="collapse">
                    <ul>
                        <li><a href="../Index.html">Inicio</a></li>
                        <li><a href="http://globalcollegemonterrey.com/#escuela" data-scroll>Nosotros</a></li>
                        <li><a href="http://globalcollegemonterrey.com/#servicios" data-scroll>Servicios</a></li>
                        <li class="active"><a href="#">Cotización</a></li>
                        <li><a href="/LogInGBC/Login.aspx" data-scroll>Login</a></li>
                    </ul>
                </nav>

            </div>
        </header>


        <div class="texto-encabezado text-xs-center">

            <div class="container">
                <h1 class="gbcencabezado display-4 wow bounceIn">Cotización</h1>
                <p class="wow bounceIn" data-wow-delay=".3s">Estamos listos para ayudarte</p>

            </div>

        </div>

    </section>
    <section class="ruta p-y-1">
        <div class="container">
            <div class="row">
                <div class="col-xs-12 text-xs-right">
                    <a href="http://globalcollegemonterrey.com">Inicio</a> » Cotización

                </div>
            </div>
        </div>
    </section>


    <main class="p-y-1">
        <div class="container">
            <h2 class="m-b-3 m-t-1 text-xs-center text-md-left">Formulario de contacto</h2>
            <form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>

                <div class="row col-md-12 text-md-center m-x-auto flex-items-xs-center m-b-3">
                    <div class="col-xs-12 col-md-6 text-md-center text-xs-center m-b-3">
                        <asp:Label ID="Label1" runat="server" Text="Selecciona el tipo de curso que te interesa " CssClass="lbl hidden-sm-down"></asp:Label>
                         <asp:Label ID="Label12" runat="server" Text="Tipo de curso:" CssClass="lbl hidden-md-up"></asp:Label>
                        <asp:DropDownList ID="ddlTipoCurso" OnSelectedIndexChanged="ddlTipoCurso_SelectedIndexChanged" runat="server" AutoPostBack="True"  CssClass="btn btn-secondary btn-block" Height="40px"></asp:DropDownList>
                    </div>
                    <div class="col-xs-12 col-md-6 text-md-center text-xs-center m-b-3">
                        <asp:Label ID="Label9" runat="server" Text="Seleccione el curso de su preferencia " CssClass="lbl hidden-sm-down"></asp:Label>
                         <asp:Label ID="Label13" runat="server" Text="Curso:" CssClass="lbl hidden-md-up"></asp:Label>
                        <asp:DropDownList ID="ddlCurso" runat="server" AutoPostBack="True" CssClass="btn btn-secondary btn-block" Height="40px"></asp:DropDownList>
                    </div>
                    <div class="col-xs-12 col-md-6 text-md-center text-xs-center m-b-3">
                        <asp:Label ID="lblCantidad" runat="server" Text="¿Cuantas personas asistiran?  " CssClass="lbl hidden-sm-down"></asp:Label>
                         <asp:Label ID="Label14" runat="server" Text="Personas a asistir:" CssClass="lbl hidden-md-up"></asp:Label>
                        <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" TextMode="Number" ToolTip="Ej: 1"></asp:TextBox>
                        <asp:RangeValidator ID="Range1"
                            ControlToValidate="txtCantidad"
                            MinimumValue="1"
                            MaximumValue="999999"
                            Type="Integer"
                            EnableClientScript="true"
                            Text="La cantidad debe ser un numero entero"
                            runat="server" />
                    </div>
                    <div class="col-xs-12 col-md-6 text-md-center text-xs-center m-b-3">
                        <asp:Label ID="Label2" runat="server" Text="Selecciona la sucursal" CssClass="lbl hidden-sm-down"></asp:Label>
                        <asp:Label ID="Label3" runat="server" Text="Sucursal: " CssClass="lbl hidden-md-up"></asp:Label>
                        <asp:DropDownList ID="ddlSucursal" runat="server" CssClass="btn btn-secondary btn-block" Height="40px"></asp:DropDownList>
                    </div>
                    <div class="col-xs-12 col-md-6 text-md-center text-xs-center m-b-3">
                        <asp:Label ID="Label8" runat="server" Text="Selecciona los dias de tu preferencia " CssClass="lbl hidden-sm-down"></asp:Label>
                         <asp:Label ID="Label10" runat="server" Text="Dias de la clase:" CssClass="lbl hidden-md-up"></asp:Label>
                        <asp:DropDownList ID="ddlDias" runat="server" CssClass="btn btn-secondary btn-block" Height="40px"></asp:DropDownList>
                    </div>
                    <div class="col-xs-12 col-md-6 text-md-center text-xs-center m-b-3">
                        <asp:Label ID="Label7" runat="server" Text="Selecciona el horario de tu preferencia " CssClass="lbl hidden-sm-down"></asp:Label>
                         <asp:Label ID="Label11" runat="server" Text="Horario:" CssClass="lbl hidden-md-up"></asp:Label>
                        <asp:DropDownList ID="ddlHorarios" runat="server" CssClass="btn btn-secondary btn-block" Height="40px"></asp:DropDownList>
                    </div>
                    <div class="row col-md-12 text-md-center m-x-auto flex-items-xs-center m-b-2">

                        <div class="col-xs-12 col-md-4 text-md-center text-xs-center m-b-3 m-t-2">
                            <asp:Label ID="Label4" runat="server" Text="Nombre (Completo): " CssClass="lbl"></asp:Label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" ToolTip="Ej: Nombre Apellido Apellido"></asp:TextBox>
                        </div>
                        <div class="col-xs-12 col-md-4 text-md-center text-xs-center m-b-3 m-t-2">
                            <asp:Label ID="Label5" runat="server" Text="Correo (Electronico):" CssClass="lbl"></asp:Label>
                            <asp:TextBox ID="txtxCorreo" runat="server" CssClass="form-control" TextMode="Email" ToolTip="Ej: mail@mail.com"></asp:TextBox>
                        </div>
                        <div class="col-xs-12 col-md-4 text-md-center text-xs-center m-b-3 m-t-2">
                            <asp:Label ID="Label6" runat="server" Text="Telefono (Opcional): " CssClass="lbl"></asp:Label>
                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" TextMode="Phone"></asp:TextBox>
                        </div>
                        <asp:Button ID="btnCotizar" runat="server" Text="Enviar" OnClick="btnCotizar_Click" CssClass="btn btn-primary btn-block col-xs-12 col-sm-12 col-md-3 m-t-2" />
                         <div class="col-md-1 hidden-sm-down"></div>
                         <button type="reset" class="btn btn-secondary btn-block col-xs-12 col-sm-12 col-md-3 m-t-2 ">Limpiar</button>
                    </div>
                </div>
	               </ContentTemplate>
        </asp:UpdatePanel>
                 </form>
        </div>
       </main>

    <footer class="piedepagina p-y-1" role="contentinfo">
        <!--<div>Icons made by <a href="https://www.flaticon.com/authors/maxim-basinski" title="Maxim Basinski">Maxim Basinski</a> from <a href="https://www.flaticon.com/" title="Flaticon">www.flaticon.com</a> is licensed by <a href="http://creativecommons.org/licenses/by/3.0/" title="Creative Commons BY 3.0" target="_blank">CC 3.0 BY</a></div>-
       <div>Iconos diseñados por <a href="https://www.flaticon.es/autores/vectors-market" title="Vectors Market">Vectors Market</a> desde <a href="https://www.flaticon.es/" title="Flaticon">www.flaticon.com</a> con licencia <a href="http://creativecommons.org/licenses/by/3.0/" title="Creative Commons BY 3.0" target="_blank">CC 3.0 BY</a></div>
       -->
        <div class="container">

            <ul class="row redes-sociales col-md-12 p-b-2 mx-auto">
                <li class="col-xs-12"><a href="https://www.facebook.com/globalcollegemonterrey/"><i class="fa fa-facebook" aria-hidden="false"></i>acebook </a></li>
                <li class="col-xs-12"><a href="tel:018126809469" data-scroll><i class="fa fa-phone" aria-hidden="false"></i>01 81 2680 9469</a></li>
                <li class="col-xs-12 hidden-xs-down"><a href="mailto:robertovega@globalcollegemonterrey.com" data-scroll style="align-items: stretch"><i class="fa fa-envelope" aria-hidden="false"></i>robertovega@globalcollegemonterrey.com </a></li>

                <li class="col-xs-12 hidden-sm-up"><a href="mailto:robertovega@globalcollegemonterrey.com" data-scroll style="align-items: stretch"><i class="fa fa-envelope hidden-sm-down" aria-hidden="false"></i>robertovega</a></li>
                <li class="col-xs-12 hidden-sm-up"><a href="mailto:robertovega@globalcollegemonterrey.com" data-scroll style="align-items: stretch"><i class="fa fa-envelope hidden-sm-down" aria-hidden="false"></i>@globalcollege </a></li>
                <li class="col-xs-12 hidden-sm-up"><a href="mailto:robertovega@globalcollegemonterrey.com" data-scroll style="align-items: stretch"><i class="fa fa-envelope hidden-sm-down" aria-hidden="false"></i>monterrey.com </a></li>


                <!--         <li><a href="#"><i class="fa fa-twitter" aria-hidden="true"></i> </a></li>
                <li><a href="#"><i class="fa fa-youtube" aria-hidden="true"></i> </a></li> -->
            </ul>

            <p>2017 - 2018 © <a href="../Index.html" class="card-link">GLOBAL COLLEGE</a> Todos los derechos reservados</p>

        </div>

    </footer>

    <a data-scroll class="ir-arriba" href="#encabezado"><i class="fa  fa-arrow-circle-up" aria-hidden="true"></i></a>

    <!-- Carga de archivos  JS -->

    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/owl.carousel.min.js"></script>
    <script type="text/javascript">
        $('.owl-carousel').owlCarousel({
            loop: true,
            margin: 0,
            nav: true,
            autoWidth: false,
            navText: ['<i class="fa fa-arrow-circle-left" title="Anterior"></i>', '<i class="fa  fa-arrow-circle-right" title="Siguiente"></i>'],
            responsive: {
                0: {
                    items: 1
                },
                500: {
                    items: 2,
                    margin: 20
                },
                800: {
                    items: 3,
                    margin: 20
                },
                1000: {
                    items: 4,
                    margin: 20
                }
            }
        })

    </script>
    <script src="js/wow.min.js"></script>
    <script src="js/smooth-scroll.min.js"></script>
    <script src="js/sitio.js"></script>


</body>
</html>
