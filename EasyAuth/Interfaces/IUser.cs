namespace EasyAuth.Interfaces
{
    public interface IUser
    {
        string UserName { get; }

        string[] Roles { get; }

        bool IsEnabled { get; }
    }
}