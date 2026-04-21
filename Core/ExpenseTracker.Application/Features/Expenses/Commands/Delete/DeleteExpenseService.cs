using ExpenseTracker.Application.Contracts.Persistence;

namespace ExpenseTracker.Application.Features.Expenses.Commands.Delete;

public class DeleteExpenseService
{
    private readonly IExpenseRepository _expenseRepository;

    public DeleteExpenseService(IExpenseRepository expenseRepository)
    {
        _expenseRepository = expenseRepository;
    }

    public bool DeleteExpense(Guid id)
    {
        return _expenseRepository.Delete(id);
    }
}
