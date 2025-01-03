using AICode.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace AICode.Database;

public sealed class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<User>().Property(u => u.FullName).HasMaxLength(3);
		builder.Entity<Category>().HasData(
		   new Category
		   {
			   Id = 1,
			   Name = "Food",
			   CreatedAt = DateTime.UtcNow
		   },
		   new Category
		   {
			   Id = 2,
			   Name = "Housing",
			   CreatedAt = DateTime.UtcNow
		   },
		   new Category
		   {
			   Id = 3,
			   Name = "Transportation",
			   CreatedAt = DateTime.UtcNow
		   },
		   new Category
		   {
			   Id = 4,
			   Name = "Utilities",
			   CreatedAt = DateTime.UtcNow
		   },
		   new Category
		   {
			   Id = 5,
			   Name = "Healthcare",
			   CreatedAt = DateTime.UtcNow
		   },
		   new Category
		   {
			   Id = 6,
			   Name = "Entertainment",
			   CreatedAt = DateTime.UtcNow
		   },
		   new Category
		   {
			   Id = 7,
			   Name = "Education",
			   CreatedAt = DateTime.UtcNow
		   },
		   new Category
		   {
			   Id = 8,
			   Name = "Other",
			   CreatedAt = DateTime.UtcNow
		   }
	   );
	}
    public DbSet<Expense> Expenses { get; set; }
	public DbSet<Category> Categories { get; set; }
}