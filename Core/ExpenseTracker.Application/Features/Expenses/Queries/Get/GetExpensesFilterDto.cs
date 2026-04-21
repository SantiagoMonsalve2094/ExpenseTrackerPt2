namespace ExpenseTracker.Application.Features.Expenses.Queries.Get;

public class GetExpensesFilterDto
{
    public string? Category { get; set; }
    public string? PaymentMethod { get; set; }
    public DateTime? Date { get; set; }
}
