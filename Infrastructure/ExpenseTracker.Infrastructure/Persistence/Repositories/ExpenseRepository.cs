using ExpenseTracker.Application.Contracts.Persistence;
using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Infrastructure.Persistence.Repositories;

public class ExpenseRepository : IExpenseRepository
{
    private readonly DbContext _dbContext;

    public ExpenseRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IReadOnlyCollection<Expense> GetAll()
    {
        return _dbContext.Expenses;
    }

    public Expense? GetById(Guid id)
    {
        return _dbContext.Expenses.FirstOrDefault(expense => expense.Id == id);
    }

    public void Add(Expense expense)
    {
        _dbContext.Expenses.Add(expense);
    }

    public void Update(Expense expense)
    {
        Expense? existingExpense = GetById(expense.Id);

        if (existingExpense is null)
        {
            return;
        }

        existingExpense.Description = expense.Description;
        existingExpense.Amount = expense.Amount;
        existingExpense.Date = expense.Date;
        existingExpense.Category = expense.Category;
        existingExpense.PaymentMethod = expense.PaymentMethod;
    }

    public bool Delete(Guid id)
    {
        Expense? existingExpense = GetById(id);

        if (existingExpense is null)
        {
            return false;
        }

        _dbContext.Expenses.Remove(existingExpense);
        return true;
    }
}
