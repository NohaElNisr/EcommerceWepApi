using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SouqAPI.Model
{
    public class SouqEntity: IdentityDbContext<ApplicationUser>
    {
        public SouqEntity() : base()//onconfigu
        {

        }
        public SouqEntity(DbContextOptions options) : base(options)
        {

        }




        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-LIRBEPU;Initial Catalog=SouqAPI;Integrated Security=True");
        //}
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        

    }
}
