using Microsoft.EntityFrameworkCore;
using codArd.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<codArd.Models.Task> Tasks { get; set; }

}