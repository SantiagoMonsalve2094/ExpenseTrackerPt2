using ExpenseTracker.Application.Features.Expenses.Commands.Create;
using ExpenseTracker.Application.Features.Expenses.Commands.Update;
using ExpenseTracker.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    public IExpenseTrackerService expenseTrackerService;

    public ExpensesController(IExpenseTrackerService expenseTrackerService)
    {
        this.expenseTrackerService = expenseTrackerService;
    }

    [HttpGet]
    public IActionResult GetExpenses()
    {
        return Ok(expenseTrackerService.GetExpenses());
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetExpenseById(Guid id)
    {
        var expense = expenseTrackerService.GetExpenseById(id);

        if (expense is null)
        {
            return NotFound();
        }

        return Ok(expense);
    }

    [HttpPost]
    public IActionResult RegisterExpense([FromBody] CreateExpenseDto expense)
    {
        var newExpense = expenseTrackerService.RegisterExpense(expense);

        return CreatedAtAction(nameof(GetExpenseById), new { id = newExpense.Id }, newExpense);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateExpense(Guid id, [FromBody] UpdateExpenseDto expense)
    {
        var updatedExpense = expenseTrackerService.UpdateExpense(id, expense);

        if (updatedExpense is null)
        {
            return NotFound();
        }

        return Ok(updatedExpense);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteExpense(Guid id)
    {
        var deleted = expenseTrackerService.DeleteExpense(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
