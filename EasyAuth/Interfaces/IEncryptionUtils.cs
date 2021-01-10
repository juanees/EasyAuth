namespace EasyAuth.Interfaces
{
    public interface IEncryptionUtils
    {
        //TODO: Maybe add this method: public string EncryptPassword(string plainTextPassword);

        public bool IsPasswordValid(string plainTextPassword, string hashedPassword);
    }
}