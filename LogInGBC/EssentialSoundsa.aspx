<%@ Page Title="" Language="C#" MasterPageFile="~/AlumnosMaster.master" AutoEventWireup="true" CodeFile="EssentialSoundsa.aspx.cs" Inherits="EssentialSounds" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="js/GBCESRP.js">
 
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!--<section class="txteswb m-x-auto">
        <div class="row col-md-12 flex-items-md-middle">
            <p class="col-sm-6 text-xs-center display-4"> Essential Sounds</i></p>
        </div>
    </section>-->
    <section class="bienvenidos">

        <header class="encabezado navbar-fixed-top" role="banner" id="encabezado">
            <div class="container">
                <a href="http://www.globalcollegemonterrey.com" class="logo">
                    <img src="images/LogoBlancoSmallH.png" alt="Logo" />
                </a>



                <nav id="menu-principal" class="collapse hidden-xs-down">
                    <ul>
                        <li><a href="ClasesA.aspx" data-scroll>Mis Clases</a></li>
                        <li class="active"><a href="#escuela" data-scroll>Esssential Sounds</a></li>
                        <li><a href="Login.aspx" data-scroll>Cerrar Sesión</a></li>
                    </ul>
                </nav>

            </div>
        </header>
    </section>

﻿

    <section class="EssentialSounds m-x-auto">
        <div class="row col-md-12 flex-items-md-middle">
            <div class="as col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/1.jpg" alt="1" onclick="PLESSA1()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/2.jpg" alt="2" onclick="PLESSA2()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/3.jpg" alt="3" onclick="PLESSA3()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/4.jpg" alt="4" onclick="PLESSA4()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/5.jpg" alt="5" onclick="PLESSA5()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/6.jpg" alt="6" onclick="PLESSA6()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/7.jpg" alt="7" onclick="PLESSA7()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/8.jpg" alt="8" onclick="PLESSA8()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/9.jpg" alt="9" onclick="PLESSA9()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/10.jpg" alt="10" onclick="PLESSA10()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/11.jpg" alt="11" onclick="PLESSA11()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/12.jpg" alt="12" onclick="PLESSA12()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/13.jpg" alt="13" onclick="PLESSA13()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/141.jpg" alt="14" onclick="PLESSA141()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/142.jpg" alt="14" onclick="PLESSA142()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/15.jpg" alt="15" onclick="PLESSA15()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/16.jpg" alt="16" onclick="PLESSA16()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/17.jpg" alt="17" onclick="PLESSA17()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/18.jpg" alt="18" onclick="PLESSA18()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/19.jpg" alt="19" onclick="PLESSA19()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/20.jpg" alt="20" onclick="PLESSA20()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/21.jpg" alt="21" onclick="PLESSA21()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/22.jpg" alt="22" onclick="PLESSA22()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/23.jpg" alt="23" onclick="PLESSA23()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/24.jpg" alt="24" onclick="PLESSA24()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/25.jpg" alt="25" onclick="PLESSA25()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/26.jpg" alt="26" onclick="PLESSA26()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/27.jpg" alt="27" onclick="PLESSA27()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/28.jpg" alt="28" onclick="PLESSA28()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/29.jpg" alt="29" onclick="PLESSA29()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/30.jpg" alt="30" onclick="PLESSA30()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/31.jpg" alt="31" onclick="PLESSA31()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/32.jpg" alt="32" onclick="PLESSA32()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/33.jpg" alt="33" onclick="PLESSA33()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/34.jpg" alt="34" onclick="PLESSA34()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/35.jpg" alt="35" onclick="PLESSA35()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/36.jpg" alt="36" onclick="PLESSA36()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/37.jpg" alt="37" onclick="PLESSA37()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/38.jpg" alt="38" onclick="PLESSA38()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/39.jpg" alt="39" onclick="PLESSA39()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/40.jpg" alt="40" onclick="PLESSA40()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/41.jpg" alt="41" onclick="PLESSA41()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/42.jpg" alt="42" onclick="PLESSA42()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/43.jpg" alt="43" onclick="PLESSA43()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/44.jpg" alt="44" onclick="PLESSA44()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/45.jpg" alt="45" onclick="PLESSA45()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/46.jpg" alt="46" onclick="PLESSA46()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/47.jpg" alt="47" onclick="PLESSA47()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/48.jpg" alt="48" onclick="PLESSA48()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/49.jpg" alt="49" onclick="PLESSA49()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/50.jpg" alt="50" onclick="PLESSA50()" />
            </div>
            <div class="col-md-3 col-sm-6 text-md-center text-xs-center m-t-2">
                <img class="essentials" src="GBCESRP/fwdessentialimages/51.jpg" alt="51" onclick="PLESSA51()" />
            </div>
        </div>
    </section>
</asp:Content>

