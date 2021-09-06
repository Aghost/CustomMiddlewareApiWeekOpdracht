using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CustomMiddleware.Business.Interfaces
{
    public interface ISecurityService
    {
        string GenerateToken(Claim[] claim);
        string GenerateSalt();
        string ComputeHash(string password, string salt);
    }
}
