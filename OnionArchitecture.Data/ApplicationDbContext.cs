using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Domain;

namespace OnionArchitecture.Data
{
    public class ApplicationDbContext : DbContext
    {

      public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        } 
      
        public DbSet<Project> Projects { get; set; }
    }
}
