using Microsoft.AspNetCore.Mvc.Rendering;

namespace MarketManagement.Web.Services
{
    public interface ISelectProductType
    {
        Task<IEnumerable<SelectListItem>> GetProductsCategory();

    }
}
