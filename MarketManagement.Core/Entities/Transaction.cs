﻿
using MarketManagement.Core.Interfaces;

namespace MarketManagement.Core.Entities
{
    public class Transaction 
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = ""; // in case product name changes
        public double Price { get; set; }
        public int BeforeQty { get; set; }
        public int SoldQty { get; set; }
        public string CashierName { get; set; } = "";
    }
}
