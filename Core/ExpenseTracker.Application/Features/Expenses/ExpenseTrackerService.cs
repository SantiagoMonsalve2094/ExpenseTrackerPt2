using ExpenseTracker.Application.Features.Expenses.Commands.Create;
using ExpenseTracker.Application.Features.Expenses.Commands.Delete;
using ExpenseTracker.Application.Features.Expenses.Commands.Update;
using ExpenseTracker.Application.Features.Expenses.Queries.GetAll;
using ExpenseTracker.Application.Features.Expenses.Queries.GetById;
using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Application.Features.Expenses;

public class ExpenseTrackerService : IExpenseTrackerService
{
    private static readonly List<Expense> _expenses = [];

    public Expense RegisterExpense(CreateExpenseDto expense)
    {
        CreateExpenseService createExpenseService = new(_expenses);

        return createExpenseService.RegisterExpense(expense);
    }

    public IReadOnlyCollection<Expense> GetExpenses()
    {
        GetAllExpensesService getAllExpensesService = new(_expenses);

        return getAllExpensesService.GetExpenses();
    }

    public Expense? GetExpenseById(Guid id)
    {
        GetExpenseByIdService getExpenseByIdService = new(_expenses);

        return getExpenseByIdService.GetExpenseById(id);
    }

    public Expense? UpdateExpense(Guid id, UpdateExpenseDto expense)
    {
        UpdateExpenseService updateExpenseService = new(_expenses);

        return updateExpenseService.UpdateExpense(id, expense);
    }

    public bool DeleteExpense(Guid id)
    {
        DeleteExpenseService deleteExpenseService = new(_expenses);

        return deleteExpenseService.DeleteExpense(id);
    }
}
