using System.ComponentModel.DataAnnotations.Schema;

namespace riode_backend.Models
{
    public class Category
    {
        public int Id { get; set; }
		public string CategoryName { get; set; }
        public string Image {  get; set; }
		public bool isDeleted { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime UpdatedDate { get; set; }
		public ICollection<Product>? Products { get; set; }
    }
}
