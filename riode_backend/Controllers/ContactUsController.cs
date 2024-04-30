using Microsoft.AspNetCore.Mvc;
using riode_backend.Contexts;
using riode_backend.Models;
using System;

namespace riode_backend.Controllers
{
	public class ContactUsController : Controller
	{
        private readonly RiodeDbContext _context;

        public ContactUsController(RiodeDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Comment comment)
        {
            if (!ModelState.IsValid)
                return View();

            Comment comments = new()
            {
                Name = comment.Name,
                Comments = comment.Comments,
                Email = comment.Email,
            };
            await _context.Comments.AddAsync(comments);
            await _context.SaveChangesAsync();

            if (ModelState.IsValid)
            {
                TempData["Success"] = "Your comment was posted";
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}
