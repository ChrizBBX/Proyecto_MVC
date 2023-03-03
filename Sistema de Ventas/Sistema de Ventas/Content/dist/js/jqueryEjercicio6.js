$(document).ready(function(){
    $("#Tabla").DataTable();
})

$("#modaltrigger").click(function(){
    $("#modal").modal("show");
})

var cadena;
  $("#btnCalcular").click(function(){
      var Numero1 = $("#txtnumero1").val();
      var Numero2 = $("#txtnumero2").val();
      var Numero3 = $("#txtnumero3").val();
      var x = "0";
      
      if(parseInt(Numero1) == parseInt(Numero2) && parseInt(Numero1) == parseInt(Numero3)){
        iziToast.warning({title: 'Advertencia',message: 'Los numeros son iguales',});
        x = "1";
      }
      else if(parseInt(Numero1) == parseInt(Numero2)){
        iziToast.warning({title: 'Advertencia',message: Numero1 + " Igual que " + Numero2,});
        x = "1";
      }else if(parseInt(Numero1) == parseInt(Numero3)){
        iziToast.warning({title: 'Advertencia',message: Numero1 + " Igual que " + Numero3,});
        x = "1";
      }else if(parseInt(Numero3) == parseInt(Numero2)){
        iziToast.warning({title: 'Advertencia',message: Numero3 + " Igual que " + Numero2,});
        x = "1";
      } 

      if(Numero1 == ""){
        iziToast.warning({title: 'Advertencia',message: 'Ingrese el numero 1',});
        x = "1";
      }
      
      if(Numero2 == ""){
        iziToast.warning({title: 'Advertencia',message: 'Ingrese el numero 2',});
        x = "1";
      }

      if(Numero3 == ""){
        iziToast.warning({title: 'Advertencia',message: 'Ingrese el numero 3',});
        x = "1";
      }

      if(parseInt(Numero1) > parseInt(Numero2) & parseInt(Numero1) > parseInt(Numero3)){
          var mayor = Numero1;
          if(parseInt(Numero2) > parseInt(Numero3)){
          var enmedio = Numero2;
          var menor = Numero3;
      }else{
        var enmedio = Numero3;
        var menor = Numero2;
      }
      }

      if(parseInt(Numero2) > parseInt(Numero1) & parseInt(Numero2) > parseInt(Numero3)){
          var mayor = Numero2;
          if(parseInt(Numero1) > parseInt(Numero3)){
          var enmedio = Numero1;
          var menor = Numero3;
      }else{
        var enmedio = Numero3;
        var menor = Numero1;
      }
      }

      if(parseInt(Numero3) > parseInt(Numero1) & parseInt(Numero3) > parseInt(Numero2)){
          var mayor = Numero3;
          if(parseInt(Numero2) > parseInt(Numero1)){
          var enmedio = Numero2;
          var menor = Numero1;
      }else{
        var enmedio = Numero1;
        var menor = Numero2;
      }
      }

      if(x == "0"){
      cadena = "<tr>"
      cadena += "<th>" + "" +"</th>";
      cadena += "<td>" + Numero1 + "</td>"
      cadena += "<td>" + Numero2 + "</td>"
      cadena += "<td>" + Numero3 + "</td>"
      cadena += "<td>" + mayor + "</td>"
      cadena += "<td>" + menor + "</td>"
      cadena += "<td>" + enmedio + "</td>"
      $("#Tabla").append(cadena);
      iziToast.success({
        title: 'Agregado',
       message: 'Registro agregado correctamente',
        });   

      $("#txtnumero1").val("");
      $("#txtnumero2").val("");
      $("#txtnumero3").val("");
    }
  })
