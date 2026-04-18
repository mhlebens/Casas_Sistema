$("#IdCasa").change(function () {
    var idCasa = $(this).val();

    if (idCasa) {
        $.get('/Casas/ObtenerPrecio', { idCasa: idCasa }, function (data) {
            $("#PrecioCasa").val(data);
        });
    } else {
        $("#PrecioCasa").val("");
    }
});