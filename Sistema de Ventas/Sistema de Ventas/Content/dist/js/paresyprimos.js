$(document).ready( function () {
    $('#Tabla').DataTable();
  } );
  
  
    $("#btnCalcular").click(function(){
        var texto  = $("#txtarreglo").val();
        var arreglo =  texto.split('$');
        var pares = "";
        var primos = "";
        var na = "";
        var divisiones = 0;
        var x = false;

        if(texto == ""){
            iziToast.warning({title: 'Advertencia' ,message: 'Ingrese el arreglo',})
            x = true
        }
        
        if(x == false){
        $.each(arreglo, function(index, value){

          for(i = 0; i <= value; i++){
             if(value % i == 0){
                divisiones++; 
             }

             if(i == value){
                if(divisiones > 2){
                }else{
                    primos += " " + value + ",";
                }
             }
          }
          
          if(value % 2 == 0){
            pares += " " + value + ","; 
          }
          
          });
          cadena = "<tr>"
          cadena += "<th>" + "" +"</th>";
          cadena += "<td>" + pares + "</td>"
          cadena += "<td>" + primos + "</td>"
          cadena += "<td>" + na + "</td>"
          $("#Tabla").append(cadena);
          $("#txtarreglo").val("");
          iziToast.success({title:'Registrado',message: 'Agregado Correctamente',})
          $('#exampleModal').modal("hide");
        }

      })
  
    $('#modal').click(function () {
  $('#exampleModal').modal("show");
  })
  
    $('#hidemodal').click(function () {
  $('#exampleModal').modal("hide");
  })
  