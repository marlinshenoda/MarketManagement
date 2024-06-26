﻿using MarketManagement.Core.Entities;
using MarketManagement.Core.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Interfaces
{
    public interface IProductRepository: IEntityBaseRepository<Product>
    {

        Product? GetProductById(int Id);

    }
}
