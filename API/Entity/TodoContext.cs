using Microsoft.EntityFrameworkCore;

namespace ApiTest.Entity;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
    }

    public DbSet<TodoItem> TodoItems { get; set; } = null!;

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    //base.OnConfiguring(optionsBuilder);
    //    if (!optionsBuilder.IsConfigured)
    //        optionsBuilder.UseInMemoryDatabase("TodoList");
    //}
}