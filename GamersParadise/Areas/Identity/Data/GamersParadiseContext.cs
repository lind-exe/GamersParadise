using GamersParadise.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GamersParadise.Models;
namespace GamersParadise.Data;

public class GamersParadiseContext : IdentityDbContext<GamersParadiseUser>
{
    public GamersParadiseContext(DbContextOptions<GamersParadiseContext> options)
        : base(options)
    {
    }
    public virtual DbSet<UserThread> UserThreads { get; set; }
    public virtual DbSet<MainCategory> MainCategories { get; set; }
    public virtual DbSet<SubCategory> SubCategories { get; set; }
    public virtual DbSet<Comment> Comments { get; set; }
    public virtual DbSet<PrivateMessage> PrivateMessages { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
