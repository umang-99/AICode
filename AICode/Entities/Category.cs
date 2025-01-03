using System.ComponentModel.DataAnnotations;

namespace AICode.Entities
{
	public class Category
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(200)]
		public string Name { get; set; }

		public DateTime CreatedAt { get; set; }

		// Navigation property
		public ICollection<Expense> Expenses { get; set; } // Navigation property for Expenses
	}
}
