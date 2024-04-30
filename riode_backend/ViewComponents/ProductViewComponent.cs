using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using riode_backend.Contexts;
using System;

namespace riode_backend.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        private readonly RiodeDbContext _context;

        public ProductViewComponent(RiodeDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await _context.Products.Where(p => p.isStocked).Where(p => !p.isDeleted).Include(p => p.Category).ToListAsync();
            return View(products);
        }
    }
}
