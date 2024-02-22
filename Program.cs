using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddRazorPages();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    await context.Database.MigrateAsync();

    // Seed database with initial roles
    if (!context.Roles.Any())
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
        await roleManager.CreateAsync(new IdentityRole("Employee"));
    }

    // Seed database with an initial user
    if (!context.Users.Any())
    {
        var persona = new Persona
        {
            NombreCompleto = "Admin",
            CUIL = "20345678901",
            FechaNacimiento = new DateTime(2000, 10, 18),
            Genero = Genero.Masculino,
            EstadoCivil = EstadoCivil.Soltero,
            Domicilio = "Direccion 2",
            Hijos = 0,
            FechaIngreso = DateTime.Now
        };

        var user = new ApplicationUser
        {
            UserName = "admin@localhost",
            Email = "admin@localhost",
            EmailConfirmed = true,
            Persona = persona
        };
        await userManager.CreateAsync(user, "181020");
        await userManager.AddToRoleAsync(user, "Admin");
    }

    // Seed database with an initial empresa
    if (!context.Empresas.Any())
    {
        var empresa = new Empresa
        {
            CUIT = "12345678901",
            Nombre = "StockCar",
            Categoria = "Comercio",
            Direccion = "Direccion 1",
            Telefono = "123456789",
            Email = "stockcar@localhost",
            FechaRegistro = DateTime.Now
        };
        context.Empresas.Add(empresa);
        await context.SaveChangesAsync();
    }
}

app.Run();