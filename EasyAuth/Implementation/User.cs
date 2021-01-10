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

        public User(string userName, bool enabled, params string[] roles)
        {
            this.userName = userName ?? throw new ArgumentNullException(nameof(userName));
            this.roles = roles;
            this.enabled = enabled;
        }

        public string UserName => userName;

        public string[] Roles => roles;

        public bool IsEnabled => enabled;
    }
}