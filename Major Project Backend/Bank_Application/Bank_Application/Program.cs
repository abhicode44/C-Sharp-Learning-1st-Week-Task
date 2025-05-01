using System.Text;
using Bank_Application.Data;
using Bank_Application.Helper;
using Bank_Application.Interface.GernralRepository;
using Bank_Application.Interface.IServices;
using Bank_Application.Mapper;
using Bank_Application.Model;
using Bank_Application.Repository;
using Bank_Application.Services;
using CloudinaryDotNet;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// 1. Database Context
builder.Services.AddDbContext<MyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Authentication - JWT
builder.Services.AddAuthentication()
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

// 3. Authorization
builder.Services.AddAuthorization();

// 4. Swagger - With JWT Authorization
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

// 5. Controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// 6. Dependency Injection - Services and Repositories
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IBankService, BankService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IPhotoService, PhotoService>();
builder.Services.AddScoped<IAuditService, AuditService>();

// Generic Repositories
builder.Services.AddScoped<IGenericRepository<Admin>, GenericRepository<Admin>>();
builder.Services.AddScoped<IGenericRepository<Bank>, GenericRepository<Bank>>();
builder.Services.AddScoped<IGenericRepository<Company>, GenericRepository<Company>>();
builder.Services.AddScoped<IGenericRepository<Benificiary>, GenericRepository<Benificiary>>();
builder.Services.AddScoped<IGenericRepository<Transactionn>, GenericRepository<Transactionn>>();
builder.Services.AddScoped<IGenericRepository<Employee>, GenericRepository<Employee>>();
builder.Services.AddScoped<IGenericRepository<SalaryDistribution>, GenericRepository<SalaryDistribution>>();
builder.Services.AddScoped<IGenericRepository<Audit>, GenericRepository<Audit>>();

// 7. HttpContext Accessor
builder.Services.AddHttpContextAccessor();

// 8. Cloudinary Configuration
builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));

var cloudinarySettings = builder.Configuration.GetSection("CloudinarySettings").Get<CloudinarySettings>();
var cloudinaryAccount = new Account(
    cloudinarySettings.CloudName,
    cloudinarySettings.ApiKey,
    cloudinarySettings.ApiSecret
);
var cloudinary = new Cloudinary(cloudinaryAccount);
builder.Services.AddSingleton(cloudinary);

// 9. CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // Angular Frontend URL
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});



// 10. AutoMapper Configuration
builder.Services.AddAutoMapper(typeof(MappingProfile)); // Add AutoMapper Profile



var app = builder.Build();

// Middleware Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
