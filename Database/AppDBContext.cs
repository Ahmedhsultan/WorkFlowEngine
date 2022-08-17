using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<User> user { get; set; }
        public DbSet<Digrams> digrams { get; set; }
        public DbSet<Processes> processes { get; set; }
        public DbSet<Requests> requests { get; set; }
    }
}