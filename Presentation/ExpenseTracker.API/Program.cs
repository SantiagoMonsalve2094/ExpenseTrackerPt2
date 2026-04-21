var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<ExpenseTracker.Infrastructure.Persistence.DbContext>();
builder.Services.AddSingleton<ExpenseTracker.Application.Contracts.Persistence.IExpenseRepository, ExpenseTracker.Infrastructure.Persistence.Repositories.ExpenseRepository>();
builder.Services.AddScoped<ExpenseTracker.Application.Features.Expenses.Commands.Create.CreateExpenseService>();
builder.Services.AddScoped<ExpenseTracker.Application.Features.Expenses.Commands.Update.UpdateExpenseService>();
builder.Services.AddScoped<ExpenseTracker.Application.Features.Expenses.Commands.Delete.DeleteExpenseService>();
builder.Services.AddScoped<ExpenseTracker.Application.Features.Expenses.Queries.Get.GetExpensesService>();

var app = builder.Build();

app.MapControllers();

app.Run();
