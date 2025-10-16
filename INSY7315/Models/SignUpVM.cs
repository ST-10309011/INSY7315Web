using System.ComponentModel.DataAnnotations;

namespace AfterGrad.Models
{
    public class SignUpVM
    {
        [Required(ErrorMessage = "Student Number is required.")]
        public string StudentNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
        public string Password { get; set; } = string.Empty;
    }
}