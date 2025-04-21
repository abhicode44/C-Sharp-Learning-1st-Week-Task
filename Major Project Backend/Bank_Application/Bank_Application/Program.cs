using Bank_Application.Data;
using Bank_Application.Interface.GernralRepository;
using Bank_Application.Interface.IServices;
using Bank_Application.Model;
using Bank_Application.Repository;
using Bank_Application.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<MyContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IGenericRepository<Admin>, GenericRepository<Admin>>();

builder.Services.AddScoped<IBankService, BankService>();
builder.Services.AddScoped<IGenericRepository<Bank>, GenericRepository<Bank>>();

builder.Services.AddScoped<ICompanyService , CompanyService>();
builder.Services.AddScoped<IGenericRepository<Company>, GenericRepository<Company>>();

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
