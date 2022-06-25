using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Mehovoi_Eskiz.Core
{
    public class SessionClass
    {
        public SessionClass(string login, string password)
        {
            Login = login;
            Password = password;
        }
        public string Login { get; set; }

        public string Password { get; set; }

        public string IsAdmin { get; set; }

    }
}
