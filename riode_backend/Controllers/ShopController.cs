using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using riode_backend.Contexts;
using System;

namespace riode_backend.Controllers
{
	public class ShopController : Controller
	{
        private readonly RiodeDbContext _context;

        public ShopController(RiodeDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.Where(p => p.isStocked).Include(p => p.Category).ToListAsync();


            return View(products);
        }


    }
}
