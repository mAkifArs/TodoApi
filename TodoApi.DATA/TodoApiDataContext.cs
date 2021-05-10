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
            modelBuilder.Entity<UserInfo>().Property(b => b.UserId).UseIdentityAlwaysColumn();
            
            modelBuilder.Entity<TodoList>().Property(b => b.TodoId).UseIdentityAlwaysColumn();
            
            
            
            modelBuilder.Entity<TodoList>()
                .HasOne(u => u.UserInfo)
                .WithMany(t => t.Todos).HasForeignKey(x => x.UserId);
            
            
        }
        
    }
}