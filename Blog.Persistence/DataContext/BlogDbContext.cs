using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistence.DataContext;

public class BlogDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();

    public DbSet<Blogs> Blogs => Set<Blogs>();

    public DbSet<Comment> Comments => Set<Comment>();

    public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) 
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogDbContext).Assembly);
    }
}