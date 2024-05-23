using CoreProjeAPI.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace CoreProjeAPI.DAL.ApiContext
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("your connection db string type here");
        }
        public DbSet<Category> Categories { get; set; } 
    }
}
