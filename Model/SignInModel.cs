using System.ComponentModel.DataAnnotations;

namespace MyFirstApi.Model
{
    public class SignInModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
