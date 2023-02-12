using LibraryAPI;
using LibraryAPI.Interfaces;
using LibraryAPI.Middlewares;
using LibraryAPI.Models;
using LibraryAPI.Models.Entities;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var DbConnectionString = MyConfig.GetValue<string>("ConnectionStrings:DefaultConnection");

// Header Context

builder.Services.AddScoped<IHeaderContextService, HeaderContextService>();
builder.Services.AddHttpContextAccessor();

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAuditService, AuditService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ILibraryBooksRentalService, LibraryBooksRentalService>();
builder.Services.AddScoped<ILibraryBooksService, LibraryBooksService>();

builder.Services.AddScoped<CustomCookieAuthenticationEvents>();

builder.Services.AddScoped<ErrorHandlingMiddleware>();

builder.Services.AddCors();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(DbConnectionString, builder => {
        builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
    });
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
        options =>
        {
            options.Cookie.SameSite = SameSiteMode.Lax;
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            options.Cookie.HttpOnly = true;
            options.Cookie.Name = "SESSION";
            options.Cookie.IsEssential = true;
            options.EventsType = typeof(CustomCookieAuthenticationEvents);
            options.Events.OnRedirectToLogin = context =>
            {
                context.Response.Headers["Location"] = context.RedirectUri;
                context.Response.StatusCode = 401;
                return Task.CompletedTask;
            };
        });

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => false;
    options.MinimumSameSitePolicy = SameSiteMode.Lax;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//} 

app.UseHttpsRedirection();

// global cors policy
app.UseCors(x => x
    .WithMethods("GET", "POST", "PUT", "PATCH", "DELETE", "OPTIONS", "HEAD")
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials() // allow credentials
    .Build()
);

app.UseCookiePolicy();

app.UseAuthentication();
app.UseAuthorization();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapControllers();

app.Run();
