using ExpenseTracker.Application.Features.Expenses.Commands.Create;
using ExpenseTracker.Application.Features.Expenses.Commands.Delete;
using ExpenseTracker.Application.Features.Expenses.Commands.Update;
using ExpenseTracker.Application.Features.Expenses.Queries.GetAll;
using ExpenseTracker.Application.Features.Expenses.Queries.GetById;
using ExpenseTracker.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    private static readonly List<Expense> _expenses = [];

    [HttpGet]
    public IActionResult GetExpenses()
    {
        GetAllExpensesService getAllExpensesService = new(_expenses);

        return Ok(getAllExpensesService.GetExpenses());
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetExpenseById(Guid id)
    {
        GetExpenseByIdService getExpenseByIdService = new(_expenses);
        var expense = getExpenseByIdService.GetExpenseById(id);

        if (expense is null)
        {
            return NotFound();
        }

        return Ok(expense);
    }

    [HttpPost]
    public IActionResult RegisterExpense([FromBody] CreateExpenseDto expense)
    {
        CreateExpenseService createExpenseService = new(_expenses);
        var newExpense = createExpenseService.RegisterExpense(expense);

        return CreatedAtAction(nameof(GetExpenseById), new { id = newExpense.Id }, newExpense);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateExpense(Guid id, [FromBody] UpdateExpenseDto expense)
    {
        UpdateExpenseService updateExpenseService = new(_expenses);
        var updatedExpense = updateExpenseService.UpdateExpense(id, expense);

        if (updatedExpense is null)
        {
            return NotFound();
        }

        return Ok(updatedExpense);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteExpense(Guid id)
    {
        DeleteExpenseService deleteExpenseService = new(_expenses);
        var deleted = deleteExpenseService.DeleteExpense(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
