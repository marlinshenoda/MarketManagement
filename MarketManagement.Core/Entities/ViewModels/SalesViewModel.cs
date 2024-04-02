using System.ComponentModel.DataAnnotations;


namespace MarketManagement.Core.Entities.ViewModels
{
    public class SalesViewModel
    {
  
        public IEnumerable<ProductPartialViewModel> Categories { get; set; } 
        public IEnumerable<CategotyPartialViewModel> Products { get; set; }

    }
}
