
using MarketManagement.Core.Entities;
using MarketManagement.Core.Interfaces;
using MarketManagement.Data.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Data.Repositories
{
    public class TransactionRepository :  ITransactionRepository
    {
        public TransactionRepository(ApplicationDbContext context)
        {
            _context=context;
        }
        private readonly ApplicationDbContext _context;

        public async Task<IEnumerable<Transaction>> GetByDayAndCashier(string cashierName, DateTime date)
        {
           
            if (string.IsNullOrWhiteSpace(cashierName))
            {
                return _context.Transaction.Where(x => x.TimeStamp.Date == date.Date);
            }
            else
            {
                return _context.Transaction.Where(x =>
                    EF.Functions.Like(x.CashierName, $"%{cashierName}%") &&
                    x.TimeStamp.Date == date.Date);
            }
        }

        public async Task<IEnumerable<Transaction>> Search(string cashierName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
            {
                return _context.Transaction.Where(x =>
                    x.TimeStamp.Date >= startDate.Date &&
                    x.TimeStamp.Date <= endDate.Date);
            }
            else
            {
                return _context.Transaction.Where(x =>
                    EF.Functions.Like(x.CashierName, $"%{cashierName}%") &&
                    x.TimeStamp.Date >= startDate.Date &&
                    x.TimeStamp.Date <= endDate.Date);
            }
        }

        public async Task Add(string cashierName, int productId, string productName, double price, int beforeQty, int soldQty)
        {
            var transaction = new Transaction
            {
                ProductId = productId,
                ProductName = productName,
                TimeStamp = DateTime.Now,
                Price = price,
                BeforeQty = beforeQty,
                SoldQty = soldQty,
                CashierName = cashierName
            };

          

         await   _context.Transaction.AddAsync(transaction);
         await   _context.SaveChangesAsync();
        }
    }
   }
