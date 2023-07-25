using Microsoft.EntityFrameworkCore;
using WebMarket.Models;

namespace WebMarket.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ) : base (options) // options اسم دلخواه
        {
        }

        public DbSet<Category> Categories { get; set; } //Dbset . معرفی مدل ها به دیتا بیس// Categories اسم جدول  در دیتابیس
        // Category  مدل جدولی که در پوشه مدل معرفی کردیم 
    }
}
