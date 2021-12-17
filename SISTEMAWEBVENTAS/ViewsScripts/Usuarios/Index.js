let url;

function agregarUsuario() {
    var object = {
        Nombre: $('#txtNombre').val().trim(),
        APaterno: $('#txtApellidoPaterno').val().trim(),
        AMaterno: $('#txtApellidoMaterno').val().trim(),
        IdRol: $('#txtIdRol').val().trim(),

        };
    $.ajax({
        
        url: '/Usuarios/addUsers',
        type: 'POST',
        data: object,
        success: function (data) {
            if (data.IsOK == true) {
                swal({
                    title: 'Correcto',
                    text: "El Registro Se Creo Correctamente",
                    icon: "success",
                });

            }
        },
    });
}