using MarketManagement.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MarketManagement.Web.ViewComponents
{
    [ViewComponent]
    public class TransactionsViewComponent : ViewComponent
    {
        private readonly ITransactionRepository transactionRepository;

        public TransactionsViewComponent(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(string userName)
        {
            var transactions =await transactionRepository.GetByDayAndCashier(userName,DateTime.Now);

            return View(transactions);
        }
    }
}
