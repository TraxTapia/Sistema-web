$(document).ready(function () {

    $('#frmIniciarSesion').on('submit', function (e) {
        e.preventDefault();
        if (!$(this).valid()) {
            return;
        }
        //console.log('resq formFichaTecnica')
        codProductoSearch = $('#inputEmail').val();
        var object = {
            CodProducto: $('#txtCodProducto').val().trim(),

        };
        ValidatorCodProducto.resetForm();
        $.ajax({
            beforeSend: function () {
                $.blockUI({
                    theme: true,
                    message: '<div class="row"><div class="col-lg-12"><br /><p style="font-size:small; text-align: center;"><img src="/SASE/Content/assets/img/loading.gif" style="width: 35px;" /></p><p style="font-size:small; text-align: center;">Buscando Registros Espere un Momento Por favor...</p><br /></div></div>',
                    baseZ: 10000
                });
            },
            url: '/SASE/FichaTec/FindFichaTecnica',
            type: 'Post',
            data: object,
            success: function (data) {

                //LimpiarModalCaptura_();
                $.unblockUI();
                if (data != undefined || data != null) {
                    $('#divResult').html(data);

                }
            },
        });
    });
});


function validateFormLogin() {

    if ($("#inputEmail").val() == "" ) {
        swal({
            title: 'Aviso',
            text: "Deves ingresar tu correo electrónico",
            icon: "warning",
        });

        return;
    }
}
