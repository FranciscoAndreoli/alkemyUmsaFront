var token = getCookie("Token");
let table = new DataTable('#usuarios', {
    ajax: {
        url: `https://localhost:7061/api/Usuarios`,
        dataSrc: "data",
        headers: { "Authorization": "Bearer " + token }
    },
    columns: [
        { data: 'nombre', title: 'Nombre' },
        { data: 'dni', title: 'DNI' },
        { data: 'email', title: 'Mail' },
        { data: 'rol', title: 'Rol' },
        {
            data: function (data) {
                var botones =
                    `<td><a href='javascript:EditarUsuario(${JSON.stringify(data)})'><i class="fa-solid fa-pen-to-square editarUsuario"></i></td>` +
                    `<td><a href='javascript:EliminarUsuario(${JSON.stringify(data)})'><i class="fa-solid fa-trash eliminarUsuario"></i></td>`
                return botones;
            }
        }

    ]
});

function AgregarUsuario() {
    $.ajax({
        type: "GET",
        url: "/Usuarios/UsuariosAddParcial",
        data: "",
        contentType: 'application/json',
        'dataType': "html",
        success: function (resultado) {
            $('#usuariosAddParcial').html(resultado);
            $('#usuarioModal').modal('show');
        }

    });
}

function EditarUsuario(data) {
    debugger
    $.ajax({
        type: "POST",
        url: "/Usuarios/UsuariosAddParcial",
        data: JSON.stringify(data),
        contentType: 'application/json',
        'dataType': "html",
        success: function (resultado) {
            $('#usuariosAddParcial').html(resultado);
            $('#usuarioModal').modal('show');
        }

    });
}

function EliminarUsuario(data) {
    $.ajax({
        type: "GET",
        url: "/Usuarios/EliminarUsuario",
        data: JSON.stringify(data),
        'dataType': "html",
        success: function (resultado) {

        }

    });
}