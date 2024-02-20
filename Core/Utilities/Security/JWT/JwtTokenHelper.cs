using Core.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class JwtTokenHelper : ITokenHelper
    {
        private IConfiguration _configuration;
        private TokenOptions _tokenOptions;

        public JwtTokenHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _tokenOptions = _configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public AccessToken CreateToken(User user)
        {
            // TODO: Refactor
            DateTime expirationTime = DateTime.Now.AddMinutes(_tokenOptions.ExpirationTime);
            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            JwtSecurityToken jwt = new JwtSecurityToken(
                 issuer: _tokenOptions.Issuer,
                 audience: _tokenOptions.Audience,
                 expires: expirationTime,
                 signingCredentials: signingCredentials,
                 notBefore: DateTime.Now
                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            string token = handler.WriteToken(jwt);

            return new AccessToken()
            {
                Token = token,
                ExpirationTime = expirationTime,
            };
        }
    }
}
