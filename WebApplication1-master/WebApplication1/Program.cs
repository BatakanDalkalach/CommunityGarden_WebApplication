using Microsoft.EntityFrameworkCore;
using WebApplication1.DatabaseContext;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add MVC services
builder.Services.AddControllersWithViews();

// Configure database with connection string
var connectionString = builder.Configuration.GetConnectionString("GardenDbConnection") 
    ?? "Data Source=CommunityGarden.db";

// Use SQLite for better compatibility (or SQL Server if LocalDB is available)
builder.Services.AddDbContext<CommunityGardenDatabase>(options =>
{
    if (connectionString.Contains("localdb") || connectionString.Contains("sqlexpress", StringComparison.OrdinalIgnoreCase))
    {
        options.UseSqlServer(connectionString);
    }
    else
    {
        options.UseSqlite(connectionString);
    }
});

// Register application services
builder.Services.AddScoped<PlotManagementService>();
builder.Services.AddScoped<MemberManagementService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
