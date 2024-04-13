using MarketManagement.Core.Interfaces;
using MarketManagement.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MarketManagement.Web.ViewComponents
{
    [ViewComponent]
    public class TransactionsViewComponent : ViewComponent
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionsViewComponent(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        //public IViewComponentResult Invoke(string userName)
        //{
        //    var transactions = _transactionRepository.GetByDayAndCashier(userName, DateTime.Now);

        //    return View(transactions);
        //}
        public string Invoke()
        {

            return "list of transaction" ;
        }
    }
}
