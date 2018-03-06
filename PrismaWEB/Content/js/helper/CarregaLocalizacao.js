function CarregaLocalizacao(id, url, campoAlterar) {
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