using Business.Configurations;
using Core.Models;
using Data.Contexts;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureApp(builder.Configuration);

builder.Services.AddAuthentication()
    .AddCookie(IdentityConstants.ApplicationScheme);
    
builder.Services.AddAuthorizationBuilder();
builder.Services.AddCors(op =>
{
    op.AddDefaultPolicy(p =>
    {
        p.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services
    .AddIdentityCore<User>()
    .AddRoles<Role>()
    .AddEntityFrameworkStores<ChatContext>()
    .AddApiEndpoints();

var app = builder.Build();

app.MapIdentityApi<User>();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

await app.Services.SeedData();

app.Run();