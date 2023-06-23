$(document).ready(function () { //click
    GetAll();
    EstadoGetAll();
});

function GetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:65156/api/Empleado/GetAll',
        success: function (result) { //200 OK 
            $('#Empleados tbody').empty();
            $.each(result.Objects, function (i, empleado) {
                var filas =
                    '<tr>'
                    + '<td class="text-center"> <button class="btn btn-warning" onclick="GetById(' + empleado.IdEmpleado + ')"><span class=" bi bi-pencil-square" style="color:#FFFFFF"></button></td>'
                    + "<td  id='id' class='visually-hidden'>" + empleado.IdEmpleado + "</td>"
                    + "<td class='text-center'>" + empleado.NumeroNomina + "</td>"
                    + "<td class='text-center'>" + empleado.Nombre + "</ td>"
                    + "<td class='text-center'>" + empleado.ApellidoPaterno + "</td>"
                    + "<td class='text-center'>" + empleado.ApellidoMaterno + "</td>"
                    + "<td  id='id' class='visually-hidden'>" + empleado.Entidad.IdEntidadFederativa + "</td>"
                    + "<td class='text-center'>" + empleado.Entidad.Estado + "</td>"
                    + '<td class="text-center"> <button class="btn btn-danger" onclick="Eliminar(' + empleado.IdEmpleado + ')"><span class="bi bi-trash3" style="color:#FFFFFF"></span></button></td>'
                    + "</tr>";
                $("#Empleados tbody").append(filas);
            });
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};

function EstadoGetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:65156/api/Entidad/GetAll',
        success: function (result) {
            $("#ddlEstados").append('<option value="' + 0 + '">' + 'Seleccione una opción' + '</option>');
            $.each(result.Objects, function (i, entidad) {
                $("#ddlEstados").append('<option value="'
                    + entidad.IdEntidadFederativa + '">'
                    + entidad.Estado + '</option>');
            });
        }
    });
};

function Add() {
    var empleado = {
        IdEmpleado: 0,
        NumeroNomina: $('#txtNumeroNomina').val(),
        Nombre: $('#txtNombre').val(),
        ApellidoPaterno: $('#txtApellidoPaterno').val(),
        ApellidoMaterno: $('#txtApellidoMaterno').val(),
        Entidad: {
            IdEntidadFederativa: $('#ddlEstados').val()
        }
    }
    $.ajax({
        type: 'POST',
        url: 'http://localhost:65156/api/Empleado/Add',
        dataType: 'json',
        data: empleado,
        success: function (result) {
            $('#myModal').modal("show");
            GetAll();
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};

function GetById(IdEmpleado) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:65156/api/Empleado/GetById/' + IdEmpleado,
        success: function (result) {
            $('#txtIdEmpleado').val(result.Object.IdEmpleado);
            $('#txtNumeroNomina').val(result.Object.NumeroNomina);
            $('#txtNombre').val(result.Object.Nombre);
            $('#txtApellidoPaterno').val(result.Object.ApellidoPaterno);
            $('#txtApellidoMaterno').val(result.Object.ApellidoMaterno);
            $('#ddlEstados').val(result.Object.Entidad.IdEntidadFederativa);
            $('#ModalUpdate').modal('show');
        },
        error: function (result) {
            alert('Ocurrio un error en la consulta' + result.responseJSON.ErrorMessage);
        }
    });
};

function Update() {
    var empleado = {
        IdEmpleado: $('#txtIdEmpleado').val(),
        NumeroNomina: $('#txtNumeroNomina').val(),
        Nombre: $('#txtNombre').val(),
        ApellidoPaterno: $('#txtApellidoPaterno').val(),
        ApellidoMaterno: $('#txtApellidoMaterno').val(),
        Entidad: {
            IdEntidadFederativa: $('#ddlEstados').val()
        }
    }
    $.ajax({
        type: 'POST',
        url: 'http://localhost:65156/api/Empleado/Update',
        datatype: 'json',
        data: empleado,
        success: function (result) {
            $('#myModal').modal("show");
            $('#Modal').modal('show');
            GetAll();
            /*Console(respond);*/
        },
        error: function (result) {
            alert('Ocurrio un error al actualizar' + result.responseJSON.ErrorMessage);
        }
    });
};

function Eliminar(IdEmpleado) {
    if (confirm("¿Estas seguro de eliminar el Empleado seleccionada?")) {
        $.ajax({
            type: 'POST',
            url: 'http://localhost:65156/api/Empleado/Delete/' + IdEmpleado,
            success: function (result) {
                $('#myModal').modal("show");
                GetAll();
            },
            error: function (result) {
                alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
            }
        });
    };
};

function IniciarEmpleado() {
    $('#txtIdEmpleado').val("");
    $('#txtNumeroNomina').val("");
    $('#txtNombre').val("");
    $('#txtApellidoPaterno').val("");
    $('#txtApellidoMaterno').val("");
    $('#ddlEstados').val(0)
};

function Comprobar() {
    var idEmpleado = $("#txtIdEmpleado").val();
    if (idEmpleado != 0) {
        Update();
    }
    else
    {
        Add();
    }
};

function MostrarModal() {
    $("#ModalUpdate").modal("show");
}
function CerrarModal() {
    $("#ModalUpdate").modal('hide');
}