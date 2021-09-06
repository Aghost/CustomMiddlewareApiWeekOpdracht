using System;
using System.Collections.Generic;
using System.Security.Claims;
using CustomMiddleware.Interfaces;
using CustomMiddleware.Services;

namespace CustomMiddleware.Services
{
    public class UserService : IUserService
    {
        private readonly SecurityService securityService;
        public string Login(string username, string password)
        {
            if (username == "test" && password == "test12345!@#$%"){
                var arr = new Claim[] {
                    new Claim("UserId", "1"),
                    new Claim(ClaimTypes.Name, username)
                };
                string tmp = securityService.GenerateToken(arr);

            }else{
                throw new UnauthorizedAccessException();
            }

            return "done";
        }
    }
}
