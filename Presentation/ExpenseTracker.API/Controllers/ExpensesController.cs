using ExpenseTracker.Application.Features.Expenses.Commands.Create;
using ExpenseTracker.Application.Features.Expenses.Commands.Delete;
using ExpenseTracker.Application.Features.Expenses.Commands.Update;
using ExpenseTracker.Application.Features.Expenses.Queries.Get;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    private readonly CreateExpenseService _createExpenseService;
    private readonly UpdateExpenseService _updateExpenseService;
    private readonly DeleteExpenseService _deleteExpenseService;
    private readonly GetExpensesService _getExpensesService;

    public ExpensesController(
        CreateExpenseService createExpenseService,
        UpdateExpenseService updateExpenseService,
        DeleteExpenseService deleteExpenseService,
        GetExpensesService getExpensesService)
    {
        _createExpenseService = createExpenseService;
        _updateExpenseService = updateExpenseService;
        _deleteExpenseService = deleteExpenseService;
        _getExpensesService = getExpensesService;
    }

    [HttpGet]
    public IActionResult GetExpenses()
    {
        return Ok(_getExpensesService.GetExpenses());
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetExpenseById(Guid id)
    {
        var expense = _getExpensesService.GetExpenseById(id);

        if (expense is null)
        {
            return NotFound();
        }

        return Ok(expense);
    }

    [HttpPost]
    public IActionResult RegisterExpense([FromBody] CreateExpenseDto expense)
    {
        var newExpense = _createExpenseService.RegisterExpense(expense);

        return CreatedAtAction(nameof(GetExpenseById), new { id = newExpense.Id }, newExpense);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateExpense(Guid id, [FromBody] UpdateExpenseDto expense)
    {
        var updatedExpense = _updateExpenseService.UpdateExpense(id, expense);

        if (updatedExpense is null)
        {
            return NotFound();
        }

        return Ok(updatedExpense);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteExpense(Guid id)
    {
        var deleted = _deleteExpenseService.DeleteExpense(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
