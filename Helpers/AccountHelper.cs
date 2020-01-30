using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;

namespace agos_api.Helpers
{
    public interface IAccountHelper
    {
        bool IsValidPassword (string password);
        string GenerateJwtToken (string userName, IList<string> role);
    }

    public class AccountHelper : IAccountHelper
    {
        private readonly IConfiguration _config;

        public AccountHelper(
            IConfiguration config
            )
        {
            _config = config;
        }
        public bool IsValidPassword (string password)
        {
            Match check1, check2, check3, check4;
            Regex regex = new Regex(@"([A-Z]+)");
            check1 = regex.Match(password);
            regex = new Regex(@"([a-z]+)");
            check2 = regex.Match(password);
            regex = new Regex(@"([0-9]+)");
            check3 = regex.Match(password);
            regex = new Regex(@"([@#$%]+)");
            check4 = regex.Match(password);

            bool isValidPass = false;
            if ((check4.Success) && (check2.Success) && (check3.Success) && (check4.Success) && ((password.Length > 6) && (password.Length <= 255)))
            {
                isValidPass = true;
            }
            return isValidPass;
        }

        public string GenerateJwtToken (string userName, IList<string> role)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Role, role[0])
            };
            var keyByte = Encoding.UTF8.GetBytes(_config["JwtToken:KEY"]);
            var signInKey = new SymmetricSecurityKey(keyByte);
            var expireHours = DateTime.Now.AddHours(Convert.ToDouble(_config["JwtToken:ExpireHours"]));
            var token = new JwtSecurityToken(
                audience: _config["JwtToken:AUDIENCE"],
                issuer: _config["JwtToken:ISSUER"],
                claims: claims,
                expires: expireHours,
                signingCredentials: new SigningCredentials(signInKey, SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // public dynamic ValidateCurrentToken(string token)
        // {
        //     var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["JwtToken:KEY"]));
        //     var tokenHandler = new JwtSecurityTokenHandler();
        //     try
        //     {
        //         tokenHandler.ValidateToken(token, new TokenValidationParameters
        //         {
        //             ValidateIssuerSigningKey = true,
        //             ValidateIssuer = true,
        //             ValidateAudience = true,
        //             ValidIssuer = _config["JwtToken:ISSUER"],
        //             ValidAudience = _config["JwtToken:AUDIENCE"],
        //             IssuerSigningKey = key
        //         }, out SecurityToken validatedToken);
        //     }
        //     catch
        //     {
        //         return BadRequest();
        //     }
        //     return Ok();
        // }
    }
}