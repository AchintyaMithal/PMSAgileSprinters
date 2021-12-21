using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorizationAPI.Models;
using Microsoft.Extensions.Configuration;

namespace AuthorizationAPI.Repository.IRepository
{
    public interface IAuthRepository
    {
        Customer CheckCredentials(LoginModel user);
        string GenerateToken(IConfiguration _config, Customer customer);
    }
}
