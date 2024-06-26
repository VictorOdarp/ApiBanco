using ApiBanco.Data;
using ApiBanco.Interface;
using ApiBanco.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAccountInterface, AccountService>();
builder.Services.AddScoped<IUserInterface, UserService>();

var DefaultConnetion = "server=localhost;userid=root;password=895smigol;database=APIbank;";

builder.Services.AddDbContext<AppBankDbContext>(options =>
{
    options.UseMySql(DefaultConnetion, ServerVersion.AutoDetect(DefaultConnetion));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
