using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Threadnos_API.Application.Mappings;
using Threadnos_API.Application.Services.Abstraction;
using Threadnos_API.Application.Services.Implementation;
using Threadnos_API.Domain.IRepositories;
using Threadnos_API.Infrastructure.Persistence;
using Threadnos_API.Infrastructure.Persistence.Repositories;
using Threadnos_API.Presentation.Middleware.YourNamespace.Middlewares;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
    .UseSnakeCaseNamingConvention());

builder.Services.AddSingleton(new MapperConfiguration(cfg =>
{
    cfg.AddProfile<DefaultMapper>();
}).CreateMapper());

builder.Services.AddScoped<IThreadlineService, ThreadlineService>();

builder.Services.AddScoped<IThreadlineRepository, ThreadlineRepository>();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
