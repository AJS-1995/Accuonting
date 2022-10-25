using _0_Framework.Application;
using _01_QueryManagement.Contracts.Favicon;
using _01_QueryManagement.Contracts.Permissions;
using _01_QueryManagement.Contracts.Users;
using _01_QueryManagement.Query;
using AccountManagement.Configuration;
using CompanyManagement.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using MoneyManagement.Configuration;
using ServiceHost;
using System.Text.Encodings.Web;
using System.Text.Unicode;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpContextAccessor();
var connectionString = builder.Configuration.GetConnectionString("Database_DB");
CompanyManagementBootstrapper.Configure(builder.Services, connectionString);
MoneyManagementBootstrapper.Configure(builder.Services, connectionString);
UserManagementBootstrapper.Configure(builder.Services, connectionString);

builder.Services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));
builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
builder.Services.AddTransient<IFileUploader, FileUploader>();
builder.Services.AddTransient<IAuthHelper, AuthHelper>();
builder.Services.AddTransient<IUserQueryModel, UserQuery>();
builder.Services.AddTransient<IPermissionQueryModel, PermissionQuery>();
builder.Services.AddTransient<IFaviconQueryModel, FaviconQuery>();

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.Lax;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
    {
        o.LoginPath = new PathString("/Index");
        o.LogoutPath = new PathString("/Index");
        o.AccessDeniedPath = new PathString("/AccessDenied");
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminArea",
        builder => builder.RequireRole(new List<string> { "1" }));
});

builder.Services.AddCors(options => options.AddPolicy("MyPolicy", builder =>
    builder
        .WithOrigins("/Privacy")
        .AllowAnyHeader()
        .AllowAnyMethod()));
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages()
    .AddMvcOptions(options => options.Filters.Add<SecurityPageFilter>())
    .AddRazorPagesOptions(options =>
    {
        options.Conventions.AuthorizeAreaFolder("Admin", "/", "AdminArea");
    })
    .AddNewtonsoftJson();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();
app.UseRouting();
app.UseAuthorization();
app.UseCors("MyPolicy");
app.MapRazorPages();
app.MapControllers();
app.Run();