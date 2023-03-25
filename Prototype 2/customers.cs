using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype_2
{
    public class customers
    {
        public string username, password;

        public customers(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        
        public string getUsername()
        {
            return username;
        }

        public string getPassword()
        {
            return password;
        }
    }
}
