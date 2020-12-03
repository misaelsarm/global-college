<%@ Page Title="" Language="C#" MasterPageFile="~/Maestros.master" AutoEventWireup="true" CodeFile="ClasesM.aspx.cs" Inherits="ClasesM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="bienvenidos">

        <header class="encabezado navbar-fixed-top" role="banner" id="encabezado">
            <div class="container">
                <a href="index.html" class="logo">
                    <img src="images/LogoBlancoSmallH.png" alt="Logo" />
                </a>


                <nav id="menu-principal" class="collapse">
                    <ul>
                        <li class="active"><a href="#" data-scroll>Clases</a></li>
                        <li><a href="EssentialSoundsm.aspx" data-scroll>Essential Sounds ©</a></li>
                        <li><a href="Login.aspx" data-scroll>Cerrar Sesión</a></li>
                    </ul>
                </nav>

            </div>
        </header>
    </section>
    <section class="MaterialesM m-x-auto" style="min-height: 63vh">
        <div class="row col-md-12 flex-items-md-middle">
            <div class="row col-md-12 text-md-center m-x-auto flex-items-xs-center m-b-3">
                <div class="col-md-4 text-md-center text-xs-center">
                    <asp:Label ID="Label1" runat="server" Text="Mis Clases:" CssClass="lbl"></asp:Label>
                    <asp:DropDownList ID="ddlclasesm" runat="server" CssClass="btn btn-secondary btn-block" Height="38px">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row col-md-12 text-md-center m-x-auto flex-items-xs-center m-b-3">
                <asp:Button ID="btnverclase" runat="server" Text="Ver material" CssClass="btn btn-primary btn-block col-sm-12 col-md-3 m-t-2" OnClick="btnverclase_Click" />
            </div>
            <div class="row col-md-12 text-md-center m-x-auto flex-items-xs-center m-b-3" id="videoyt" style="height:55vh;">
                <asp:Label ID="lblvideo" runat="server" Text="" CssClass="col-xs-12 col-md-6"></asp:Label>
            </div>
    </section>
</asp:Content>

