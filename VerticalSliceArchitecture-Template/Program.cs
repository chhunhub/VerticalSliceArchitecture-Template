using Data;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using SharedKernel;
using VerticalSliceArchitecture_Template.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
var configuration = builder.Configuration;
builder.Services.AddMediatorR(typeof(VerticalSliceArchitectureDbContext).Assembly);
//Inject DbContext
string connectionString = configuration.GetConnectionString("DataBase")!;
builder.Services.AddDbContext<VerticalSliceArchitectureDbContext>(configure =>
{
    configure.UseSqlServer(connectionString);
});
builder.Services.AddScoped<IUnitOfWork>(db => db.GetRequiredService<VerticalSliceArchitectureDbContext>());
//Persistence

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
