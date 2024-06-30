using Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Projekt_zaliczeniowy.ServicesClient;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ZooDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ZooDbContext") ?? throw new InvalidOperationException("Connection string 'ZooDbContext' not found")));

builder.Services.AddRazorPages();

var apiBaseUrl = builder.Configuration["ApiSettings:BaseUrl"];

if (string.IsNullOrEmpty(apiBaseUrl))
{
    throw new ArgumentNullException("ApiSettings:BaseUrl", "API Base URL is not configured.");
}

builder.Services.AddHttpClient("ProjektZaliczeniowy", client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
});

builder.Services.AddSingleton<JwtService>();

builder.Services.AddScoped<AuthenticationService>(provider =>
{
    var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
    var httpClient = httpClientFactory.CreateClient("ProjektZaliczeniowy");
    var jwtService = provider.GetRequiredService<JwtService>();
    return new AuthenticationService(httpClient, jwtService);
});

builder.Services.AddScoped<ApiService>(provider =>
{
    var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
    var httpClient = httpClientFactory.CreateClient("ProjektZaliczeniowy");
    var jwtService = provider.GetRequiredService<JwtService>();
    return new ApiService(httpClient, jwtService);
});

builder.Services.AddScoped<ZooUserService>(provider =>
{
    var apiService = provider.GetRequiredService<ApiService>();
    return new ZooUserService(apiService);
});

builder.Services.AddScoped<IAnimalService, AnimalService>(provider =>
{
    var apiService = provider.GetRequiredService<ApiService>();
    return new AnimalService(apiService);
});

builder.Services.AddScoped<IAnimalSponsorService, AnimalSponsorService>(provider =>
{
    var apiService = provider.GetRequiredService<ApiService>();
    return new AnimalSponsorService(apiService);
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddHttpContextAccessor();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOrUserPolicy", policy => policy.RequireRole("Admin", "User"));
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseMiddleware<JwtMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
