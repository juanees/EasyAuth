namespace EasyAuth.Interfaces
{
    public interface IUserManager
    {
        public IUserToken? GetUserToken();

        public bool HasUserToken();

        public bool IsGranted(params string[] roles);

        public IUserToken CreateUserToken(IUser user);

        public bool Login(string userName, string plainTextPassword);

        public void Logout();

        public IEncryptionUtil EncryptionUtil { get; }
    }
}