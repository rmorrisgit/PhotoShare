using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhotoShare.Data;
using PhotoShare.Models;

namespace PhotoShare.Controllers
{
    public class HomeController : Controller
    {

        private readonly PhotoShareContext _context;

        // Constructor
        public HomeController(PhotoShareContext context)
        {
            _context = context;
        }

        // Home page - ../ or ../Home/Index
        public async Task<IActionResult> Index()
        {
            // get a list of photos
            var photos = await _context.Photo.ToListAsync();


            return View(photos);
        }

        // Display a photo by id - ../Home/DisplayPhoto/
        public async Task<IActionResult> PhotoDetails(int id)
        {
            // To-do: Entity Framework - fetch the photo by id
            var photo = await _context.Photo.FirstOrDefaultAsync(m => m.PhotoId == id);

            return View(photo);
        }

        // Privacy page - ../Home/Privacy/
        public IActionResult Privacy()
        {
            return View();
        }
    }
}