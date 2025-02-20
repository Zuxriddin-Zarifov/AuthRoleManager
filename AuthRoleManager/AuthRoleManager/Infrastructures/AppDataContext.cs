using AuthRoleManager.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AuthRoleManager.Infrastructures;

public class AppDataContext : DbContext
{
    protected DbSet<User> Users { get; set; }
    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
    {
        
    }
}
