using Microsoft.AspNetCore.Mvc;
using PhotoShare.Models;

namespace PhotoShare.Controllers
{
    public class HomeController : Controller
    {
        // Constructor
        public HomeController()
        {
        }

        // Home page - ../ or ../Home/Index
        public IActionResult Index()
        {
            // To-do: Entity Framework - fetch all photos


            // Create a list of photos
            List<Photo> photos = new List<Photo>();

            // Create photo object
            Photo photo1 = new Photo()
            {
                PhotoId = 1,
                //Title = "My cat",
                Description = "This is my cat",
                ImageFilename = "cat.jpg",
                IsVisible = true
            };

            // Create photo object
            Photo photo2 = new Photo();

            photo2.PhotoId = 2;
            //photo2.Title = "Dog";
            photo2.Description = "This is my dog";
            photo2.ImageFilename = "dog.jpg";
            photo2.IsVisible = true;

            // Create photo object
            Photo photo3 = new Photo();

            photo3.PhotoId = 3;
            //photo3.Title = "Hamster";
            photo3.Description = "This is my hamster";
            photo3.ImageFilename = "hamster.jpg";
            photo3.IsVisible = true;

            // Add them to the list
            photos.Add(photo1);
            photos.Add(photo2);
            photos.Add(photo3);

            return View(photos);
        }

        // Display a photo by id - ../Home/DisplayPhoto/
        public IActionResult PhotoDetails(int id)
        {
            // To-do: Entity Framework - fetch the photo by id

            Photo photo = new Photo()
            {
                PhotoId = id,
                //Title = "Bird",
                Description = "This is my bird",
                ImageFilename = "bird.jpg",
                IsVisible = true
            };

            return View(photo);
        }

        // Privacy page - ../Home/Privacy/
        public IActionResult Privacy()
        {
            return View();
        }
    }
}