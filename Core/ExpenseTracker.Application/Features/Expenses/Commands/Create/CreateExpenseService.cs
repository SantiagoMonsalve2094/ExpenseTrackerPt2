using ExpenseTracker.Application.Contracts.Persistence;
using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Application.Features.Expenses.Commands.Create;

public class CreateExpenseService
{
    private readonly IExpenseRepository _expenseRepository;

    public CreateExpenseService(IExpenseRepository expenseRepository)
    {
        _expenseRepository = expenseRepository;
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

        _expenseRepository.Add(newExpense);

        return newExpense;
    }
}
