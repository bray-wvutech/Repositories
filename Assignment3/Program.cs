using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Assignment3.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    // secure anything in the Pages/Items folder 
    // by assigning it the admin policy
    // which we created above 
    // saying it requires a user to have the admin role
    options.Conventions.AuthorizeFolder("/Movies", "AdminPolicy");
});


builder.Services.AddScoped<IMovieRepository, MovieRepositoryEf>();

builder.Services.AddDbContext<Assignment3Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Assignment3Context") ?? throw new InvalidOperationException("Connection string 'Assignment3Context' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => 
    options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<Assignment3Context>();

builder.Services.AddAuthorization(options =>
{
    // in our authorization options we add a policy
    // that requires the user to have the admin role
    options.AddPolicy("AdminPolicy", policy =>
    {
        policy.RequireRole("Admin");
    });
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

app.UseAuthorization();

app.MapRazorPages();

// next add this code
// this will run every time our website starts up
// we need to create a scope here to get access to our ServiceProvider
// which lets us get access to the RoleManager and UserManager
// using ensures everything gets disposed of properly when we are done
using (var scope = app.Services.CreateScope())
{
    var roleManager =
        scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    // check if we already have an admin role
    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        // if not make the admin role
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    }

    // now we are going to make a default admin user
    var userManager =
        scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

    string email = "admin@mostuff.com";
    // DANGER! PASSWORD MUST BE:
    // 6+ chars
    // at least one non alphanumerc character
    // at least one digit ('0'-'9')
    // at least one uppercase ('A'-'Z')
    string password = "Password123!";

    // see if we have already created the user
    // if not create them and give them the admin role
    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new IdentityUser
        {
            UserName = email,
            Email = email,
            EmailConfirmed = true
        };
        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "Admin");
    }
}

app.Run();
