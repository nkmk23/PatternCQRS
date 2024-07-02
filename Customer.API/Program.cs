using Customer.Application.Handlers;
using Customer.Domain.Interfaces.Infrastructure;
using Customer.Infrastructure.Data;
using Customer.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>(provider =>
    new CustomerRepository(provider.GetRequiredService<AppDbContext>(), builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<CreateCustomerCommandHandler>();
builder.Services.AddTransient<DeleteCustomerCommandHandler>();
builder.Services.AddTransient<UpdateCustomerCommandHandler>();
builder.Services.AddTransient<GetCustomerByIdQueryHandler>();
builder.Services.AddTransient<GetAllCustomersQueryHandler>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
