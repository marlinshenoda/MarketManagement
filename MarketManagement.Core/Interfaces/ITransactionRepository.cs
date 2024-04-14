using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketManagement.Core.Entities;

namespace MarketManagement.Core.Interfaces
{
    public interface ITransactionRepository : IEntityBaseRepository<Transaction>
    {
    }
}
