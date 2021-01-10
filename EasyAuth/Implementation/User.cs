using EasyAuth.Interfaces;
using System;

namespace EasyAuth.Implementation
{
    public class User : IUser
    {
        private string userName;
        private string encryptedPassword;
        private string[] roles;
        private bool enabled = false;

        public User(string userName/*, string encryptedPassword*/, bool enabled, params string[] roles)
        {
            this.userName = userName ?? throw new ArgumentNullException(nameof(userName));
            //this.encryptedPassword = encryptedPassword ?? throw new ArgumentNullException(nameof(encryptedPassword));
            this.roles = roles;
            this.enabled = enabled;
        }

        public string UserName => userName;

        //public string Password => encryptedPassword;

        public string[] Roles => roles;

        public bool IsEnabled => enabled;
    }
}