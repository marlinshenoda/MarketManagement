﻿using MarketManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Interfaces
{
    public interface IProductRepository: IEntityBaseRepository<Product>
    {
    }
}
