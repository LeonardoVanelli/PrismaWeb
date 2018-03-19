function CarregaLocalizacao(id, url, campoAlterar) {
    $("." + campoAlterar).addClass("loading")
    $.ajax({
        url: url + id,
        type: 'Post',
        success: function (data) {
            if (data) {             
                $('.' + campoAlterar).dropdown({
                    values: data
                });
                $('.' + campoAlterar).removeClass("loading")
            }
        }
    });
}