using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Application.Contracts.Persistence;

public interface IExpenseRepository
{
    IReadOnlyCollection<Expense> GetAll();
    Expense? GetById(Guid id);
    void Add(Expense expense);
    void Update(Expense expense);
    bool Delete(Guid id);
}
