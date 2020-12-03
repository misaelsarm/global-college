function MantenSesion()

{                

    var CONTROLADOR = "SessionTimer.ashx";

    var head = document.getElementsByTagName('head').item(0);            

    script = document.createElement('script');            

    script.src = CONTROLADOR ;

    script.setAttribute('type', 'text/javascript');

    script.defer = true;

    head.appendChild(script);
} 
