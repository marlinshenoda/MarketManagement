using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketManagement.Core.Entities;

namespace MarketManagement.Core.Interfaces
{
    public interface ITransactionRepository
    {
        public  Task<IEnumerable<Transaction>> GetByDayAndCashier(string cashierName, DateTime date);
        public Task<IEnumerable<Transaction>> Search(string cashierName, DateTime startDate, DateTime dateTime);
        public Task Add(string cashierName, int productId, string productName, double price, int beforeQty, int soldQty);
    }
}
