using Chat.Entities.Models.ChatItem;
using Chat.Entities.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Chat.Entities.Db
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<UserInfo> Users { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<UsersGroup> UsersGroups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-F4JCGAD;Database=Chat8;Trusted_Connection=True;");
        }
    }
}
