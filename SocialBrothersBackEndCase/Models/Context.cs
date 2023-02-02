using Microsoft.EntityFrameworkCore;
using System.Data;

namespace SocialBrothersBackEndCase.Models
{
    public class Context : DbContext
    {
        public DbSet<InsertIntoDatabase> List { get; set; }
        //Where database is being stored
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=C:\Temp\Addresses.db");
  
    }
}
