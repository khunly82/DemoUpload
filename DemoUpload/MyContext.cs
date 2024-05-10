using Microsoft.EntityFrameworkCore;

namespace DemoUpload
{
    public class MyContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public MyContext(DbContextOptions options): base(options) { }
    }
}
