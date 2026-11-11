using codArd.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Topic> Topics { get; set; }

    public DbSet<codArd.Models.Task> Tasks { get; set; }

}