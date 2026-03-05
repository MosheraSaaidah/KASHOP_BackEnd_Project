using KAShop.DAL.DTO.Request;
using KAShop.DAL.DTO.Response;
using KAShop.DAL.Models;
using Mapster;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAShop.BLL.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AuthenticationService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<RegisterResponse> RegisterUser(RegisterRequest request)
        {
            var user = request.Adapt<ApplicationUser>();
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            { 
                return new RegisterResponse
                {
                    Success = false,
                    Message = "User registration failed: "
                };
            }return new RegisterResponse
                {
                    Success = true,
                    Message = "User registered successfully"
                };
            
           
        }
    }
}
