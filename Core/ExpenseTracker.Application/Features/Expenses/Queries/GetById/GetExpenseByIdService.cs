using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Application.Features.Expenses.Queries.GetById;

public class GetExpenseByIdService
{
    private readonly List<Expense> _expenses;

    public GetExpenseByIdService(List<Expense> expenses)
    {
        _expenses = expenses;
    }

    public Expense? GetExpenseById(Guid id)
    {
        return _expenses.FirstOrDefault(expense => expense.Id == id);
    }
}
