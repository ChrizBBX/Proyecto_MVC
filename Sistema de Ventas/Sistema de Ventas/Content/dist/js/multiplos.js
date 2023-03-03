$(document).ready( function () {
    $('#Tabla').DataTable();
  } );
  
  
    $("#btnCalcular").click(function(){
          
      var texto  = $("#txtarreglo").val();
      var arreglo =  texto.split('$');
      var multiplo3 = "";
      var multiplo5 = "";
      var na = "";
      var x = false;

      if(texto == ""){
        iziToast.warning({title: 'Advertencia' ,message: 'Ingrese el arreglo',})
        x = true;
      }

      if(x == false){
      $.each(arreglo, function(index, value){
       
        if(value % 3 == 0){
            multiplo3 = value;
        }else{
            multiplo3 = "x"
        }

        if(value % 5 == 0){
            multiplo5 = value;
        }else{
            multiplo5 = "x"
        }

       if(multiplo3 == "x" && multiplo5 =="x"){
        na = value;
       }

        cadena = "<tr>"
        cadena += "<th>" + "" +"</th>";
        cadena += "<td>" + multiplo3 + "</td>"
        cadena += "<td>" + multiplo5 + "</td>"
        cadena += "<td>" + na + "</td>"
        $("#Tabla").append(cadena);
      })
      iziToast.success({title:'Registrado',message: 'Agregado Correctamente',});
      $("#txtarreglo").val("");
      $("#exampleModal").modal("hide");
    }
      })
  
    $('#modal').click(function () {
  $('#exampleModal').modal("show");
  })
  
    $('#hidemodal').click(function () {
  $('#exampleModal').modal("hide");
  })
  