using BookShop;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using BookShop.Shared;
using BookShop.Utility;
using BookShop.Services;
using FluentValidation;
using Blazorise.FluentValidation;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<CookieHelper>();
builder.Services.AddScoped<ToastHelper>();

builder.Services.AddSingleton<ShopFilterStateContainer>();
builder.Services.AddSingleton<UserLoginStateContainer>();
builder.Services.AddSingleton<LocalStorageService>();
builder.Services.AddSingleton<ShopCartService>();

builder.Services
	.AddBlazorise(options =>
	{
		options.Immediate = true;
	})
	.AddBootstrap5Providers()
	.AddFontAwesomeIcons()
	.AddBlazoriseFluentValidation();

builder.Services.AddValidatorsFromAssembly(typeof(App).Assembly);

var app = builder.Build();

ApiCallService.Configure(app.Services.GetRequiredService<IConfiguration>(), app.Services.GetRequiredService<CookieHelper>());

await app.RunAsync();
