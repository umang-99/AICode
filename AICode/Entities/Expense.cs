using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AICode.Entities
{
	public class Expense
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(200)]
		public string Name { get; set; }

		public int UserId { get; set; } // Foreign key to User table

		public int CategoryId { get; set; } // Foreign key to Category table

		[Column(TypeName = "decimal(18, 2)")]
		public decimal Amount { get; set; }

		public DateTime Date { get; set; }

		public string Description { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime UpdatedAt { get; set; }

		public bool IsDeleted { get; set; }

		// Navigation properties
		public User User { get; set; } // Navigation property for User
		public Category Category { get; set; } // Navigation property for Category
	}
}
