using System.Text;
using database;
using database.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// 依赖注入
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMemoryCache(); // 使用缓存
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString(@"sqlServer"));
});
builder.Services.AddDataProtection();
builder.Services.Configure<JwtHelper>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        var jwt = builder.Configuration.GetSection("Jwt")
            .Get<JwtHelper>();
        var keyBytes = Encoding.UTF8.GetBytes(jwt.SecKey);
        var secKey = new SymmetricSecurityKey(keyBytes);
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = secKey
        };

    });
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("cors", p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.WebHost.UseUrls("http://localhost:8868"); // 配置url

var app = builder.Build();

app.MapControllers();
//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("cors");

app.Run();
