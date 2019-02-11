using Microsoft.EntityFrameworkCore;

namespace Portfolio.Models
{
    public class PortfolioContext : DbContext
    {
        public PortfolioContext(DbContextOptions<PortfolioContext> options)
            : base(options)
        {
        }

        public DbSet<ProjectItem> ProjectItem { get; set; }
    }
}