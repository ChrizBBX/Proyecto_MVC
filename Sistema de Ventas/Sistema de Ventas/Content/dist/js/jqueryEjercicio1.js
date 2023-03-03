$(document).ready( function () {
  $('#Tabla').DataTable();
} );


        $("#btnCalcular").click(function(){
            var salario = $("#txtsalario").val();
            var nombre = $("#txtnombre").val();
            var x = "0"
            var cadena;

            if(nombre == ""){
                iziToast.warning({title: 'Advertencia',message: 'Ingrese el nombre',});
                x = "1";
            }
               
            if(salario == ""){
                iziToast.warning({title: 'Advertencia',message: 'Ingrese el salario',});
                x = "1";
            }

            if(salario == 0){
                iziToast.warning({title: 'Advertencia',message: 'Ingrese un salario valido',});
                x = "1";
            }

            if(x == "0"){
            if(salario > 0 && salario < 500){
                var nuevoSalario = (salario * 0.15) + parseInt(salario);
            cadena = "<tr>"
            cadena += "<th>" + "" +"</th>";
            cadena += "<td>" + nombre + "</td>"
            cadena += "<td>" + salario + "</td>"
            cadena += "<td>" + nuevoSalario + "</td>"
            $("#Tabla").append(cadena);
            iziToast.success({
              title: 'Agregado',
             message: 'Registro agregado correctamente',
              });      
            $("#txtnombre").val("");
            $("#txtsalario").val("");
            }

            if(salario > 499 && salario < 1000){
                var nuevoSalario = (salario * 0.10) + parseInt(salario);
                cadena = "<tr>"
            cadena += "<th>" + "" +"</th>";
            cadena += "<td>" + nombre + "</td>"
            cadena += "<td>" + salario + "</td>"
            cadena += "<td>" + nuevoSalario + "</td>"
            $("#Tabla").append(cadena);
            iziToast.success({
              title: 'Agregado',
             message: 'Registro agregado correctamente',
              });      
            $("#txtnombre").val("");
            $("#txtsalario").val("");
            }

            
            if(salario > 999){
                var nuevoSalario = (salario * 0.05) + parseInt(salario);
                cadena = "<tr>"
            cadena += "<th>" + "" +"</th>";
            cadena += "<td>" + nombre + "</td>"
            cadena += "<td>" + salario + "</td>"
            cadena += "<td>" + nuevoSalario + "</td>"
            $("#Tabla").append(cadena);
            iziToast.success({
              title: 'Agregado',
             message: 'Registro agregado correctamente',
              });      
            $("#txtnombre").val("");
            $("#txtsalario").val("");
            }
            $("#exampleModal").modal("hide");
            } 
    })

  $('#modal').click(function () {
$('#exampleModal').modal("show");
})

  $('#hidemodal').click(function () {
$('#exampleModal').modal("hide");
})
