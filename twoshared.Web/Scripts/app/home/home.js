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



function AddToCart(id) {
   
    Cargando.mostrar("Loading...");    
  
    var data = JSON.stringify
        ({
            'idProduct': id            
        });
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: "POST",
        url: '/Home/Insert_Prouct_cart',
        data: data,
        success: function (result) {
            var mensaje = result.message;
            Cargando.ocultar();
            if (result.resp == "1") {
                Swal.fire(
                    'Success!',
                    result.message,
                    'success'
                ).then(function () {
                    location.reload();
                });;
            }
            else {
                Swal.fire(
                    'Error',
                    mensaje,
                    'error'
                );
            }
        },
        error: function () {
            alert("error");

        },
        complete: function (xhr, status) {
        }
    });
   
}



