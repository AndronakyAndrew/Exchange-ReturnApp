using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange_ReturnApp
{
    public class User
    {
        public int userId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public User() { }

        public User(string name, string password, string email)
        {
            this.Name = name;
            this.Password = password;
            this.Email = email;
        }

    }
}
