using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TodoAPI.Models
{
    public class TodoContext: DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; } = null!;
        public DbSet<Priority> Priorities { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;
        public DbSet<TodoItemTag> TodoItemTags { get; set; } = null!;

        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<UserRole> UserRoles { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>()
                .HasMany(e => e.Tags)
                .WithMany(e => e.TodoItems)
                .UsingEntity<TodoItemTag>();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Roles)
                .WithMany(e => e.Users)
                .UsingEntity<UserRole>();
        }
    }
}
