using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmLightSample.Model;
namespace MvvmLightSample.Service
{
    public class AuthenticateHelper
    {
        public static bool  Authenticate(User model)
        {
            if (model.Username == "123" && model.Password == "123")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
