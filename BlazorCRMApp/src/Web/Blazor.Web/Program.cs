using Blazor.Web.Components;
using Blazor.Web.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Radzen;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddRadzenComponents();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<CustomNotificationService>();

builder.Services.AddRazorPages();

builder.Services.AddHttpContextAccessor();

string apiGatewayURL = "https://localhost:7299/";

builder.Services.AddTransient<IHttpService, HttpService>();

builder.Services.AddHttpClient<IMasterService, MasterService>(client =>
{
    client.BaseAddress = new Uri($"{apiGatewayURL}");
});

builder.Services.AddHttpClient<IUserService, UserService>(client =>
{
    client.BaseAddress = new Uri($"{apiGatewayURL}");
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.Cookie.Name = "auth_token";
        option.LoginPath = "/login";
        option.Cookie.MaxAge = TimeSpan.FromMinutes(30);
        option.AccessDeniedPath = "/access-denied";
    });

builder.Services.AddAuthenticationCore();
builder.Services.AddCascadingAuthenticationState();



var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}




app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


app.UseStatusCodePagesWithRedirects("/not-found");

app.Run();
