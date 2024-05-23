
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Identity Kýsmýnda Dependency Injection Yaptýðýmýz Ýçin Buraya IoC containerýna servisimiz ekledik.
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<WriterUser,WriterRole>().AddEntityFrameworkStores<Context>();

builder.Services.AddControllersWithViews();

///Proje seviyesinde rolleme yapabilmek için gerekli ayarlarý eklendi
///Authenticate olmuþ kullanýcý olup olmadýðýný kontrol ediyor
///Eðer deðilse Acoount/Login route etmeye çalýþýyor fakat biz kendi belirlediðimiz bir path'e root etmek istersek aþaðýsana bir servis metodu daha yazacaðýz AddAuthentication.

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

//rolleme ayarlarý sonu

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//StatusCode sayfalarý 404 vs...
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404/");
//StatusCode sayfalarý


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
