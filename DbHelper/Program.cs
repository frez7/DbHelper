using DbHelper.BL.AuthBL.Managers;
using DbHelper.BL.AuthBL.Services;
using DbHelper.BL.Extensions;
using DbHelper.BL.OtherServices;
using DbHelper.BL.ProjectBL;
using DbHelper.DAL.Data;
using DbHelper.DAL.Entities.DbHelper;
using DbHelper.DAL.Entities.Identity;
using DbHelper.WebApi.AuthBL.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddIdentity<Employee, Role>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 5;
});

builder.Services.AddTransient<TokenService>();
builder.Services.AddTransient<AuthManager>();
builder.Services.AddTransient<GetUserService>();
builder.Services.AddTransient<ValidateService>();
builder.Services.AddTransient<ProjectManager>();
builder.Services.AddTransient<EmployeeManager>();
builder.Services.AddTransient<FilterService>();
builder.Services.AddTransient<TaskManager>();
builder.Services.AddTransient<ProjectEmployeeManager>();

builder.Services.AddTransient<IRepository<Employee>, Repository<Employee>>();
builder.Services.AddTransient<IRepository<IdentityUserRole<int>>, Repository<IdentityUserRole<int>>>();
builder.Services.AddTransient<IRepository<Project>, Repository<Project>>();
builder.Services.AddTransient<IRepository<ProjectEmployee>, Repository<ProjectEmployee>>();
builder.Services.AddTransient<IRepository<ProjectTask>, Repository<ProjectTask>>();
builder.Services.AddTransient<ProjectRepository>();
builder.Services.AddTransient<ProjectEmployeeRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "1.0.0",
        Title = "DbHelper API",
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new string[]{}
        }
    });
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
builder.Services.AddAuthentication(opt => {
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"]!,
            ValidAudience = builder.Configuration["Jwt:Audience"]!,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]!))
        };
    });
builder.Services.AddAuthorization(options =>
{
    options.DefaultPolicy =
    new AuthorizationPolicyBuilder
            (JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser()
        .Build();
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "DbHelper");
});

app.ConfigureExceptionHandler();

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
