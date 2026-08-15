using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using PingAFreelancerApplication;
using PingAFreelancerInfrastructure;
using PingAFreelancerInfrastructure.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.Configure<JwtBearerOptions>(
    JwtBearerDefaults.AuthenticationScheme,
    options => options.TokenValidationParameters.RoleClaimType = "roles");

builder.Services.AddCors(options =>
    {
        options.AddPolicy("Spa", policy => policy
            .WithOrigins(builder.Configuration["ClientOrigin"]!)
            .AllowAnyHeader()
            .AllowAnyMethod());
    });

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddAuthorization();
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PingAFreelancerContext>();
    await db.Database.MigrateAsync();
    await DbInitializer.SeedFreelancersAsync(db);
    try
    {
        await db.Database.OpenConnectionAsync();
        Console.WriteLine("connected");
        await db.Database.CloseConnectionAsync();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        if (ex.InnerException != null)
        {
            Console.WriteLine(ex.InnerException.Message);
        }
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors("Spa");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await app.RunAsync();