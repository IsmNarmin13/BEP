using Microsoft.AspNetCore.Identity;

namespace riode_backend.Models
{
    public class AppUser : IdentityUser
    {
        public string Fullname { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
