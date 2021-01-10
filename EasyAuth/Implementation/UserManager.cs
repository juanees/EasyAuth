using EasyAuth.Interfaces;
using System.Linq;

namespace EasyAuth.Implementation
{
    public class UserManager : IUserManager
    {
        private readonly IAuthenticateUserManager authenticateUserManager;
        private readonly ISessionUserManager sessionUserManager;

        public UserManager(IAuthenticateUserManager authenticateUserManager, ISessionUserManager sessionUserManager)
        {
            this.authenticateUserManager = authenticateUserManager;

            this.sessionUserManager = sessionUserManager;
        }

        public bool Login(string userName, string plainTextPassword)
        {
            if (authenticateUserManager.TryAuthenticateUser(userName, plainTextPassword, out IUser user))
            {
                return sessionUserManager.SaveUserToSession(user);
            }
            return false;
        }

        public void Logout()
        {
            sessionUserManager.RemoveUserFromSession();
        }

        public bool TryGetUser(out IUser user)
        {
            if (sessionUserManager.TryGetUserFromSession(out user))
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
            if (sessionUserManager.TryGetUserFromSession(out IUser user))
            {
                return user.Roles.Intersect(roles).Count() > 0;
            }
            return false;
        }

        public string SerializeUser(IUserSerializationStrategy userSerialization, IUser user)
        {
            return userSerialization.Serialize(user);
        }
    }
}