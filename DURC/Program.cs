using DURC.Data;
using DURC.Filters;
using DURC.Middlewares;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using System.Threading;

var builder = WebApplication.CreateBuilder(args);


// global action filter : call for every API request
builder.Services.AddControllers(options => {
    options.Filters.Add<LogActiviteFilter>();
    }
);
gi 


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (builder.Environment.IsDevelopment())
{
    // read from a json file 

    //builder.Configuration.AddJsonFile("config.json");

    builder.Services.AddDbContext<ApplicationDbContext>(options => options
        .UseSqlServer(builder.Configuration.GetConnectionString("constr")));

}



var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

//app.UseMiddleware<RateLimitingMiddleware>();
//app.UseMiddleware<ProfilingMiddleware>();

app.MapControllers();
app.Run();
