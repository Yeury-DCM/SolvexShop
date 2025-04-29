using SolvexShop.Infrastructure.Persistence;
using SolvexShop.Core.Application;
using SolvexShop.Infrastructure.Identity;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

 builder.Services.AddPersistenceLayer(builder.Configuration);
 builder.Services.AddIdentityLayer(builder.Configuration);
builder.Services.ApplicationLayerGenericConfiguration();
builder.Services.AddApplicationLayer();
builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache();


var app = builder.Build();

//Seed default users
await app.Services.RunSeedAsync(builder.Configuration);


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

app.UseSession();
app.UseRouting();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}")
    .WithStaticAssets();


app.Run();
