using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Authentication
{
    public  interface IAuthService
    {
        bool Authenticate(string email, string password, UserRole userRole);
    }
}
