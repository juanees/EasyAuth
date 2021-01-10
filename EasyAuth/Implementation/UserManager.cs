using EasyAuth.Interfaces;
using System;
using System.Linq;

namespace EasyAuth.Implementation
{
    public class UserManager : IUserManager
    {
        private readonly Func<string, string, bool> authenticateUser;
        private readonly Func<IUserToken> getUserFromSession;
        private readonly Action<IUserToken> saveUserToSession;
        private readonly Action logOutUser;
        private readonly EncryptionUtil encryptionUtil;

        public UserManager(Func<string, string, bool> authenticateUser, Func<IUserToken> getUserFromSession, Action<IUserToken> saveUserToSession, Action logOutUser)
        {
            this.authenticateUser = authenticateUser ?? throw new ArgumentNullException(nameof(authenticateUser));
            this.getUserFromSession = getUserFromSession ?? throw new ArgumentNullException(nameof(getUserFromSession));
            this.saveUserToSession = saveUserToSession ?? throw new ArgumentNullException(nameof(saveUserToSession));
            this.logOutUser = logOutUser ?? throw new ArgumentNullException(nameof(logOutUser));
            this.encryptionUtil = new EncryptionUtil();
        }

        public IEncryptionUtil EncryptionUtil => encryptionUtil;

        public bool Login(string userName, string plainTextPassword)
        {
            return authenticateUser(userName, plainTextPassword);
        }

        public IUserToken CreateUserToken(IUser user)
        {
            var userToken = new UserToken(user);
            saveUserToSession(userToken);
            return userToken;
        }

        public IUserToken GetUserToken()
        {
            var user = getUserFromSession();
            return user;
        }

        public bool HasUserToken()
        {
            return getUserFromSession() != default;
        }

        public bool IsGranted(params string[] roles)
        {
            var user = getUserFromSession();
            if (user == default || user.GetUser() == default)
            {
                return false;
            }
            return user.GetUser().Roles.Intersect(roles).Count() > 0;
        }

        public void Logout()
        {
            logOutUser();
        }
    }
}