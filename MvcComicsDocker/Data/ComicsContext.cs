using Microsoft.EntityFrameworkCore;
using MvcComicsDocker.Models;

namespace MvcComicsDocker.Data
{
    public class ComicsContext : DbContext
    {
        public ComicsContext(DbContextOptions<ComicsContext> options) : base(options) { }

        public DbSet<Comic> Comics { get; set; }
    }
}
