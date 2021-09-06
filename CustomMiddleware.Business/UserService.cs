using System;
using System.Collections.Generic;
using System.Security.Claims;
using CustomMiddleware.Business.Interfaces;

namespace CustomMiddleware.Business
{
    public class UserService : IUserService
    {
        public string Login(string username, string password)
        {
            if (username == "test" && password == "test12345!@#$%"){
                var arr = new Claim[] {
                    new Claim("UserId", "1"),
                    new Claim(ClaimTypes.Name, username)
                };
                string tmp = SecurityService.GenerateToken(arr);
                //return SecurityService.GenerateToken(arr);
            }else{
                throw new UnauthorizedAccessException();
            }

            return "done";
        }
    }
}
