namespace ExpenseTracker.Application.Features.Expenses.Commands.Delete;

public class DeleteExpenseService
{
    private readonly ExpenseMemoryStore _expenseMemoryStore;

    public DeleteExpenseService(ExpenseMemoryStore expenseMemoryStore)
    {
        _expenseMemoryStore = expenseMemoryStore;
    }

    public bool DeleteExpense(Guid id)
    {
        var existingExpense = _expenseMemoryStore.Expenses.FirstOrDefault(expense => expense.Id == id);

        if (existingExpense is null)
        {
            return false;
        }

        _expenseMemoryStore.Expenses.Remove(existingExpense);
        return true;
    }
}
