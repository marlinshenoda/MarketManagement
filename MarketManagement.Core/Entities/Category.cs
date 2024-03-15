using eTickets.Core.Interfaces;
using MarketManagement.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MarketManagement.Core.Entities
{
    public class Category :IEntityBase
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;

        // navigation property for ef core
        public List<Product>? Products { get; set; }
    }
}
