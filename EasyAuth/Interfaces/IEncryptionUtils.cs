namespace EasyAuth.Interfaces
{
    public interface IEncryptionUtils
    {
        //public string EncryptPassword(string plainTextPassword);

        public bool IsPasswordValid(string plainTextPassword, string hashedPassword);
    }
}