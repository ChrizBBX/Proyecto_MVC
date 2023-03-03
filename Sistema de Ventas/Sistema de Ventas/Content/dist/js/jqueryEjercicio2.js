$(document).ready( function () {
  $('#Tabla').DataTable();
} )

$("#modal").click(function(){
    $("#exampleModal").modal("show");
})

$("#hidemodal").click(function(){
    $("#exampleModal").modal("hide");
})

  var cadena;
        $("#btnCalcular").click(function(){
         var nombre = $("#txtnombre").val();
         var Apellido = $("#txtapellido").val();
         var Edad = $("#txtedad").val();
         var x = "0";

         var sexo = $("input:radio[name=sexo]:checked").val();
         var Nota1 = $("#txtnota1").val();
         var Nota2 = $("#txtnota2").val();
         var Nota3 = $("#txtnota3").val();

         if(nombre == ""){
          iziToast.warning({title: 'Advertencia',message: 'Ingrese el nombre',});
            x = "1";
         }
         if(Apellido == ""){
          iziToast.warning({title: 'Advertencia',message: 'Ingrese el apellido',});
            x = "1";
         }if(Edad == ""){
          iziToast.warning({title: 'Advertencia',message: 'Ingrese la edad',});
            x = "1";
         }
         if(Nota1 == ""){
          iziToast.warning({title: 'Advertencia',message: 'Ingrese la nota 1',});
         }
         if(Nota2 == ""){
          iziToast.warning({title: 'Advertencia',message: 'Ingrese la nota 2',});
         }if(Nota3 == ""){
          iziToast.warning({title: 'Advertencia',message: 'Ingrese la nota 3',});
         }

         var promedio = (parseInt(Nota1) + parseInt(Nota2)  + parseInt(Nota3) ) / 3;

         if(x == "0"){
         if(promedio>69){
            var cadena = "Aprobado"
         }else{
            var cadena = "Reprobado"
         }

         cadena = "<tr>"
            cadena += "<th>" + "" +"</th>";
            cadena += "<td>" + nombre + "</td>"
            cadena += "<td>" + Apellido + "</td>"
            cadena += "<td>" + Edad + "</td>"
            cadena += "<td>" + sexo + "</td>"
            cadena += "<td>" + Nota1 + "</td>"
            cadena += "<td>" + Nota2 + "</td>"
            cadena += "<td>" + Nota3 + "</td>"
            $("#Tabla").append(cadena);
            iziToast.success({
              title: 'Agregado',
             message: 'Registro agregado correctamente',
              });   

         $("#txtnombre").val("");
         $("#txtapellido").val("");
         $("#txtedad").val("");
         $("#rbtnmasculino").attr("checked",false);
         $("#rbtnfemenino").attr("checked",false);
         $("#txtnota1").val("");
         $("#txtnota2").val("");
         $("#txtnota3").val("");
         $("#exampleModal").modal("hide");
        }
        })