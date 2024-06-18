using FoodOrderingApp;
using FoodOrderingApp.Components;
using FoodOrderingApp.Interop.TeamsSDK;
using FoodOrderingApp.Data;
using FoodOrderingApp.Interfaces;
using FoodOrderingApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("AppDbContext") ?? throw new InvalidOperationException("Connection string 'AppDbContext' not found"),
        sqlServerOptions => sqlServerOptions.EnableRetryOnFailure())
);

builder.Services.AddQuickGridEntityFrameworkAdapter(); ;

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var config = builder.Configuration.Get<ConfigOptions>();

builder.Services.AddTeamsFx(config.TeamsFx.Authentication);
builder.Services.AddScoped<MicrosoftTeams>();
builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<RestaurantService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<UserService>();

builder.Services.AddControllers();
builder.Services.AddHttpClient("WebClient", client =>
{
    //client.BaseAddress = new Uri("https://eclipse822.webhook.office.com/");
    client.Timeout = TimeSpan.FromSeconds(600);
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddAntiforgery(o => o.SuppressXFrameOptionsHeader = true);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapControllers();
app.Run();