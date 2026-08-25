using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using PingAFreelancerApplication;
using PingAFreelancerInfrastructure;
using PingAFreelancerInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using PingAFreelancerInfrastructure.Identity;
using PingAFreelancerApplication.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.Configure<JwtBearerOptions>(
    JwtBearerDefaults.AuthenticationScheme,
    options => options.TokenValidationParameters.RoleClaimType = "roles");

builder.Services.AddAuthorization();
builder.Services.AddRequiredScopeAuthorization();

builder.Services.AddCors(options =>
    {
        options.AddPolicy("PafSpa", policy => policy
            .WithOrigins(builder.Configuration.GetSection("Cors:AllowedOrigins")!.Get<string[]>()!)
            .AllowAnyHeader()
            .AllowAnyMethod());
    });

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICurrentUser, CurrentUser>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();
if (app.Configuration.GetValue<bool>("RunMigrationsAtStartup"))
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<PingAFreelancerContext>();
    try
    {
        await db.Database.MigrateAsync();
        await DbInitializer.SeedFreelancersAsync(db);
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

app.MapOpenApi();

app.UseHttpsRedirection();
app.UseRouting();

app.UseCors("PafSpa");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await app.RunAsync();