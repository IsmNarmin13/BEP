using System.ComponentModel.DataAnnotations;

namespace riode_backend.Areas.Admin.ViewModels
{
    public class CategoryViewModel
    {
        [Required]
        public string CategoryName { get; set; }
        public IFormFile Image { get; set; }
    }
}
