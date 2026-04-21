using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Application.Features.Expenses.Commands.Create;

public class CreateExpenseService
{
    private readonly List<Expense> _expenses;

    public CreateExpenseService(List<Expense> expenses)
    {
        _expenses = expenses;
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

        _expenses.Add(newExpense);

        return newExpense;
    }
}
