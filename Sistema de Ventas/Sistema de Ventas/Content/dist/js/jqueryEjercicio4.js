$(document).ready( function () {
  $('#Tabla').DataTable();
} );

$("#modaltrigger").click(function(){
  $("#modal").modal("show");
})

        $("#btnsuma").click(function(){
            var Numero1 = $("#txtnumero1").val();
            var Numero2 = $("#txtnumero2").val();
            var resultado = parseInt(Numero1) + parseInt(Numero2);
            var operacion = "Suma";
            var x = "0"
            if(Numero1 == ""){
              iziToast.warning({title: 'Advertencia',message: 'Ingrese el numero 1',});
              x = "1";
            }

            if(Numero2 == ""){
              iziToast.warning({title: 'Advertencia',message: 'Ingrese el numero 2',});
              x = "1";
            }

            if(x == "0"){
              cadena = "<tr>"
            cadena += "<th>" + "" +"</th>";
            cadena += "<td>" + Numero1 + "</td>"
            cadena += "<td>" + Numero2 + "</td>"
            cadena += "<td>" + operacion + "</td>"
            cadena += "<td>" + resultado + "</td>"
            $("#Tabla").append(cadena);
            iziToast.success({
              title: 'Agregado',
             message: 'Registro agregado correctamente',
              });   
            $("#txtnumero1").val("");
            $("#txtnumero2").val("");
            $("#modal").modal("hide");
            }

        })

        $("#btndivision").click(function(){
          var Numero1 = $("#txtnumero1").val();
          var Numero2 = $("#txtnumero2").val();
          var resultado = parseInt(Numero1) / parseInt(Numero2);
          var operacion = "Division";
          var x = "0"
          if(Numero1 == ""){
            iziToast.warning({title: 'Advertencia',message: 'Ingrese el numero 1',});
            x = "1";
          }else if(Numero1 == "0"){
            iziToast.warning({title: 'Advertencia',message: 'No se puede dividir entre 0',});
            x = "1";
          }

          if(Numero2 == ""){
            iziToast.warning({title: 'Advertencia',message: 'Ingrese el numero 2',});
            x = "1";
          }else if(Numero1 == "0"){
            iziToast.warning({title: 'Advertencia',message: 'No se puede dividir entre 0',});
            x = "1";
          }

          if(x == "0"){
            cadena = "<tr>"
          cadena += "<th>" + "" +"</th>";
          cadena += "<td>" + Numero1 + "</td>"
          cadena += "<td>" + Numero2 + "</td>"
          cadena += "<td>" + operacion + "</td>"
          cadena += "<td>" + resultado + "</td>"
          $("#Tabla").append(cadena);
          iziToast.success({
            title: 'Agregado',
           message: 'Registro agregado correctamente',
            });   
          $("#txtnumero1").val("");
          $("#txtnumero2").val("");
          $("#modal").modal("hide");
          }
        })

        $("#btnresta").click(function(){
          var Numero1 = $("#txtnumero1").val();
          var Numero2 = $("#txtnumero2").val();
          var resultado = parseInt(Numero1) - parseInt(Numero2);
          var operacion = "Resta";
          var x = "0"
          if(Numero1 == ""){
            iziToast.warning({title: 'Advertencia',message: 'Ingrese el numero 1',});
            x = "1";
          }

          if(Numero2 == ""){
            iziToast.warning({title: 'Advertencia',message: 'Ingrese el numero 2',});
            x = "1";
          }

          if(x == "0"){
            cadena = "<tr>"
          cadena += "<th>" + "" +"</th>";
          cadena += "<td>" + Numero1 + "</td>"
          cadena += "<td>" + Numero2 + "</td>"
          cadena += "<td>" + operacion + "</td>"
          cadena += "<td>" + resultado + "</td>"
          $("#Tabla").append(cadena);
          iziToast.success({
            title: 'Agregado',
           message: 'Registro agregado correctamente',
            });   
          $("#txtnumero1").val("");
          $("#txtnumero2").val("");
          $("#modal").modal("hide");
          }
        })

        $("#btnmultiplicacion").click(function(){
          var Numero1 = $("#txtnumero1").val();
          var Numero2 = $("#txtnumero2").val();
          var resultado = parseInt(Numero1) * parseInt(Numero2);
          var operacion = "Multiplicacion";
          var x = "0"
          if(Numero1 == ""){
            iziToast.warning({title: 'Advertencia',message: 'Ingrese el numero 1',});
            x = "1";
          }

          if(Numero2 == ""){
            iziToast.warning({title: 'Advertencia',message: 'Ingrese el numero 2',});
            x = "1";
          }

          if(x == "0"){
            cadena = "<tr>"
          cadena += "<th>" + "" +"</th>";
          cadena += "<td>" + Numero1 + "</td>"
          cadena += "<td>" + Numero2 + "</td>"
          cadena += "<td>" + operacion + "</td>"
          cadena += "<td>" + resultado + "</td>"
          $("#Tabla").append(cadena);
          iziToast.success({
            title: 'Agregado',
           message: 'Registro agregado correctamente',
            });   
          $("#txtnumero1").val("");
          $("#txtnumero2").val("");
          $("#modal").modal("hide");
          }
        })