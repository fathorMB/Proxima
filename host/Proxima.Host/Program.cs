﻿
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Proxima.Host.Data;
using Proxima.Host.Fakes;
using Proxima.Host.Interfaces;
using Proxima.Host.Services;
using System.Text;

namespace Proxima.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add CORS and define a policy that allows the Angular dev server
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularDev",
                    policy => policy
                        .WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });

            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddScoped<IClusterService, FakeClusterService>();
            }
            else
            {
                builder.Services.AddScoped<IClusterService, ClusterService>();
            }

            // Add services to the container.
            // Add EF Core with an In-Memory database
            builder.Services.AddDbContext<AuthDbContext>(options =>
                options.UseInMemoryDatabase("AuthDb"));

            // Configure JWT Authentication
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                var secretKey = builder.Configuration["JwtSettings:Secret"] ?? "SuperSecretKey12345";
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["JwtSettings:Issuer"] ?? "ProximaIssuer",
                    ValidAudience = builder.Configuration["JwtSettings:Audience"] ?? "ProximaAudience",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });
            builder.Services.AddAuthorization();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Use CORS middleware. Make sure it’s placed before authentication/authorization if needed.
            app.UseCors("AllowAngularDev");

            // Ensure the in‑memory database is created (and seed data is applied)
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AuthDbContext>();
                dbContext.Database.EnsureCreated();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                //app.UseHttpsRedirection();
            }

            // Enable authentication and authorization middleware
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
