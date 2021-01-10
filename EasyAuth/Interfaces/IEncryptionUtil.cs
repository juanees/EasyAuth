namespace EasyAuth.Interfaces
{
    public interface IEncryptionUtil
    {
        public string EncryptPassword(string plainTextPassword);

        public bool IsPasswordValid(string plainTextPassword, string hashedPassword);
    }
}