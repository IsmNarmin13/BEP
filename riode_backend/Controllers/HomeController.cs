using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using riode_backend.Contexts;
using riode_backend.ViewModels;

namespace riode_backend.Controllers
{
    public class HomeController : Controller
    {
        private readonly RiodeDbContext _context;

        public HomeController(RiodeDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories.ToListAsync();
            var products = await _context.Products.ToListAsync();

            HomeViewModel homeViewModel = new HomeViewModel
            {
                Categories = categories,
                Products = products
            };
            return View(homeViewModel);
        }


    }
}
