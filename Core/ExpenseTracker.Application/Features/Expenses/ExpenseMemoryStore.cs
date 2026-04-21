using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Application.Features.Expenses;

public class ExpenseMemoryStore
{
    public List<Expense> Expenses { get; } = [];
}
