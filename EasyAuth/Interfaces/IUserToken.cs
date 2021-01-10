namespace EasyAuth.Interfaces
{
    public interface IUserToken
    {
        const string DEFAULT_KEY = "AUTH-USER-f8fad5b-d9cb";

        public IUser GetUser();

        public string SerializeUser();

        public IUser DeserializeUser(string serializedUser);
    }
}