﻿
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
    public class TransactionRepository :ITransactionRepository
    {
        private ApplicationDbContext db;

        public TransactionRepository(ApplicationDbContext db) 
        {
            this.db = db;

        }
        private List<Transaction> transactions = new List<Transaction>();

        public IEnumerable<Transaction> GetByDayAndCashier(string cashierName, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
                return transactions.Where(x => x.TimeStamp.Date == date.Date);
            else
                return transactions.Where(x =>
                    x.CashierName.ToLower().Contains(cashierName.ToLower()) &&
                    x.TimeStamp.Date == date.Date);
        }

        public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
                return transactions.Where(x => x.TimeStamp >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date);
            else
                return transactions.Where(x =>
                    x.CashierName.ToLower().Contains(cashierName.ToLower()) &&
                    x.TimeStamp >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date);
        }

        public void Add(string cashierName, int productId, string productName, double price, int beforeQty, int soldQty)
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

            if (transactions != null && transactions.Count > 0)
            {
                var maxId = transactions.Max(x => x.Id);
                transaction.Id = maxId + 1;
            }
            else
            {
                transaction.Id = 1;
            }

            transactions?.Add(transaction);
        }
    }
}


    
