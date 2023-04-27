using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public virtual DbSet<tbUser> Users { get; set; }
        public virtual DbSet<tbChat> Chats { get; set; }
        public virtual DbSet<tbPost> Posts { get; set; }
        public virtual DbSet<tbComment> Comments { get; set; }




    }
}
