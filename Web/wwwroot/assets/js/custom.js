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


    $(document).on("click", '.category', function () {
        var id = $(this).data('id')
        $.ajax({
            method: "GET",
            url: "/shop/filterbycategory",
            data: {
                id: id
            },
            success: function (result) {
                console.log(result)
                if (result != "") {
                    $('#products').html("");
                    $('#products').append(result);
                }

            }
        })
    })

    $(document).on("click", '#product-search-btn', function () {
        var name = $('#search-product').val()
        $.ajax({
            method: "GET",
            url: "/shop/FilterByName",
            data: {
                name: name
            },
            success: function (result) {
                console.log(result)
                if (result != "") {
                    $('#products').html("");
                    $('#products').append(result);
                }

            }
        })
    })


    $(document).on("click", '.addToCardBtn', function () {
        var id = $(this).data('id')
        $.ajax({
            method: "POST",
            url: "/basket/add",
            data: {
                id: id
            },
            success: function (result) {
                console.log(result)
            }
        })
    })


    $(document).on("click", '.deleteButton', function () {
        var id = $(this).data('id')

        $.ajax({
            method: "POST",
            url: "/basket/delete",
            data: {
                id: id
            },
            success: function (result) {
 
                $(`.basket-product[id=${id}]`).remove();

            }
        })
    })


    $(document).on("click", '.decrease', function () {
        var id = $(this).data('id')
        console.log(id)
        $.ajax({
            method: "POST",
            url: "/basket/decreasecount",
            data: {
                id: id
            },
            success: function (result) {
                console.log(id)
                console.log(result)
            }
        })
    })


    $(document).on("click", '.increase', function () {
        var id = $(this).data('id')
        console.log(id)
        $.ajax({
            method: "POST",
            url: "/basket/increasecount",
            data: {
                id: id
            },
            success: function (result) {
                console.log(id)
                console.log(result)
            }
        })
    })

});