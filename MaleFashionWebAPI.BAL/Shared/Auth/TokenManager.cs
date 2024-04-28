using MaleFashoin_WebAPI.DAL.MaleFashionDB;
using MaleFashoin_WebAPI.Domain.DTO_s.UserMgmt;
using MaleFashoin_WebAPI.Domain.StatusCodes.JWT;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion_WebAPI.BAL.Shared.Auth
{
    public class TokenManager : ITokenManager
    {
        private readonly string _key;
        private readonly byte[] _secret;
        private readonly JwtTokenConfig _jwtTokenConfig;

        public TokenManager(JwtTokenConfig jwtTokenConfig)
        {
            // Initialize private fields with provided values
            _key = jwtTokenConfig.Secret;
            _jwtTokenConfig = jwtTokenConfig;
            _secret = Encoding.ASCII.GetBytes(jwtTokenConfig.Secret);

        }

        public async Task<string> GenerateTokenAsync(CreateAccountRequest request, string userId)
        {
            // Create a JwtSecurityTokenHandler
            var tokenHandler = new JwtSecurityTokenHandler();

            // Create a byte array from the secret key
            var tokenKey = Encoding.ASCII.GetBytes(_key);

            // Create a SecurityTokenDescriptor that defines the token's properties
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    // Add claims such as user's email, first name, and username to the token\
                    new Claim(JwtRegisteredClaimNames.Actort, userId),
                    new Claim(JwtRegisteredClaimNames.UniqueName,request.UserName),
                    new Claim(JwtRegisteredClaimNames.Actort, request.Password),
                }),
                Expires = DateTime.UtcNow.AddHours(1), // Token expiration time (1 hour)
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256),
            };

            // Create a token based on the descriptor
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // Return the generated token as a string
            return await Task.FromResult(tokenHandler.WriteToken(token));
        }
    }
}
