
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Identity K�sm�nda Dependency Injection Yapt���m�z ��in Buraya IoC container�na servisimiz ekledik.
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<WriterUser,WriterRole>().AddEntityFrameworkStores<Context>();

builder.Services.AddControllersWithViews();

///Proje seviyesinde rolleme yapabilmek i�in gerekli ayarlar� eklendi
///Authenticate olmu� kullan�c� olup olmad���n� kontrol ediyor
///E�er de�ilse Acoount/Login route etmeye �al���yor fakat biz kendi belirledi�imiz bir path'e root etmek istersek a�a��sana bir servis metodu daha yazaca��z AddAuthentication.

builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddMvc();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(3);
    options.LoginPath = "/User/Login/Index/";
    options.AccessDeniedPath = "/ErrorPage/Index/";
}
);

//rolleme ayarlar� sonu

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//StatusCode sayfalar� 404 vs...
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404/");
//StatusCode sayfalar�


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
