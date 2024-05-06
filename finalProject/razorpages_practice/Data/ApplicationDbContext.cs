using Microsoft.EntityFrameworkCore;

namespace razorpages_practice.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        
        }
    }
}
