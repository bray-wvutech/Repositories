using Api;
using Assignment3.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



// WE SETUP OUR DEPENDENCIES HERE JUST LIKE IN THE WEBSITE
// NOTE WE ALSO NEED TO SETUP THE CONNECTION STRING IN THIS PROJECT TOO
builder.Services.AddScoped<IMovieRepository, MovieRepositoryEf>();

builder.Services.AddDbContext<Assignment3Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Assignment3Context") ?? throw new InvalidOperationException("Connection string 'Assignment3Context' not found.")));




// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// WE MAP ALL OF OUR ENDPOINTS HERE IN A FUNCTION CALL
RepositoryEndpoints.MapEndpoints(app);

app.Run();
