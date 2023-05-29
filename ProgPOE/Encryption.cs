using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgPOE
{
    public class Encryption
    {
        #region GetRandomSalt
        // (Matskas, 2014)
        private string GetRandomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }
        #endregion

        #region HashPassword
        // (Matskas, 2014)
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, GetRandomSalt());   // Hashing Password using GenerateSalt
        }
        #endregion

        #region ValidatePassword
        // (Matskas, 2014)
        public bool ValidatePassword(string password, string correctHash)    // Takes in user password to validate and compares to hashed original password
        {
            return BCrypt.Net.BCrypt.Verify(password, correctHash);          // Using .Verify to compare user input string(Hashed) to the stored hash password in DB
        }
        #endregion
    }
}
// --------------------------------- .....ooooo00000 END OF FILE 00000ooooo..... --------------------------------- //

// Matskas, C. (2014) A simple .NET password hashing implementation using BCrypt, cmatskas. cmatskas. Available at: https://cmatskas.com/a-simple-net-password-hashing-implementation-using-bcrypt/ (Accessed: August 20, 2022). 
