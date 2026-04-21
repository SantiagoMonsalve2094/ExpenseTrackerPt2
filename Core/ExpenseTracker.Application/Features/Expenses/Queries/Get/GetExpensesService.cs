using ExpenseTracker.Application.Contracts.Persistence;
using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Application.Features.Expenses.Queries.Get;

public class GetExpensesService
{
    private readonly IExpenseRepository _expenseRepository;

    public GetExpensesService(IExpenseRepository expenseRepository)
    {
        _expenseRepository = expenseRepository;
    }

    public IReadOnlyCollection<Expense> GetExpenses()
    {
        return _expenseRepository.GetAll();
    }

    public Expense? GetExpenseById(Guid id)
    {
        return _expenseRepository.GetById(id);
    }
}
