using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
    /// <summary>
    /// Interface for password hashing operations
    /// </summary>
    public interface IPasswordHasher
    {
        /// <summary>
        /// Hash a password using BCrypt
        /// </summary>
        string HashPassword(string password);

        /// <summary>
        /// Verify a password against a hash
        /// </summary>
        bool VerifyPassword(string password, string passwordHash);
    }
}
