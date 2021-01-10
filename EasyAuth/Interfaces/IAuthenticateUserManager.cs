namespace EasyAuth.Interfaces
{
    public interface IAuthenticateUserManager : IEncryptionUtils
    {
        public bool TryAuthenticateUser(string userName, string plainTextPassword, out IUser user);
    }
}