using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Support.Host
{
    public class JwtManager
    {

        public static string GenerateToken(List<Claim> claims, int expireMinutes = 200)
        {
            var strkey = Encoding.ASCII.GetBytes("db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==");

            //var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            //var symmetricSecurityKey = new SymmetricSecurityKey(Convert.FromBase64String(StrSymmetricKey));
            //var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
            //var securityTokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(claims),
            //    Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireMinutes)),
            //    SigningCredentials = signingCredentials,
            //    IssuedAt = DateTime.Now,
            //};
            var JWToken = new JwtSecurityToken(
           issuer: "http://localhost:57358/",
           audience: "http://localhost:57358/",
           claims: claims,
           notBefore: new DateTimeOffset(DateTime.Now).DateTime,
           expires: new DateTimeOffset(DateTime.Now.AddDays(1)).DateTime,
           //Using HS256 Algorithm to encrypt Token
           signingCredentials: new SigningCredentials(new SymmetricSecurityKey(strkey),
                               SecurityAlgorithms.HmacSha256Signature)
       );
            var token = new JwtSecurityTokenHandler().WriteToken(JWToken);
            return token;
        }

        public static ClaimsPrincipal GetPrincipal(string token)
        {

            var strkey = Encoding.ASCII.GetBytes("db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==");

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                    return null;

                var symmetricKey = strkey;

                var validationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
                };

                SecurityToken securityToken;
                var principal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);

                return principal;
            }

            catch (Exception)
            {
                return null;
            }
        }
    }
}
