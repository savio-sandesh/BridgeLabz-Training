namespace BusinessLayer.Helpers
{
    // Contract/Interface defining password hashing and cryptographic verification operations
    public interface IPasswordHasher
    {
        // Hashes a plain-text password using a secure one-way algorithm with automatic salt
        string Hash(string password);

        // Verifies a plain-text password against a previously generated hash
        bool Verify(string password, string hash);
    }

    // Concrete implementation utilizing the BCrypt library for secure credential handling
    public class PasswordHasher : IPasswordHasher
    {
        // Generates a salted BCrypt hash from the plain-text password
        // public string Hash(string password) => BCrypt.Net.BCrypt.HashPassword(password);

        public string Hash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        // Validates whether the incoming plain-text password matches the stored BCrypt hash
        // public bool Verify(string password, string hash) => BCrypt.Net.BCrypt.Verify(password, hash);

        public bool Verify(string password,string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password,hash);
        }
    }
}