$(document).ready( function () {
    $('#Tabla').DataTable();
  } );
  
  
    $("#btnCalcular").click(function(){
        var numero = $("#txtnumero").val();
        var procedimiento = "";
        var resultado = 1;
        var x = false;

        if(numero == ""){
          iziToast.warning({title: 'Advertencia',message:'Ingrese el numero',})
          x = true;
        }
       
        if(x == false){
        for(i = 1; i <= numero; i++){
           resultado = resultado * i;
           
           if(i == numero){
            procedimiento +=   i+""
           }else
           procedimiento +=   i+"x"
        }

        cadena = "<tr>"
        cadena += "<th>" + "" +"</th>";
        cadena += "<td>" + numero + "</td>"
        cadena += "<td>" + procedimiento + "</td>"
        cadena += "<td>" + resultado + "</td>"
        $("#Tabla").append(cadena);
        $("#txtnumero").val("");
        iziToast.success({title: 'Registrado',message:'Agregado Correctamente',})
      }

      $('#exampleModal').modal("hide");
      })
  
    $('#modal').click(function () {
  $('#exampleModal').modal("show");
  })
  
    $('#hidemodal').click(function () {
  $('#exampleModal').modal("hide");
  })
  