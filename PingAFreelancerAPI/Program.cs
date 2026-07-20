using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using PingAFreelancerApplication;
using PingAFreelancerApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient.Extensions.Azure;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddApplication(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PingAFreelancerContext>();
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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();