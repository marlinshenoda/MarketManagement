using MarketManagement.Data.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MarketManagement.Web.Services
{
    public class SelectProductType:ISelectProductType
    {
        private readonly ApplicationDbContext _context;

        public SelectProductType(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SelectListItem>> GetProductsCategory()
        {
            return await _context.Category
                              .Select(m => new SelectListItem
                              {
                                  Text = m.Name.ToString(),
                                  Value = m.Id.ToString()
                              })
                              .ToListAsync();
        }
    }
}
