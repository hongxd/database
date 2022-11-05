namespace database.Utils
{
    public class JwtHelper
    {

        public string SecKey { get; set; }
        public int ExpireSeconds { get; set; }

        //private readonly string? Jwt;

        //public string Encode()
        //{
        //    JwtSecurityTokenHandler tokenHandler = new();
        //    TokenValidationParameters valParam = new();
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
        //    valParam.IssuerSigningKey = securityKey;
        //    valParam.ValidateIssuer = false;
        //    valParam.ValidateAudience = false;
        //    var claimsPrincipal = tokenHandler.ValidateToken(Jwt,
        //        valParam, out var secToken);
        //    foreach (var claim in claimsPrincipal.Claims)
        //    {
        //        Console.WriteLine($"{claim.Type}={claim.Value}");
        //    }

        //    return "";
        //}
    }
}
