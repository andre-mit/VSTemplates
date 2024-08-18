using Microsoft.EntityFrameworkCore;

namespace Clean.Arch.Template.Infraestructure.Data.Contexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}