

$(document).ready(function () {
    $("#cont-category-product").on("click", ".product-row", function () {

        // Highlight the row selected
        $(".product-row").removeClass("highlight");
        $(this).addClass("highlight");
    });
    });