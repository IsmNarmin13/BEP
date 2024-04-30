using System.ComponentModel.DataAnnotations;

namespace riode_backend.Areas.Admin.ViewModels
{
    public class BrandUpdateViewModel
    {
        [Required]
        public string BrandName { get; set; }
        public IFormFile? Image { get; set; }
    }
}
