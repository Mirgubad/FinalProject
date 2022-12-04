jQuery(document).ready(function ($) {
    $(document).on("click", '.category', function () {
        var id = $(this).data('id')
        $.ajax({
            method: "GET",
            url: "/faq/filterbycategory",
            data: {
                id: id
            },
            success: function (result) {
                $('#questions').html("");
                $('#questions').append(result);
            }
        })
    })
});