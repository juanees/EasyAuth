using EasyAuth.Interfaces;
using System.Linq;

namespace EasyAuth.Implementation
{
    public class UserManager : IUserManager
    {
        private readonly IAuthenticateUserManager authenticateUser;
        private readonly ISessionUserManager sessionManager;
        
        public UserManager(IAuthenticateUserManager authenticateUser, ISessionUserManager sessionManager)
        {
            this.authenticateUser = authenticateUser;
            
            this.sessionManager = sessionManager;
        }

        public bool Login(string userName, string plainTextPassword)
        {
            if (authenticateUser.TryAuthenticateUser(userName, plainTextPassword, out IUser user))
            {
                return sessionManager.SaveUserToSession(user);
            }
            return false;
        }

        public void Logout()
        {
            sessionManager.RemoveUserFromSession();
        }

        public bool TryGetUser(out IUser user)
        {
            if (sessionManager.TryGetUserFromSession(out user)) 
            {
                return true;
            }
            return false;
        }

        public bool HasUser()
        {
            return TryGetUser(out _);
        }

        public bool IsGranted(params string[] roles)
        {
            if (sessionManager.TryGetUserFromSession(out IUser user))
            {
                return user.Roles.Intersect(roles).Count() > 0;
            }
            return false;
        }

        public string CreateUserToken(IUser user)
        {
            return string.Empty;
        }

    }
}