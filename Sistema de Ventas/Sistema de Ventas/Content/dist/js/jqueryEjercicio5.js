 $(document).ready( function () {
  $('#Tabla').DataTable();
} );

$("#modaltrigger").click(function(){
    $("#modal").modal("show");
})
      var cadena;
        $("#btnCalcular").click(function(){
            var Numero1 = $("#txtnumero1").val();
            var Numero2 = $("#txtnumero2").val();
            var x = "0";
            
            if(parseInt(Numero1) == parseInt(Numero2)){
              iziToast.warning({title: 'Advertencia',message: 'Los numeros son iguales',});
              x = "1";
            }

            if(Numero1 == ""){
                iziToast.warning({title: 'Advertencia',message: 'Ingrese el primer numero',});
                x = "1";
            }

            if(Numero2 == ""){
                iziToast.warning({title: 'Advertencia',message: 'Ingrese el segundo numero',});
                x = "1";
            }
            
            if(x == "0"){
            if(parseInt(Numero1) > parseInt(Numero2)){
              iziToast.success({
              title: 'Resultado',
             message: Numero1 + " mayor que " + Numero2,
              });   
              cadena = "<tr>";
            cadena += "<th>" + "" +"</th>";
            cadena += "<td>" + Numero1 + "</td>"
            cadena += "<td>" + Numero2 + "</td>"
            cadena += "<td>" + Numero1 + "</td>"
            cadena += "<td>" + Numero2 + "</td>"
            $("#Tabla").append(cadena);  
            }else{
              iziToast.success({
              title: 'Resultado',
             message: Numero2 + " mayor que " + Numero1,
              });   
              cadena = "<tr>";
            cadena += "<th>" + "" +"</th>";
            cadena += "<td>" + Numero1 + "</td>"
            cadena += "<td>" + Numero2 + "</td>"
            cadena += "<td>" + Numero2 + "</td>"
            cadena += "<td>" + Numero1 + "</td>"
            $("#Tabla").append(cadena);  
            }
            $("#txtnumero1").val("");
            $("#txtnumero2").val("");
            $("#modal").modal("hide");
        }
        })

    
