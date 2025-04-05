using ContactApp_WebAPI.Data;
using ContactApp_WebAPI.GlobalException;
using ContactApp_WebAPI.Interface.IRepository;
using ContactApp_WebAPI.Interface.IServices;
using ContactApp_WebAPI.Mapper;
using ContactApp_WebAPI.Repository;
using ContactApp_WebAPI.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();

builder.Services.AddScoped<IUserServices , UserServices>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IContactService, ContactServices>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();

builder.Services.AddScoped<IContactDetailsServices, ContactDetailServices>();
builder.Services.AddScoped<IContactDetailsRepository , ContactDetailsRepository>();

builder.Services.AddExceptionHandler<GlobalNotFoundException>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddExceptionHandler<GlobalNotFoundException>();
builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddDbContext<MyContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(_ => { });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
