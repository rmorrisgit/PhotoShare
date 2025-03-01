using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhotoShare.Data;
using PhotoShare.Models;

namespace PhotoShare.Controllers
{
    // only logged in users have access
    [Authorize]
    public class TagsController : Controller
    {
        private readonly PhotoShareContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TagsController(PhotoShareContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }
        //DELETED THESE ACTIONS
        // GET: Tags
        // GET: Tags/Details/5
        // GET: Tags/Edit/5
        // POST: Tags/Edit/5
        // POST: Tags/Delete/5


        // GET: Tags/Create
        public async Task<IActionResult> CreateAsync(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var userId = _userManager.GetUserId(User);
            var photo = await _context.Photo
                 .Where(m => m.ApplicationUserId == userId)
                .FirstOrDefaultAsync(m => m.PhotoId == id);

            if (photo == null)
            {
                return NotFound();
            }


            ViewData["PhotoId"] = id;

            return View();
        }

        // POST: Tags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TagId,Name,PhotoId")] Tag tag)
        {
            //
            // TODO: embed the user ID in the form and validate 
            //

            if (ModelState.IsValid)
            {
                _context.Add(tag);
                await _context.SaveChangesAsync();

                //redirect to /Photos/Edit/5
                return RedirectToAction("Edit", "Photos", new { id = tag.PhotoId });
            }
            ViewData["PhotoId"] = new SelectList(_context.Photo, "PhotoId", "PhotoId", tag.PhotoId);
            return View(tag);
        }



        // GET: Tags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            //
            // TODO: verify the the user ID for Photo matches the logged in user 
            //

            // id is the tag id
            if (id == null)
            {
                return NotFound();
            }

            var tag = await _context.Tag.FirstOrDefaultAsync(m => m.TagId == id);

            if (tag == null)
            {
                return NotFound();
            }

            // set the photo id to pass to return to the Photo Details page
            var photoId = tag.PhotoId;

            // Remove the tag
            _context.Tag.Remove(tag);
            await _context.SaveChangesAsync();

            return RedirectToAction("Edit", "Photos", new { id = photoId });
        }


    }
}
