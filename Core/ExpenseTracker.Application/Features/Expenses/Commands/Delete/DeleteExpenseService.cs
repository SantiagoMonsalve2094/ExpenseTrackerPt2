namespace ExpenseTracker.Application.Features.Expenses.Commands.Delete;

public class DeleteExpenseService
{
    private readonly List<ExpenseTracker.Domain.Entities.Expense> _expenses;

    public DeleteExpenseService(List<ExpenseTracker.Domain.Entities.Expense> expenses)
    {
        _expenses = expenses;
    }

    public bool DeleteExpense(Guid id)
    {
        var existingExpense = _expenses.FirstOrDefault(expense => expense.Id == id);

        if (existingExpense is null)
        {
            return false;
        }

        _expenses.Remove(existingExpense);
        return true;
    }
}
