using Microsoft.EntityFrameworkCore;
using MovieApp.Components;
using MovieApp.DataAccess;
using MovieApp.GraphQL;
using MovieApp.Interfaces;
using MovieApp.model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPooledDbContextFactory<MovieDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("MovieDB") ?? throw new InvalidOperationException("Connection string 'MovieDB' not found.")));

builder.Services.AddScoped<IMovie, MovieDataAccessLayer>();

builder.Services.AddGraphQLServer().AddQueryType<MovieQueryResolver>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapGraphQL();

app.Run();
