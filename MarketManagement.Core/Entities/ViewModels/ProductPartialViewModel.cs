﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Entities.ViewModels
{
    #nullable disable
    public class ProductPartialViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }    
        public int ProductQuantity { get; set; }

        public string ProductCategory { get; set; }
    }
}
