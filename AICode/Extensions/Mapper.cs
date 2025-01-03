using AICode.Contracts;
using AICode.Entities;

namespace AICode.Extensions;

public static class Mapper
{
        public static Expense ToExpense(this CreateExpenseRequest request)
        {
            return new Expense
            {
                Name = request.Name,
                UserId = request.UserId,
                CategoryId = request.CategoryId,
                Amount = request.Amount,
                Date = request.Date,
                Description = request.Description,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false
            };
        }
}
