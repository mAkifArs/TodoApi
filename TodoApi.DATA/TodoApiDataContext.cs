using Microsoft.EntityFrameworkCore;
using TodoApi.DATA.Entities;

namespace TodoApi.DATA
{
    public class TodoApiDataContext : DbContext
    {
        public TodoApiDataContext(DbContextOptions<TodoApiDataContext> options) : base(options)
        {
        }

        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<TodoList> TodoLists { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoList>()
                .HasOne(e => e.UserInfo)
                .WithMany(c => c.TodoLists);
        }
    }
}