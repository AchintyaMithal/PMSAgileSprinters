using AuthorizationAPI.Models;
using AuthorizationAPI.Repository;
using AuthorizationAPI.Repository.IRepository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : Controller
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(typeof(AuthenticateController));
        public AuthenticateController(IConfiguration config, IAuthRepository repo)
        {
            _repo = repo;
            _config = config;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody]LoginModel user)
        {
            try
            {
                IActionResult response = Unauthorized();
                if (user==null)
                {
                    return BadRequest();
                }
                _logger.Info(nameof(Login) + $"method invoked, Username: " + user.Username);
                Customer customer = _repo.CheckCredentials(user);
                if(customer!=null)
                {
                    string tokenVal = _repo.GenerateToken(_config, customer);
                    //customer.token = tokenVal;
                    if (tokenVal != null)
                    {
                        //_log4net.Info("Token received.");
                        response = Ok(new { tokenString = tokenVal , portfolioId = customer.PortfolioId ,customerName=customer.CustomerName});
                    }
                    //log4net.Info("Response is given user is authorized or unauthorized.");
                    return response;
                   
                }
                return Unauthorized("Invalid Credentials");
            }
            catch(Exception e)
            {
                _logger.Info("Error Occured from " + nameof(Login) + " Error Message : " + e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}
