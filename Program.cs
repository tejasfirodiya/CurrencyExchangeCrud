using CurrencyExchangeCrud;
using CurrencyExchangeCrud.Data;
using CurrencyExchangeCrud.Repositories.Interfaces;
using CurrencyExchangeCrud.Repositories;
using Microsoft.EntityFrameworkCore;
using CurrencyExchangeCrud.Services.Interfaces;
using CurrencyExchangeCrud.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddScoped<ICountryRepository, CountryRespository>();
builder.Services.AddScoped<ICountryAppService, CountryAppService>();

builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();
builder.Services.AddScoped<ICurrencyAppService, CurrencyAppService>();

builder.Services.AddScoped<ICurrencyExchangeRateRepository, CurrencyExchangeRateRepository>();
builder.Services.AddScoped<ICurrencyExchangeRateAppService, CurrencyExchangeRateAppService>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console().WriteTo.File(@"C:\Users\TejasFirodiya\Desktop\Test3\CurrencyExchangeCrud\Logs\Log.txt"));

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
