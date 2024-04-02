using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Entities.ViewModels
{
    public class ProductPartialViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Quentity { get; set; }

        public string Category { get; set; }
    }
}
