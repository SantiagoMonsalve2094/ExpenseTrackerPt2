using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Application.Features.Expenses.Queries.GetAll;

public class GetAllExpensesService
{
    private readonly List<Expense> _expenses;

    public GetAllExpensesService(List<Expense> expenses)
    {
        _expenses = expenses;
    }

    public IReadOnlyCollection<Expense> GetExpenses()
    {
        return _expenses;
    }
}
