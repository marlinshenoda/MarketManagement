

$(document).ready(function () {
    $("#cont-category-product").on("click", ".product-row", function () {

        // Highlight the row selected
        $(".product-row").removeClass("highlight");
        $(this).addClass("highlight");


        var Id = $(this).attr('product-id');
            $.ajax({
                url: "/Sales/GetProductsDetailsAjax",
                type: 'GET',
                data: { Id: Id },
                success: function (response) {
                    $("#productDetailPartial").html(response);
                },
                error: function () {
                    alert('Error occurred while fetching products.');
                }
            

        });
    });
    $("#categoryDropdown").change(function () {
        var SelectedCategoryId = $(this).val();
        $.ajax({
            url: "/Sales/GetProductsByCategoryIdAjax", 
            type: 'GET',
            data: { SelectedCategoryId: SelectedCategoryId },
            success: function (response) {
                $("#cont-category-product").html(response);
            },
            error: function () {
                alert('Error occurred while fetching products.');
            }
        });

    });
});

