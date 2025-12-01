using API;
using Backend.Database.DatabaseHandlers;
using Backend.GameLogic.Game;
using Backend.GameLogic.Player;
using Backend.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IGameAPI, GameAPI>();
builder.Services.AddScoped<IGame, Game>();
builder.Services.AddScoped<IPlayer, PlayerImpl>();
//builder.Services.AddScoped<IDatabase, DatabaseHandler>();

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
    pattern: "{controller=Game}/{action=IntroScreen}/{id?}")
    .WithStaticAssets();


app.Run();
