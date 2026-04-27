using ExpenseTracker.Application.Features.Expenses.Commands.Create;
using ExpenseTracker.Application.Features.Expenses.Commands.Update;
using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Application.Interfaces;

public interface IExpenseTrackerService
{
    Expense RegisterExpense(CreateExpenseDto expense);
    IReadOnlyCollection<Expense> GetExpenses();
    Expense? GetExpenseById(Guid id);
    Expense? UpdateExpense(Guid id, UpdateExpenseDto expense);
    bool DeleteExpense(Guid id);
}
