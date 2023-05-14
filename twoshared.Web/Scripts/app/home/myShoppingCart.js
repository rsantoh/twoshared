function Tags(id) {
    llamarAjaxPartialViewModal("/Home/_Tags?id=" + id, "dv_partial_modal_standar");
}

$(function () {
    //Cargando.mostrar("...");
    var options = {
        valueNames: ['item-name', 'item-fecha', 'item-carga'],
        page: 10,
        pagination: {
            paginationClass: 'nav-pagination'
        }
    };
    var companiesList = new List('products', options);
})

window.Cargando = {
    mensaje: "Por favor espere ...",
    mostrar: function (mensaje) {
        var cargando_mensaje = window.Cargando.mensaje;
        if (mensaje != undefined && mensaje != null && mensaje != "") {
            cargando_mensaje = mensaje;
        }
        $(".cargando-content p").html(cargando_mensaje);
        $(".cargando").show();
    },
    ocultar: function () {
        $(".cargando").hide();
    }
}


function DeleteItemShopingCart(id) {
    Swal.fire({
        title: 'Are you sure?',
        //text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'YES',
        cancelButtonText: 'NO'
    }).then((result) => {
        if (result.isConfirmed) {
            var dataSend = new FormData();
            dataSend.append("id", id);
            $.ajax({
                url: '/Home/Delete_Item_MyCart/',
                type: "POST",
                data: dataSend,
                dataType: 'json',
                contentType: false,
                processData: false,
                success: function (result) {
                    if (result.resp) {
                        location.reload();
                    }
                    else {
                        Swal.fire(
                            'Error',
                            'No se pudo ejecutar la operacion',
                            'error'
                        );
                        location.reload();
                    }
                },
                error: function (xhr, status) {

                    alert("An error occured: " + xhr.status + " " + xhr.statusText + " - status: " + status);
                    location.reload();
                }
            });
        }
    });


}