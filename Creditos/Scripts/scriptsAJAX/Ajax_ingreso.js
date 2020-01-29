var row;
function UpdateIngreso(Ingreso) {
    var data = $("#SubmitForm").serialize();
    $.ajax({
        type: "Post",
        url: "/ingresos/UpdateIngresos",
        data: data,
        success: function (result) {
            if (result == "Registro actualizado") {
                Swal.fire({
                    position: 'top-end',
                    icon: 'success',
                    title: 'Registro actualizado',
                    showConfirmButton: false,
                    timer: 1500
                })
                row.find("td").eq(1).html($('#valor').val());
                row.find("td").eq(3).html($('select[id="mes_id"] option:selected').text());
                row.find("td").eq(2).html($('select[id="tipo_ingreso_id"] option:selected').text());
            } else {
                Swal.fire({
                    position: 'top-end',
                    icon: 'error',
                    title: 'Error al actualizado',
                    showConfirmButton: false,
                    timer: 1500
                })
            }
            $("#MyModal").modal("hide");
        }
    })
}
$(document).ready(function () {
    $('[data-id]').click(function () {
        row = $(this).parents("tr");
        var id = $(this).data("id")
        $("#MyModal").modal();
        $.ajax({
            type: "GET",
            url: "/ingresos/GetIngresoById?IngresoId=" + id,
            success: function (data) {
                var obj = JSON.parse(data);
                $("#id_ingresos").val(obj[0].id_ingresos);
                $("#valor").val(obj[0].valor);
                $("#mes_id option[value='" + obj[0].mes_id + "']").attr("selected", true);
                $("#tipo_ingreso_id option[value='" + obj[0].tipo_ingreso_id + "']").attr("selected", true);
            }
        })
    })
})
function DeleteIngreso(Ingreso) {
    Swal.fire({
        title: 'Estás seguro?',
        text: 'Deseas eliminar el registro seleccionado!',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Borrar',
        cancelButtonText: 'Cancelar'
    }).then((result) => {
        if (result.value) {
            $.ajax({
                type: "POST",
                url: "/ingresos/DeleteIngreso?IngresoId=" + Ingreso,
                success: function (result) {
                    if (result == "Eliminado") {
                        Swal.fire(
                            'Borrado!',
                            'El registro fue borrado con éxito',
                            'success'
                        )
                        $(".row_" + Ingreso).remove();
                    } else {
                        Swal.fire(
                            'Borrado!',
                            'No se pudo eliminar el registro',
                            'error'
                        )
                    }
                }
            })
        }
    })
}