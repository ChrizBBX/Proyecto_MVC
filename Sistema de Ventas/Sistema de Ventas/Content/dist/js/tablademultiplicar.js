$(document).ready( function () {
    $('#Tabla').DataTable();
  } );
  
  
    $("#btnCalcular").click(function(){
          var numero = $("#txtnumero").val();
          var fin = $("#txtfin").val();
          var resultado = "";
          var x = false;

          if(numero == ""){
            iziToast.warning({title: 'Advertencia',message: 'Ingrese el numero',})
            x = true;
          }
          if(fin == ""){
            iziToast.warning({title: 'Advertencia',message: 'Ingrese el rango',})
            x = true;
          }

          if(x == false){
          for(i = 0 ; i <= fin; i++){
            resultado = numero + " x " + i + " = " + (numero*i);
        
        cadena = "<tr>"
        cadena += "<th>" + "" +"</th>";
        cadena += "<td>" + "0-" + fin + "</td>"
        cadena += "<td>" + resultado + "</td>"
        $("#Tabla").append(cadena);  
            $("#txtnumero").val("");
            $("#txtfin").val("");
          }
          iziToast.success({title: 'Registrado',message: "Registrado Agregado con exito",}); 
          $('#exampleModal').modal("hide");
          }
      })
  
    $('#modal').click(function () {
  $('#exampleModal').modal("show");
  })
  
    $('#hidemodal').click(function () {
  $('#exampleModal').modal("hide");
  })
  