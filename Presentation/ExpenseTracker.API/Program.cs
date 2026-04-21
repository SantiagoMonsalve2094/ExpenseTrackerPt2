var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ExpenseTracker.Application.Features.Expenses.ExpenseMemoryStore>();
builder.Services.AddScoped<ExpenseTracker.Application.Features.Expenses.Commands.Create.CreateExpenseService>();
builder.Services.AddScoped<ExpenseTracker.Application.Features.Expenses.Commands.Update.UpdateExpenseService>();
builder.Services.AddScoped<ExpenseTracker.Application.Features.Expenses.Commands.Delete.DeleteExpenseService>();
builder.Services.AddScoped<ExpenseTracker.Application.Features.Expenses.Queries.Get.GetExpensesService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
