$(document).ready( function () {
    $('#Tabla').DataTable();
  } );
  
  
    $("#btnCalcular").click(function(){
          
      var texto  = $("#txtarreglo").val();
      var arreglo =  texto.split('$');
      var mayor = 0;
      var menor = 0;
      var arr = arreglo.sort((a,b) => a-b);
      var x = false;

      if(texto == ""){
        iziToast.warning({title: 'Advertencia' ,message: 'Ingrese el arreglo',})
        x = true;
      }

      if(x == false){
      menor = arr[0];
      mayor = arr[arr.length-1];
   
      cadena = "<tr>"
      cadena += "<th>" + "" +"</th>";
      cadena += "<td>" + mayor + "</td>"
      cadena += "<td>" + menor + "</td>"
      $("#Tabla").append(cadena);
      $("#txtarreglo").val("");
      iziToast.success({title:'Registrado',message: 'Agregado Correctamente',});
      $('#exampleModal').modal("hide");
        }
      })
  
    $('#modal').click(function () {
  $('#exampleModal').modal("show");
  })
  
    $('#hidemodal').click(function () {
  $('#exampleModal').modal("hide");
  })
  