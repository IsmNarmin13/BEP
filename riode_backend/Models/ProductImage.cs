using System.ComponentModel.DataAnnotations.Schema;

namespace riode_backend.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public bool IsMain { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        public int ProductId {  get; set; }
        public Product Product { get; set; }
    }
}
