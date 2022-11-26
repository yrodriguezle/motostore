using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

using GraphQL;
using GraphQL.Types;
using GraphQL.MicrosoftDI;

using Motostore.GraphQL;
using Motostore.DataAccess;
using Motostore.Repositories;
using Motostore.Models;
using GraphQL.Instrumentation;
using Motostore.Helpers.GraphQLSubscriptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDefer();

builder.Services.AddHttpScope();

builder.Services.AddDbContext<DataContext>((options) => {
    string connectionString = builder.Configuration.GetConnectionString("Default");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

//builder.Services.AddAuthentication(JwtBearerDefaults);

builder.Services.AddSingleton<IEntitySubscription, EntityDetails>();

//builder.Services.AddSingleton<IEntitySubscription, EntityDetails>();

builder.Services.AddSingleton<MotostoreMiddleware>();

builder.Services.AddSingleton<ISchema, MotostoreSchema>(services => new MotostoreSchema(new SelfActivatingServiceProvider(services)));

builder.Services.AddGraphQL(b => b
    .ConfigureExecution(async (options, next) => {
        var timer = Stopwatch.StartNew();
        var result = await next(options);
        result.Extensions ??= new Dictionary<string, object?>();
        result.Extensions["elapsedMs"] = timer.ElapsedMilliseconds;
        return result;
    })
    .AddSystemTextJson()
    .AddSchema<MotostoreSchema>()
    .AddGraphTypes(typeof(MotostoreSchema).Assembly));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("*")
                   .AllowAnyHeader();
        });
});

builder.Services.AddScoped<IRepository, Repository>();

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

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.UseGraphQL<ISchema>();

app.Run();
