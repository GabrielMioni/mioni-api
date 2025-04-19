using Microsoft.EntityFrameworkCore;
using Mioni_Api.Data;
using Mioni_Api.GraphQL.Mutations;
using Mioni_Api.GraphQL.Queries;
using Mioni_Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("Default");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Missing required connection string: 'Default'. Check your appsettings.json or environment variables.");
}

builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(connectionString));

builder.Services.AddScoped<ProjectService>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType(d => d.Name("Query"))
    .AddTypeExtension<ProjectQueries>()
    .AddMutationType(d => d.Name("Mutation"))
    .AddTypeExtension<ProjectMutations>()
    .AddFiltering()
    .AddProjections()
    .AddSorting();

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
app.MapGraphQL();

app.Run();
