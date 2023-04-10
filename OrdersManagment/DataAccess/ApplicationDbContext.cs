using Microsoft.EntityFrameworkCore;
using OrdersManagment.Models.Tables;

namespace OrdersManagment.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Status> Status { get; set; }
    }
}
