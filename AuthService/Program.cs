using AuthService;
using AuthService.Core.Interfaces;
using AuthService.Core.Services;
using JwtAuthenticationManager;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.WithOrigins("*")
            .WithHeaders("*")
            .WithMethods("*")
            .WithExposedHeaders("*"));
});


// Add services to the container
builder.Services.AddControllers();
builder.Services.AddSingleton<JwtTokenHandler>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//--------- Database Context Dependency injection ---------//

var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_USER_PASSWORD");
var connectionString = $"server={dbHost};port=3306;database={dbName};user=root;password={dbPassword}";

builder.Services.AddDbContext<UserAccountDbContext>(o => o.UseMySQL(connectionString));

//--------- ----------------------------------- ---------//
var app = builder.Build();
app.UseCors("CorsPolicy");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();