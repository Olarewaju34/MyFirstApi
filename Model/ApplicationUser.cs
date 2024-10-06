using Microsoft.AspNetCore.Identity;

namespace MyFirstApi.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName {  get; set; }
        public string LastName { get; set; } = string.Empty;
    }
}
