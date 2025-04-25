using AuthRoleManager.Api.Extentions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureDbContexts(builder.Configuration);
builder.Services.ConfigureRepositories(builder.Configuration);

builder.Services.AddControllers();

// JWT Authentication sozlamalari
var authConfig = builder.Configuration.GetSection("Authentication");
string key = authConfig["SecurityKey"];

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = authConfig["Issuer"],
        ValidAudience = authConfig["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
    };
});

// Swagger konfiguratsiyasi (token kiritish uchun)
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AuthRoleManager API", Version = "v1" });

    // JWT token Swagger UI da kiritish uchun konfiguratsiya
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Token kiriting. Masalan: Bearer {token}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.HeadContent = @"
        <style>
            /* Swagger UI umumiy fon va shrift */
            body, .swagger-ui {
                background-color: white !important;
                font-size: 16px !important;
                font-family: 'Segoe UI', sans-serif !important;
            }

            /* Curl preview qismi (requestning ko‘rinishi) */
            .curl-command {
                background-color: #fff0f5 !important;
                color: black !important;
                border-radius: 8px;
                padding: 10px;
                font-family: monospace;
                font-size: 16px !important;
            }

            /* Curl ichidagi barcha matnlar qora bo‘lsin va 16px */
            .curl-command * {
                color: black !important;
                font-size: 16px !important;
            }

            /* Response body qismi */
            .responses-wrapper .microlight {
                background-color: #f0f8ff !important;
                color: black !important;
                border-radius: 8px;
                padding: 10px;
                font-size: 16px !important;
                font-family: monospace;
            }

            /* Kod bloklari uchun border */
            .highlight-code {
                border: 1px solid #ccc;
                border-radius: 6px;
                font-size: 16px !important;
            }

            /* Input, tugma va boshqa elementlar */
            input, select, textarea, label, .parameter__name, .btn, .authorize {
                font-size: 16px !important;
            }

            /* Sarlavhalar va matnlar */
            .opblock-tag,
            .opblock-summary-description,
            .responses-wrapper,
            .response-col_status,
            .response-col_description {
                font-size: 16px !important;
            }
        </style>
    ";
    });

}

app.UseHttpsRedirection();

// Middleware larni tartib bilan joylashtirish muhim
app.UseAuthentication(); // <-- Tokenni tekshiradi
app.UseAuthorization();  // Role va policy asosida ruxsatni tekshiradi

app.MapControllers();

app.Run();
