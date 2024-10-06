using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyFirstApi.Model;

namespace MyFirstApi.Data
{
    public class BookStoreContext(DbContextOptions<BookStoreContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Books> Books { get; set; } 
    }
}
