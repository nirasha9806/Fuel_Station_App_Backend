using Microsoft.Extensions.Options;
using backend.Models;
using MongoDB.Driver;
using backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<StoreDatabaseSettings>(
                builder.Configuration.GetSection(nameof(StoreDatabaseSettings)));

builder.Services.AddSingleton<IStoreDatabseSettings>(sp => 
    sp.GetRequiredService<IOptions<StoreDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s => 
        new MongoClient(builder.Configuration.GetValue<string>("StoreDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();
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
