using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Application.Features.Expenses.Commands.Create;

public class CreateExpenseService
{
    private readonly ExpenseMemoryStore _expenseMemoryStore;

    public CreateExpenseService(ExpenseMemoryStore expenseMemoryStore)
    {
        _expenseMemoryStore = expenseMemoryStore;
    }

    public Expense RegisterExpense(CreateExpenseDto expenseDto)
    {
        Expense newExpense = new()
        {
            Id = Guid.NewGuid(),
            Description = expenseDto.Description,
            Amount = expenseDto.Amount,
            Date = expenseDto.Date,
            Category = expenseDto.Category,
            PaymentMethod = expenseDto.PaymentMethod
        };

        _expenseMemoryStore.Expenses.Add(newExpense);

        return newExpense;
    }
}
