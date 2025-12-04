using Microsoft.EntityFrameworkCore;
using MockCreditReport.Data;
using MockCreditReport.Repositories;
using MockCreditReport.Services;


var builder = WebApplication.CreateBuilder(args);

// Add EF Core SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<CreditReportRepository>();


builder.Services.AddSingleton<MockCreditReportService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
