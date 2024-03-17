using MarketManagement.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MarketManagement.Core.Entities
{
    public class Product : IEntityBase
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]        
        public int? Quantity { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public double? Price { get; set; }

        // navigation property for ef core
        public Category? Category { get; set; }
    }
}
