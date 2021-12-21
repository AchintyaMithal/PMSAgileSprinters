using AuthorizationAPI.Repository;
using AuthorizationAPI.Repository.IRepository;
using AuthorizationAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationAPI.Repository
{
    public class AuthRepository : IAuthRepository
    {
        public Customer CheckCredentials(LoginModel user)
        {
            Customer customer = CustomerDetails.Customers.FirstOrDefault(x => x.Username == user.Username && x.Password == user.Password);
            return customer == null ? null : customer;
        }

        public string GenerateToken(IConfiguration _config, Customer customer)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                List<Claim> claims = new List<Claim>()
                {
                    new Claim(JwtRegisteredClaimNames.Sub, customer.PortfolioId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, customer.CustomerName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var token = new JwtSecurityToken(
                    _config["Jwt:Issuer"],
                    _config["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddMinutes(15),
                    signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
