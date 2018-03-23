function DeletarItem(token, pryEmpId, url) {
    if (pryEmpId != '') {
        $.ajax({
            url: url +'/'+ pryEmpId,
            type: 'Post',
            data: { __RequestVerificationToken: token },
            success: function (data) {
                if (data) {
                    //now re-using the boostrap modal popup to show success message.
                    //dynamically we will change background colour
                    if ($('.modal-header').hasClass('alert-danger')) {
                        $('.modal-header').removeClass('alert-danger').addClass('alert-success');
                        //hide ok button as it is not necessary
                        $('.delete-confirm').css('display', 'none');
                    }
                    $('.success-message').html('Deletado com sucesso');
                    location.reload();
                }
            }, error: function (err) {
                if (!$('.modal-header').hasClass('alert-danger')) {
                    $('.modal-header').removeClass('alert-success').addClass('alert-danger');
                    $('.delete-confirm').css('display', 'none');
                }
                $('.success-message').html("Inpossivel deletar pois a referencias a este item");
            }
        });
    }
}