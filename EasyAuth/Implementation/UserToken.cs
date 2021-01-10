using EasyAuth.Interfaces;
using System;
using System.Text.Json;

namespace EasyAuth.Implementation
{
    public class UserToken : IUserToken
    {
        private IUser user;

        public UserToken(IUser user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));
        }

        public IUser DeserializeUser(string serializedUser)
        {
            return JsonSerializer.Deserialize<IUser>(serializedUser);
        }

        public IUser GetUser()
        {
            return user;
        }

        public string SerializeUser()
        {
            return JsonSerializer.Serialize(user);
        }
    }
}