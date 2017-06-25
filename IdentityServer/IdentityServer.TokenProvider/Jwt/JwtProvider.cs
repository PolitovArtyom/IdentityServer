using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using IdentityServer.Data.Models;
using Microsoft.IdentityModel.Tokens;

namespace IdentityServer.TokenProvider.Jwt
{
    public class JwtProvider : ITokenProvider
    {
        private readonly string _issuer;
        private readonly TimeSpan _tokenPeriod;

        public JwtProvider(string issuer, TimeSpan period)
        {
            _issuer = issuer;
            _tokenPeriod = period;
        }

        public string Generate(Client client, ClaimsIdentity identity)
        {
            var signingCredentials =
                new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(client.Secret)),
                    SecurityAlgorithms.HmacSha256);

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Audience = client.Identifier,
                SigningCredentials = signingCredentials,
                IssuedAt = DateTime.Now,
                Expires = DateTime.Now + _tokenPeriod,
                Issuer = _issuer
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var plainToken = tokenHandler.CreateToken(securityTokenDescriptor);
            var signedAndEncodedToken = tokenHandler.WriteToken(plainToken);

            return signedAndEncodedToken;
        }
    }
}
