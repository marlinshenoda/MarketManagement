

$(document).ready(function () {
    $("#formSale").hide();
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
        if (Id > 0) {
            $("#SelectedProductId").val(Id);
            $("#formSale").show();
        }
        else {
            $("#SelectedProductId").val("");
            $("#formSale").hide();
        }
    });

    // Load the products if category is already selected
    var selectedCategoryId = $("#categoryDropdown").val();
    if (selectedCategoryId > 0) {
        loadProducts(selectedCategoryId);

    }

        $("#categoryDropdown").change(function () {
            var SelectedCategoryId = $(this).val();
            loadProducts(SelectedCategoryId);


        });
    
});

function loadProducts(SelectedCategoryId) {
  //  var SelectedCategoryId = $(this).val();

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

}