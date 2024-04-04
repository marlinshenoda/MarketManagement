

$(document).ready(function () {
    $("#cont-category-product").on("click", ".product-row", function () {

        // Highlight the row selected
        $(".product-row").removeClass("highlight");
        $(this).addClass("highlight");
    });
    $("#categoryDropdown").change(function () {
        var SelectedCategoryId = $(this).val();
        $.ajax({
            url: "/Sales/GetProductsByCategoryIdAjax", // Update the controller and action names accordingly
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

