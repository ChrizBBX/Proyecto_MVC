$(document).ready( function () {
  $('#Tabla').DataTable();
} );


    $("#modal").click(function(){
    $("#exampleModal").modal("show");
})

$("#hidemodal").click(function(){
    $("#exampleModal").modal("hide");
})

      var cadena;
        $("#btnCalcular").click(function(){
         var nombres = $("#txtnombres").val();
         var Apellidos = $("#txtapellidos").val();
         var promedio = $("#txtpromedio").val();
         var x = "0";

        if(nombres == ""){
          iziToast.warning({title: 'Advertencia',message: 'Ingrese el nombre',});
            x = "1"
         }
         if(Apellidos == ""){
          iziToast.warning({title: 'Advertencia',message: 'Ingrese el apellido',});
            x = "1"
         }
         if(promedio == ""){
          iziToast.warning({title: 'Advertencia',message: 'Ingrese el promedio',});
            x = "1"
         } else
         if(promedio >10){
          iziToast.warning({title: 'Advertencia',message: 'El promedio tiene que ser de 1 a 10',});
            x = "1"
         }

         if(x=="0"){
        if(promedio >0 && promedio <4){
            var calificacion = "Muy Deficiente";
        }
        if(promedio >2 && promedio <6){
            var calificacion = "Insuficiente";
        }
        if(promedio >4 && promedio <7){
            var calificacion = "Suficiente";
        }
        if(promedio >5 && promedio <8){
            var calificacion = "Bien";
        }
        if(promedio >6 && promedio <10){
            var calificacion = "Notable";
        }
        if(promedio >8 && promedio < 11){
            var calificacion = "Sobresaliente";
        }

        cadena = "<tr>"
            cadena += "<td>" + nombres + "</td>"
            cadena += "<td>" + Apellidos + "</td>"
            cadena += "<td>" + promedio + "</td>"
            cadena += "<td>" + calificacion + "</td>"
            $("#Tabla").append(cadena);
            iziToast.success({
              title: 'Agregado',
             message: 'Registro agregado correctamente',
              });   
    }
         $("#txtnombres").val("");
         $("#txtapellidos").val("");
         $("#txtpromedio").val("");

    
    $("#exampleModal").modal("hide");

        })
