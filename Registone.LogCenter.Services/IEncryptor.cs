namespace Registone.LogCenter.Services
{
    public interface IEncryptor
    {
        string Encrypt(string password);
        string Decrypt(string password);
    }
}
