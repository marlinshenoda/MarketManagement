using MarketManagement.Core.Entities;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;


namespace MarketManagement.Core.Entities.ViewModels
{
    public class SalesViewModel
    {

        public int SelectedCategoryId { get; set; }
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();

        public int SelectedProductId { get; set; }
 
        [Display(Name = "Quantity")]
        [Range (1, int.MaxValue)]

        public int QuantityToSell { get; set; }
    }
}
