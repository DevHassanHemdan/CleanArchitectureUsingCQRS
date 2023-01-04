using Application.IRepositories;
using Application.Repositories;
using HotelListing.Core.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Presistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddOptions();
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddMediatR(typeof(Program).GetTypeInfo().Assembly);
builder.Services.AddScoped(typeof(_IGenericRepository<>), typeof(_GenericRepository<>));
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
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
