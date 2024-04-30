namespace riode_backend.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
		public bool isDeleted { get; set; }
		public ICollection<Product>? Products { get; set; }
    }
}
