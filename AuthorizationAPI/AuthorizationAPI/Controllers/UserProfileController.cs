using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AuthorizationAPI.Models;

namespace AuthorizationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<Customer> _userManager;
        public UserProfileController(UserManager<Customer> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        //GET : /api/UserProfile
        public async Task<Object> GetUserProfile() {
            string userId = User.Claims.First(c => c.Type == "Username").Value;
            var user = await _userManager.FindByIdAsync(userId);

            return new
            {
                user.PortfolioId

        };
           
        }
    }
}