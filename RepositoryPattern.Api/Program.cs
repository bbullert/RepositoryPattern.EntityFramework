using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Core;
using RepositoryPattern.Data;
using RepositoryPattern.Data.Contexts;
using RepositoryPattern.Data.Infrastructure;
using RepositoryPattern.Data.Interceptors;
using RepositoryPattern.Seed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
        options.InvalidModelStateResponseFactory = context =>
        {
            var problemDetailsFactory = context.HttpContext.RequestServices.GetRequiredService<ProblemDetailsFactory>();
            ValidationProblemDetails problemDetails = problemDetailsFactory.CreateValidationProblemDetails(context.HttpContext, context.ModelState, 422);

            return new ObjectResult(problemDetails)
            {
                StatusCode = 422
            };
        }
    )
    .AddNewtonsoftJson();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRepositories();
builder.Services.AddUnitsOfWork();
builder.Services.AddServices();
builder.Services.AddSeedServices();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
        .AddInterceptors(new AuditInterceptor<Audit, Guid, IAuditable, Guid>());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors(builder => builder
        .WithOrigins("http://localhost:5000", "https://localhost:5001")
        .WithOrigins("http://localhost:8080", "https://localhost:8080")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
