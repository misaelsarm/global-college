(function ($) {
    $('#submit').click(function (e) {
      //evitamos la carga de la página
        e.preventDefault();
      //recogemos el id del formulario a enviar
        var form = $(this).attr('form-id');
      //llamamos a la función que contendrá el llamado ajax dándole como argumento el id del formulario
        submitForm(form);
    });
});

//fuera de la carga de la página, creamos la función que recibe el id del formulario a enviar.

function submitForm (form) {
   //recogemos el "action" a donde se enviarán los datos mediante "POST" 
    var action = $("form#" + form).attr("action");
   //ahora recogemos los datos de los controles que hayamos definido y los serializamos como un formulario con Javascript
    var datos = $('form#' + form).serialize();
   
   //enviamos los datos mediante Ajax con la función de Jquery que nos facilita esta tarea
   
    $.ajax({
      //url a enviar
        url: 'mail.php',
      //el tipo GET o POST en nuestro caso POST
        type: 'POST',
      //evitamos el cacheo de los datos
        cache: false,
      //evitamos que el JS procese los datos
        proccessData: false,
      //definimos los datos a enviar, nosotros ya los tenemos definidos en la variable "datos"
        data: datos
    });
}
