using System.Text;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using GraphQL;

using Motostore.GraphQL;
using Motostore.Helpers;
using Motostore.DataAccess;
using Motostore.Repositories;
using Motostore.Services;

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

builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();

builder.Services.AddSingleton<IEventMessageStack, EventMessageStack>();

builder.Services.AddSingleton<MotostoreMiddleware>();

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
    .AddSelfActivatingSchema<MotostoreSchema>()
    .AddGraphTypes(typeof(MotostoreSchema).Assembly));

builder.Services.AddCors((options) => options.AddDefaultPolicy((builder) => builder.WithOrigins("*").AllowAnyHeader()));

builder.Services.AddScoped<IRepository, Repository>();

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

// Configure Jwt authentication
byte[] key = Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt")["Key"]);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer((options) => options
        .TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            RequireExpirationTime = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        });

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseResponseCompression();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseWebSockets();

app.UseGraphQL<MotostoreSchema>("/graphql");

app.Run();
