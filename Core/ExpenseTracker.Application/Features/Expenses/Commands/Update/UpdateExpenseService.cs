using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Application.Features.Expenses.Commands.Update;

public class UpdateExpenseService
{
    private readonly ExpenseMemoryStore _expenseMemoryStore;

    public UpdateExpenseService(ExpenseMemoryStore expenseMemoryStore)
    {
        _expenseMemoryStore = expenseMemoryStore;
    }

    public Expense? UpdateExpense(Guid id, UpdateExpenseDto expenseDto)
    {
        Expense? existingExpense = _expenseMemoryStore.Expenses.FirstOrDefault(expense => expense.Id == id);

        if (existingExpense is null)
        {
            return null;
        }

        existingExpense.Description = expenseDto.Description;
        existingExpense.Amount = expenseDto.Amount;
        existingExpense.Date = expenseDto.Date;
        existingExpense.Category = expenseDto.Category;
        existingExpense.PaymentMethod = expenseDto.PaymentMethod;

        return existingExpense;
    }
}
