using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Y_eShopWeb_Client;
using Y_eShopWeb_Client.Service;
using Y_eShopWeb_Client.Service.IService;

using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Builder;

//var builder = WebApplication.CreateBuilder(args);


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");



builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetValue<string>("BaseAPIUrl")) });
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
//IServiceCollection serviceCollection = 
builder.Services.Configure<ForwardedHeadersOptions>(options => 
{ options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | 
    ForwardedHeaders.XForwardedProto;
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
}) ;


await builder.Build().RunAsync();

//var app = builder.Build();
//builder.Build().UseForwardedHeaders();
//app.UseForwardedHeaders();


////builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetValue<string>("BaseAPIUrl")) });
//builder.Services.AddScoped<IProductService, ProductService>();
//builder.Services.AddScoped<ICartService, CartService>();
//builder.Services.AddScoped<IOrderService, OrderService>();
//builder.Services.AddBlazoredLocalStorage(); 
//await builder.Build().RunAsync();



//using Microsoft.AspNetCore.Components.Web;
//using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
//using Y_eShopWeb_Client;

//var builder = WebAssemblyHostBuilder.CreateDefault(args);
//builder.RootComponents.Add<App>("#app");
//builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//await builder.Build().RunAsync();
