
using MarketManagement.Core.Entities;
using MarketManagement.Core.Interfaces;
using MarketManagement.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Data.Repositories
{
    public class TransactionRepository : EntityBaseRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}