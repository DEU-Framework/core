using Asp.Versioning;
using DEU_Backend;
using DEU_Backend.ConfigureOptions;
using DEU_Backend.Filters;
using DEU_Backend.Hubs;
using DEU_Backend.Services;
using DEU_Lib.Model.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<DepartmentAuthorizationService>();
builder.Services.AddScoped<DepartmentAuthorizeFilter>();
builder.Services.AddScoped<CustomServiceImplFetcherService>();
builder.Services.AddScoped<WaKaService>();
builder.Services.AddScoped<OperationService>();
builder.Services.AddScoped<DepartmentService>();
builder.Services.AddScoped<VehicleService>();
builder.Services.AddScoped<PoiService>();
builder.Services.AddScoped<ChecklistService>();
builder.Services.AddScoped<OperationHub>();
builder.Services.AddSingleton<DatabaseConfigurationService>();

//Database
builder.Services.AddDbContext<DeuDbContext>();

//Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
  // Password settings.
  options.Password.RequireDigit = true;
  options.Password.RequireLowercase = true;
  options.Password.RequireNonAlphanumeric = true;
  options.Password.RequireUppercase = true;
  options.Password.RequiredLength = 8;
  options.Password.RequiredUniqueChars = 1;

  // Lockout settings.
  options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
  options.Lockout.MaxFailedAccessAttempts = 5;
  options.Lockout.AllowedForNewUsers = true;

  // User settings.
  options.User.AllowedUserNameCharacters =
  "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
  options.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<DeuDbContext>()
    .AddDefaultTokenProviders();

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
        ValidIssuer = builder.Configuration["Jwt:ValidIssuer"],
        ValidAudience = builder.Configuration["Jwt:ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SymmetricSecurityKey"] ?? throw new Exception("SymmetricSecurityKey is null.")))
      };
    });

builder.Services.AddAuthorization();

builder.Services.AddApiVersioning(
    options =>
    {
      options.DefaultApiVersion = new ApiVersion(1, 0);
      options.AssumeDefaultVersionWhenUnspecified = true;
      options.ReportApiVersions = true;
      options.ApiVersionReader = new HeaderApiVersionReader("api-version");
    })
  .AddMvc()
  .AddApiExplorer(
    options =>
    {
      options.GroupNameFormat = "'v'VVV";
      options.SubstituteApiVersionInUrl = true;
    });

builder.Services.AddControllers().AddJsonOptions(options =>
{
  options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
  options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
  options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
});
builder.Services.AddSignalR();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
  options =>
  {
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
      In = ParameterLocation.Header,
      Description = "Please enter a valid token",
      Name = "Authorization",
      Type = SecuritySchemeType.Http,
      BearerFormat = "JWT",
      Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement {
      {
        new OpenApiSecurityScheme {
          Reference = new OpenApiReference {
            Type = ReferenceType.SecurityScheme,
              Id = "Bearer"
          }
        },
        Array.Empty < string > ()
      }
    });
  });

builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}
//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapHub<OperationHub>("/Operation");

app.Run();