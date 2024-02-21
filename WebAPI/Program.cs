using Business.DependencyResolvers;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddBusinessServices(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


Core.Utilities.Security.JWT.TokenOptions? tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<Core.Utilities.Security.JWT.TokenOptions>();
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true, // Issuer'ı validate etmeli mi?
            ValidateAudience = true,// Audience'ı validate etmeli mi?
            ValidateLifetime = true, // Süreyi validate etmeli mi?
            ValidateIssuerSigningKey = true, // Security key validate etmeli mi?
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey)), // Valid security key değeri
            ValidIssuer = tokenOptions.Issuer,// Valid Issuer değeri
            ValidAudience = tokenOptions.Audience,// Valid Audience değeri
        };
    });

var app = builder.Build();

//if (app.Environment.IsProduction())
    app.UseGlobalExceptionHandling();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
