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


    $(document).on("click", '#search-doctor', function () {
        var name = $('#FullName').val()
        $.ajax({
            method: "GET",
            url: "/doctor/filterbyname",
            data: {
                name: name
            },
            success: function (result) {
                if (name != "") {
                    $('#doctor-items').html("");
                    $('#doctor-items').append(result);
                }
                else {
                    $('#FullName').attr("placeholder", "Type Something")
                }

            }
        })
    })


});