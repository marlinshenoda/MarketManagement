using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Entities.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public Product Product { get; set; } = new Product();
    }
}
