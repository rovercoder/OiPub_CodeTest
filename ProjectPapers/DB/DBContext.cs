using Microsoft.EntityFrameworkCore;

namespace ProjectPapers.DB
{
    public class DBContext : DbContext
    {
        public DbSet<DB.Data.Paper> Papers { get; set; }

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
    }
}
