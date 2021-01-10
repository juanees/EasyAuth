namespace EasyAuth.Interfaces
{
    public interface ISessionUserManager
    {
        public string USER_KEY { get; }

        public bool SaveUserToSession(IUser item, bool replace = true);

        public void RemoveUserFromSession();

        public bool TryGetUserFromSession(out IUser item);
    }
}