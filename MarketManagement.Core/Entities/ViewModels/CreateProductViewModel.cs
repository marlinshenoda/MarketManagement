using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Entities.ViewModels
{
    public class CreateProductViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set;}
        public int ProductQuantity { get; set;}   
        public double ProductPrice { get; set;}
        public int CategoryId { get; set;}
    }
}
