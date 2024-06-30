using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using Projekt_zaliczeniowy.ServicesClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;

    public JwtMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, JwtService jwtService)
    {
        var token = jwtService.GetToken();

        if (!string.IsNullOrEmpty(token))
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("hwDtuy5Ii1dybJHrfrb6Fby72xJhauNZOBnkPG+Dbq46foyrz8/Wt96RX2/iKGM+");
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "Kajetan",
                ValidAudience = "Kajetan",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("hwDtuy5Ii1dybJHrfrb6Fby72xJhauNZOBnkPG+Dbq46foyrz8/Wt96RX2/iKGM+"))
            };

            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);
            context.User = principal;
        }

        await _next(context);
    }
}
