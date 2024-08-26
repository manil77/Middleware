using Application.Interfaces.UnitOfWork;
using Application.Services.UnitOfWork;
using Infrastructure.Interfaces.UnitOfWork;
using Infrastructure.Repository.UnitOfWork;
using Infrastructure.SQLHelper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAppUnitOfWork, AppUnitOfWork>();
builder.Services.AddScoped<IRepositoryUnitOfWork, RepositoryUnitOfWork>();
builder.Services.AddScoped<ISQLHelper, SQLHelper>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
