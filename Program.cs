using System.Text;
using database;
using database.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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
        if (jwt == null) throw new Exception("没有在appsetting中配置jwt字段");
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
builder.Services.AddCors(opt => { opt.AddPolicy("cors", p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()); });

// 配置url端口为8868，没配置默认5000
var hostUrl = builder.Configuration.GetValue<string>("HostUrl") ?? "";
builder.WebHost.UseUrls(hostUrl);

var app = builder.Build();

app.MapControllers();
//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("cors");

app.Run();