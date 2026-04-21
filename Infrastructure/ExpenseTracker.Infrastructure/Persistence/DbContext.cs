using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Infrastructure.Persistence;

public class DbContext
{
    public List<Expense> Expenses { get; } = [];
}
