$(document).ready( function () {
    $('#Tabla').DataTable();
  } );
  
var cadena
    $("#btnregistrar").click(function(){
        var nombre = $("#txtnombre").val();
        var primerapellido = $("#txtprimerapellido").val();
        var segundoapellido = $("#txtsegundoapellido").val();
        var fechanacimiento = $("#datefechanacimiento").val();
        var profesion = $("#txtprofesion").val();
        var nivelacademico = "";
        var x = "0";

        if($("#cksecundaria").prop('checked')){
            nivelacademico += " Secundaria ";
        }
        if($("#cklicenciatura").prop('checked')){
            nivelacademico += " Licenciatura ";
        }
        if($("#ckingenieria").prop('checked')){
            nivelacademico += " Ingenieria ";
        }
        if($("#ckmaestria").prop('checked')){
            nivelacademico += " Maestria ";
        }
        if($("#ckdoctorado").prop('checked')){
            nivelacademico += " Doctorado ";
        }
        
        if(nombre == ""){
            iziToast.warning({title: 'Advertencia',message: 'Ingrese el nombre',});
            x = "1";
        }
        if(primerapellido == ""){
            iziToast.warning({title: 'Advertencia',message: 'Ingrese el primer apellido',});
            x = "1";
        }
        if(segundoapellido == ""){
            iziToast.warning({title: 'Advertencia',message: 'Ingrese el segundo apellido',});
            x = "1";
        }
        if(fechanacimiento == ""){
            iziToast.warning({title: 'Advertencia',message: 'Ingrese la fecha de nacimiento',});
            x = "1";
        }
        if(profesion == ""){
            iziToast.warning({title: 'Advertencia',message: 'Ingrese la profesion',});
            x = "1";
        }
        if(nivelacademico == ""){
            iziToast.warning({title: 'Advertencia',message: 'Ingrese el nivel de academico',});
            x = "1";
        }
       
        if(x == "0"){
            cadena = "<tr>"
    cadena += "<th>" + "" +"</th>";
    cadena += "<td>" + nombre + "</td>"
    cadena += "<td>" + primerapellido + "</td>"
    cadena += "<td>" + segundoapellido + "</td>"
    cadena += "<td>" + fechanacimiento + "</td>"
    cadena += "<td>" + profesion + "</td>"
    cadena += "<td>" + nivelacademico + "</td>"
    $("#Tabla").append(cadena);
    iziToast.success({
      title: 'Agregado',
     message: 'Registro agregado correctamente',
      });   
        }
  
    }); 
