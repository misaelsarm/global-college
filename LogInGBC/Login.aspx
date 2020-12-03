<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>GLOBAL COLLEGE MONTERREY | LOGIN</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta http-equiv="x-ua-compatible" content="ie=edge">
    <link rel="shortcut icon" type="image/x-icon" href="favicon.png">
    <!-- Required meta tags always come first -->
    <meta name="description" content="Servicios Profesionales, Servicios de Metrología en Monterrey" />
    <meta charset="utf-8">
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
    <link href="css/LoginCSS.css" rel="stylesheet" />
</head>
<body>
    <section class="bienvenidos">

  
        <header class="encabezado navbar-fixed-top" role="banner" id="encabezado">
            <div class="container">
                <a href="../index.html" class="logo">
                    <img src="images/LogoBlancoSmallH.png" alt="Logo">
                </a>

               

                <nav id="menu-principal" class="collapse">
                    <ul>
                        <li><a href="../Index.html" data-scroll>Inicio</a></li>
                        <li><a href="../Index.html#escuela" data-scroll>Nosotros</a></li>
                        <li><a href="../Index.html#servicios" data-scroll>Servicios</a></li>
                        <li><a href="Cotizador.aspx" data-scroll>Cotización</a></li>
                        <li  class="active"><a href="Login.aspx" data-scroll>Login</a></li>
                        <!--<li><a href="#contacto" data-scroll>Contacto</a></li>-->
                        <!--<li><a href="cotizacion.html" data-scroll>Cotización</a></li>-->
                    </ul>
                </nav>

            </div>
        </header>
    </section>

    <form id="form1" runat="server" class="form-signin ">
        <img class="mb-4" src="images/MundoAzulSolo.png" alt="Logo" width="115" height="100">
        <h1 class="h3 m-b-1  m-t-0 font-weight-normal">Inicio de Sesión</h1>
        <label for="inputEmail" class="sr-only">Email address</label>
        <asp:TextBox ID="inputUser" runat="server" class="form-control" placeholder="Usuario" required autofocus></asp:TextBox>
        <label for="inputPassword" class="sr-only">Password</label>
        <asp:TextBox ID="inputPassword" runat="server" class="form-control" placeholder="Contraseña" required TextMode="Password"></asp:TextBox>
        <div class=" mb-3">
            <label>
                <asp:DropDownList ID="ddlrol" runat="server" CssClass="btn btn-secondary btn-block" Width="100%">
                </asp:DropDownList>
            </label>
        </div>
        <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesión" class="btn btn-lg btn-primary btn-block" OnClick="Button1_Click" />

    </form>
    <footer class="piedepagina p-y-2 m-t-0 navbar-fixed-bottom" role="contentinfo">
        <!--<div>Icons made by <a href="https://www.flaticon.com/authors/maxim-basinski" title="Maxim Basinski">Maxim Basinski</a> from <a href="https://www.flaticon.com/" title="Flaticon">www.flaticon.com</a> is licensed by <a href="http://creativecommons.org/licenses/by/3.0/" title="Creative Commons BY 3.0" target="_blank">CC 3.0 BY</a></div>-
       <div>Iconos diseñados por <a href="https://www.flaticon.es/autores/vectors-market" title="Vectors Market">Vectors Market</a> desde <a href="https://www.flaticon.es/" title="Flaticon">www.flaticon.com</a> con licencia <a href="http://creativecommons.org/licenses/by/3.0/" title="Creative Commons BY 3.0" target="_blank">CC 3.0 BY</a></div>
       -->
        <div class="container">
                       <p>2017 - 2018 © <a href="../Index.html" class="card-link m-t-2">GLOBAL COLLEGE</a> Todos los derechos reservados</p>

            <ul class="row redes-sociales">
                <!--<li class="col-md-6 col-sm-4"><a href="https://www.facebook.com/globalcollegemonterrey/"> <i class="fa fa-facebook" aria-hidden="false"></i>acebook </a> </li>-->
                <!--<li class="col-md-6 col-sm-8"><a href="!#"><i class="fa fa-phone" aria-hidden="false"></i> 01 81 2680 9469</a></li>-->
                <!-- <li class="col-md-4"><a href="!#"><i class="fa fa-envelope" aria-hidden="false"></i> @globalcollegemonterrey </a></li>-->
                <!--         <li><a href="#"><i class="fa fa-twitter" aria-hidden="true"></i> </a></li>
                <li><a href="#"><i class="fa fa-youtube" aria-hidden="true"></i> </a></li> -->
            </ul>

        </div>

    </footer>

    <a data-scroll class="ir-arriba" href="#encabezado"><i class="fa  fa-arrow-circle-up" aria-hidden="true"></i></a>

    <!-- Carga de archivos  JS -->
    <script src="js/popper.min.js"></script>
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
