using System;
using System.Collections.Generic;
using System.Linq;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CustomMiddleware
{
    public class JWTMiddleware
    {
        private void AttachUserToContext(HttpContext context, string token)
        {
            try {
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("abcdefghijklmnopqrstuvwxyz"));
                tokenHandler.ValidateToken(token, new TokenValidationParameters {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = securityKey,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                if (context.User != null) {
                    var Claims = new List<Claim>
                    {
                        new Claim("userId", jwtToken.Claims.First(x => x.Type =="userId").Value)
                    };

                    var identity = new ClaimsIdentity(Claims);
                    context.User.AddIdentity(identity);
                }
            }catch(Exception e){
                Console.WriteLine(e);
            }
        }
    }
}
