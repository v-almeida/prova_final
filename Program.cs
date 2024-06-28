using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Servico.Data;
// Include this if using Entity Framework Core

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers(); // AddControllers is necessary for controller-based APIs

// Add other services like DbContext, SwaggerGen, etc.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ServicoDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 26))));

// Configure app
var app = builder.Build();

// Configure middleware pipeline
if (app.Environment.IsDevelopment())
{
    // Enable Swagger UI
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API v1"));
}

app.UseHttpsRedirection();

app.MapPost("/servicos", async (ServicoDbContext DbContext, Trabalho newServico) =>
{
    DbContext.Trabalhos.Add(newServico);
    DbContext.SaveChanges(); // SaveChanges is synchronous, no need to await
    return Results.Created($"/servicos/{newServico.Id}", newServico);
});


// Add authorization and routing
app.UseAuthorization();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // Map controllers for API endpoints
});

app.Run();




