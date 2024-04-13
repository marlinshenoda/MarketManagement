using MarketManagement.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MarketManagement.Web.Validations
{
    public class SalesViewModel
    {

        public int SelectedCategoryId { get; set; }
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();

        public int SelectedProductId { get; set; }

        [Display(Name = "Quantity")]
        [Range(1, int.MaxValue)]
       //  [SalesViewModel_EnsureProperQuantity]
        //[Remote(action: "IsQuantityAvalable", controller: "Sales", ErrorMessage = "THere Isn't Enough Quantity", AdditionalFields = nameof(SelectedProductId))]
        public int QuantityToSell { get; set; }
    }
}
