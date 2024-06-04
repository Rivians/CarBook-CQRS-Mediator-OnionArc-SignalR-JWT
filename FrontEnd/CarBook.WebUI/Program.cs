using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
{
    opt.LoginPath = "/Login/Index/";
    opt.LogoutPath = "/Login/Logout/";
    opt.AccessDeniedPath = "/Pages/AccessDenied/";

    // SameSite: Çerezin sadece ayný site içindeki isteklerde gönderilmesini saðlar. Bu, CSRF (Cross-Site Request Forgery) saldýrýlarýna karþý koruma saðlar.
    opt.Cookie.SameSite = SameSiteMode.Strict;

    // HttpOnly: Çerezin sadece HTTP istekleri ile eriþilebilir olmasýný saðlar, böylece JavaScript gibi istemci tarafýnda eriþimi engellenir. Bu, XSS (Cross-Site Scripting) saldýrýlarýna karþý ek bir güvenlik katmaný saðlar.
    opt.Cookie.HttpOnly = true;

    // SecurePolicy özelliði, çerezin yalnýzca HTTPS istekleriyle gönderilmesini saðlar. SameAsRequest deðeri, çerezin isteðin güvenli olup olmadýðýna göre ayarlanacaðýný belirtir. Yani, istek HTTPS ise çerez de güvenli olacaktýr.
    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;

    opt.Cookie.Name = "CarBookJwt";
});

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
	  name: "areas",
	  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
	);
});

app.Run();
