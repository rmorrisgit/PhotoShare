using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Azure;

namespace PhotoShare.Models
{
    public class Photo
    {
        // primary key
        public int PhotoId { get; set; }

        public string Description { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        public string Camera { get; set; } = string.Empty;

        public string ImageFilename { get; set; } = string.Empty;




        // Property for file upload, not mapped in EF
        [NotMapped]
        [Display(Name = "Photograph")]
        public IFormFile? ImageFile { get; set; } // nullable!






        [Display(Name = "Visibility")]
        public bool IsVisible { get; set; } = false;

        [Display(Name = "Date Created")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation property
        public List<Tag>? Tags { get; set; }  // nullable!!!
    }
}