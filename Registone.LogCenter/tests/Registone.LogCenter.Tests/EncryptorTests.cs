using Registone.LogCenter.Services;
using Xunit;

namespace Registone.LogCenter.Tests
{
    public class EncryptorTests
    {
        private string password = "password";
        private string encrypted = "pl+5KGt8fIN9+T1v2yJxaA==";

        [Fact]
        public void Encrypt_Successfully()
        {
            var encryptor = new Encryptor();

            var result = encryptor.Encrypt(password);

            Assert.Equal(encrypted, result);
        }

        [Fact]
        public void Decrypt_Successfully()
        {
            var encryptor = new Encryptor();

            var result = encryptor.Decrypt("pl+5KGt8fIN9+T1v2yJxaA==");

            Assert.Equal(password, result);
        }
    }
}
