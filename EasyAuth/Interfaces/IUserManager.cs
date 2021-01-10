namespace EasyAuth.Interfaces
{
    public interface IUserManager
    {
        public bool Login(string userName, string plainTextPassword);

        public void Logout();

        public bool TryGetUser(out IUser user);

        public bool HasUser();

        public bool IsGranted(params string[] roles);

        public string CreateUserToken(IUser user);
    }
}