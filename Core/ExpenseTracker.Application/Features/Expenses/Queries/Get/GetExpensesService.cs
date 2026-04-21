using ExpenseTracker.Application.Contracts.Persistence;
using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Application.Features.Expenses.Queries.Get;

public class GetExpensesService
{
    private readonly IExpenseRepository _expenseRepository;

    public GetExpensesService(IExpenseRepository expenseRepository)
    {
        _expenseRepository = expenseRepository;
    }

    public IReadOnlyCollection<Expense> GetExpenses()
    {
        return _expenseRepository.GetAll();
    }

    public IReadOnlyCollection<Expense> GetExpensesWithFilter(GetExpensesFilterDto filter)
    {
        IEnumerable<Expense> expenses = _expenseRepository.GetAll();

        if (!string.IsNullOrWhiteSpace(filter.Category))
        {
            expenses = expenses.Where(expense =>
                expense.Category.Equals(filter.Category, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(filter.PaymentMethod))
        {
            expenses = expenses.Where(expense =>
                expense.PaymentMethod.Equals(filter.PaymentMethod, StringComparison.OrdinalIgnoreCase));
        }

        if (filter.Date.HasValue)
        {
            expenses = expenses.Where(expense => expense.Date.Date == filter.Date.Value.Date);
        }

        return expenses.ToList();
    }

    public Expense? GetExpenseById(Guid id)
    {
        return _expenseRepository.GetById(id);
    }
}
