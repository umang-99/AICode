namespace AICode.Contracts
{
    public class GetSummaryResponseDto
    {
        public IEnumerable<CategoryGroupDto> GroupedByCategory { get; set; }
        public IEnumerable<YearGroupDto> GroupedByYear { get; set; }
        public IEnumerable<MonthGroupDto> GroupedByMonth { get; set; }
        public IEnumerable<DateGroupDto> GroupedByDate { get; set; }
    }

    public class CategoryGroupDto
    {
        public string Category { get; set; } // Name of the category
        public decimal TotalAmount { get; set; } // Total amount spent in the category
        public int ExpenseCount { get; set; } // Number of expenses in the category
    }

    public class YearGroupDto
    {
        public int Year { get; set; }
        public decimal TotalAmount { get; set; }
        public int ExpenseCount { get; set; }
    }

    public class MonthGroupDto
    {
        public int Month { get; set; }
        public decimal TotalAmount { get; set; }
        public int ExpenseCount { get; set; }
    }

    public class DateGroupDto
    {
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public int ExpenseCount { get; set; }
    }
}
