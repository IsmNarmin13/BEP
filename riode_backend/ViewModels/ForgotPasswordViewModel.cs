using System.ComponentModel.DataAnnotations;

namespace riode_backend.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
