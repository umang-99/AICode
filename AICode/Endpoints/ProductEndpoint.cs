using AICode.Contracts;
using AICode.Database;
using AICode.Entities;
using AICode.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace AICode.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("products", async (
            CreateExpenseRequest request,
            ApplicationDbContext context,
            CancellationToken ct) =>
        {
            var expense = request.ToExpense();
            context.Add(expense);

            await context.SaveChangesAsync(ct);

            return Results.Ok(expense);
        });

        app.MapGet("products", async (
            ApplicationDbContext context,
            CancellationToken ct,
            int page = 1,
            int pageSize = 10) =>
        {
            var products = await context.Expenses
                .AsNoTracking()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(ct);

            return Results.Ok(products);
        });

        app.MapGet("products/{id}", async (
            int id,
            ApplicationDbContext context,
            IDistributedCache cache,
            CancellationToken ct) =>
        {
            var product = await cache.GetAsync($"products-{id}",
                async token =>
                {
                    var product = await context.Expenses
                        .AsNoTracking()
                        .FirstOrDefaultAsync(p => p.Id == id, token);

                    return product;
                },
                CacheOptions.DefaultExpiration,
                ct);

            return product is null ? Results.NotFound() : Results.Ok(product);
        });

        app.MapPut("products/{id}", async (
            int id,
            UpdateExpenseRequest request,
            ApplicationDbContext context,
            IDistributedCache cache,
            CancellationToken ct) =>
        {
            var product = await context.Expenses
                .FirstOrDefaultAsync(p => p.Id == id, ct);

            if (product is null)
            {
                return Results.NotFound();
            }

            

            await context.SaveChangesAsync(ct);

            await cache.RemoveAsync($"products-{id}", ct);

            return Results.NoContent();
        });

        /*app.MapDelete("products/{id}", async (
            int id,
            ApplicationDbContext context,
            IDistributedCache cache,
            CancellationToken ct) =>
        {
            var product = await context.Products
                .FirstOrDefaultAsync(p => p.Id == id, ct);

            if (product is null)
            {
                return Results.NotFound();
            }

            context.Remove(product);

            await context.SaveChangesAsync(ct);

            await cache.RemoveAsync($"products-{id}", ct);

            return Results.NoContent();
        });*/

        app.MapGet("getSummary", async (
            ApplicationDbContext context,
            IDistributedCache cache,
            CancellationToken ct,
            int? year = null,
            int? month = null) =>
        {
            var product = await cache.GetAsync($"get-summary-for-year-{year}-and-month-{month}",
                async token =>
                {
                    var response = new GetSummaryResponseDto();

                    response.GroupedByCategory = await context.Expenses
                    .Where(e => !e.IsDeleted) // Exclude deleted expenses
                    .GroupBy(e => e.Category.Name)
                    .Select(group => new CategoryGroupDto
                    {
                        Category = group.Key,
                        TotalAmount = group.Sum(e => e.Amount),
                        ExpenseCount = group.Count()
                    })
                    .ToListAsync();

                    var query = context.Expenses
                        .Where(e => !e.IsDeleted); // Exclude deleted expenses

                    // Apply year filter if provided
                    if (year.HasValue)
                    {
                        query = query.Where(e => e.Date.Year == year.Value);
                    }

                    // Apply month filter if provided
                    if (month.HasValue)
                    {
                        query = query.Where(e => e.Date.Month == month.Value);
                    }

                    // Grouping logic based on input parameters
                    // Grouping logic
                    List<object> groupedData;

                    if (year.HasValue && month.HasValue)
                    {
                        // Group by specific dates for the given year and month
                        response.GroupedByDate = await query
                            .GroupBy(e => e.Date.Date)
                            .Select(group => new DateGroupDto
                            {
                                Date = group.Key,
                                TotalAmount = group.Sum(e => e.Amount),
                                ExpenseCount = group.Count()
                            })
                            .ToListAsync();
                    }
                    else if (year.HasValue)
                    {
                        // Group by months for the given year
                        response.GroupedByMonth = await query
                            .GroupBy(e => e.Date.Month)
                            .Select(group => new MonthGroupDto
                            {
                                Month = group.Key,
                                TotalAmount = group.Sum(e => e.Amount),
                                ExpenseCount = group.Count()
                            })
                            .ToListAsync();
                    }
                    else
                    {
                        // Default: Group by years
                        response.GroupedByYear = await query
                            .GroupBy(e => e.Date.Year)
                            .Select(group => new YearGroupDto
                            {
                                Year = group.Key,
                                TotalAmount = group.Sum(e => e.Amount),
                                ExpenseCount = group.Count()
                            })
                            .ToListAsync();
                    }

                    return response;
                },
                CacheOptions.DefaultExpiration,
                ct);

            return product is null ? Results.NotFound() : Results.Ok(product);
        });
    }
}