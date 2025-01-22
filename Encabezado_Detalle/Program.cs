using Encabezado_Detalle.BD;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();

//************mqr configuracion de la conexion**************//
ConnetionString.Sql_conexion = builder.Configuration.GetConnectionString("Conexion");
builder.Services.AddDbContext<CotContext>(Options =>
    Options.UseSqlServer(ConnetionString.Sql_conexion)
);

//****************************//

var app = builder.Build();

//*****mqr para Migrar la BD*******///
using (var scope=app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<CotContext>();
    context.Database.Migrate();
}
//*************//

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
