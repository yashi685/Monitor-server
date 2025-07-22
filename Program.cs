using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();

var app = builder.Build();
app.UseDefaultFiles(); // Enables default.html/index.html
app.UseStaticFiles();  // Serves wwwroot files
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
