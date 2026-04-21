using ExpenseTracker.Application.Contracts.Persistence;
using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Application.Features.Expenses.Commands.Update;

public class UpdateExpenseService
{
    private readonly IExpenseRepository _expenseRepository;

    public UpdateExpenseService(IExpenseRepository expenseRepository)
    {
        _expenseRepository = expenseRepository;
    }

    public Expense? UpdateExpense(Guid id, UpdateExpenseDto expenseDto)
    {
        Expense? existingExpense = _expenseRepository.GetById(id);

        if (existingExpense is null)
        {
            return null;
        }

        existingExpense.Description = expenseDto.Description;
        existingExpense.Amount = expenseDto.Amount;
        existingExpense.Date = expenseDto.Date;
        existingExpense.Category = expenseDto.Category;
        existingExpense.PaymentMethod = expenseDto.PaymentMethod;

        _expenseRepository.Update(existingExpense);

        return existingExpense;
    }
}
