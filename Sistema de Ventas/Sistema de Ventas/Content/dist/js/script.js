$("#btnlogin").click(function(){
var x = "0";
  if($("#txtemail").val() == ""){
    iziToast.warning({
      title: 'Advetencia', message: 'Ingrese el email',
    })
    x = "1";
  }
  if($("#txtpassword").val() == ""){
    iziToast.warning({
      title: 'Advetencia', message: 'Ingrese una contraseña',
    })
    x = "1";
  }

  if(x == "0"){
    if($("#txtemail").val() == "a@gmail.com" && $("#txtpassword").val() == "123"){
      window.location.href = "blank.html";
    }else{
      iziToast.warning({
        title: 'Advetencia', message: 'El usuario o la contraseña son incorrectos',
      })
    }
  }

  })

