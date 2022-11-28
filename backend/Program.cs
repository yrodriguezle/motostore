using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

using GraphQL;
using GraphQL.Types;
using GraphQL.MicrosoftDI;

using Motostore.GraphQL;
using Motostore.DataAccess;
using Motostore.Repositories;
using Motostore.Helpers.GraphQLSubscriptions;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDefer();

builder.Services.AddHttpScope();

builder.Services.AddDbContext<DataContext>((options) => {
    string connectionString = builder.Configuration.GetConnectionString("Default");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
    options.MimeTypes = new[] { "application/json", "application/graphql-response+json" };
});

builder.Services.AddSingleton<IEventMessageStack, EventMessageStack>();

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
    .AddDataLoader()
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

app.UseResponseCompression();

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

app.UseWebSockets();

app.UseGraphQL<MotostoreSchema>("/graphql");

app.Run();
