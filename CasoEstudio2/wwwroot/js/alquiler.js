function mostrarError(msg) {
    $("#alertErrorMsg").text(msg);
    $("#alertError").removeClass("d-none");
    $("html, body").animate({ scrollTop: 0 }, 300);
}

function ocultarError() {
    $("#alertError").addClass("d-none");
}

function marcarInvalido(campo, errId) {
    $(campo).addClass("is-invalid");
    $(errId).removeClass("d-none");
}

function limpiarInvalido(campo, errId) {
    $(campo).removeClass("is-invalid");
    $(errId).addClass("d-none");
}

// Al cambiar la casa, limpia su estado y carga el precio
$("#IdCasa").on("change", function () {
    ocultarError();
    limpiarInvalido("#IdCasa", "#errIdCasa");

    var idCasa = $(this).val();

    if (!idCasa) {
        $("#PrecioCasa").val("");
        return;
    }

    $.get("/Casas/ObtenerPrecio", { idCasa: idCasa }, function (data) {
        $("#PrecioCasa").val(parseFloat(data).toFixed(2));
    }).fail(function () {
        mostrarError("No se pudo obtener el precio. Verifique la conexión.");
        $("#PrecioCasa").val("");
    });
});

// Al escribir en usuario, limpia su estado
$("#UsuarioAlquiler").on("input", function () {
    if ($(this).val().trim() !== "") {
        limpiarInvalido("#UsuarioAlquiler", "#errUsuario");
    }
});

// Validación antes de enviar
$("#formAlquiler").on("submit", function (e) {
    ocultarError();
    limpiarInvalido("#IdCasa", "#errIdCasa");
    limpiarInvalido("#UsuarioAlquiler", "#errUsuario");

    var valido = true;
    var mensaje = "";

    var idCasa = $("#IdCasa").val();
    if (!idCasa) {
        marcarInvalido("#IdCasa", "#errIdCasa");
        mensaje = "Debe seleccionar una casa disponible.";
        valido = false;
    }

    var usuario = $("#UsuarioAlquiler").val().trim();
    if (!usuario) {
        marcarInvalido("#UsuarioAlquiler", "#errUsuario");
        if (!mensaje) mensaje = "El campo de usuario es obligatorio.";
        valido = false;
    }

    if (!valido) {
        e.preventDefault();
        mostrarError(mensaje);
        return;
    }

    $("#btnAlquilar").prop("disabled", true).text("Procesando...");
});