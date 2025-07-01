using System.Threading.Tasks;
using JobTracking.Application.Contracts.Base;
using JobTracking.DataAccess.Data.Models;
using JobTracking.DataAccess.Persistance;
using JobTracking.Domain.DTOs.Response;
using Microsoft.EntityFrameworkCore;

namespace JobTracking.Application.Implementation
{
    /// <summary>
    /// Provides authentication services for users.
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Authenticates a user by username and password.
        /// </summary>
        /// <param name="username">Username of the user.</param>
        /// <param name="password">Plain text password to validate.</param>
        /// <returns>UserResponseDTO if authentication succeeds; otherwise null.</returns>
        public async Task<UserResponseDTO?> AuthenticateAsync(string username, string password)
        {
            // Hash the provided password for comparison
            var hashedPassword = PasswordHasher.HashPassword(password);

            // Attempt to find a user matching the username and hashed password
            var userEntity = await _context.Users
                .Where(u => u.Username == username && u.Password == hashedPassword)
                .FirstOrDefaultAsync();

            // Return null if no matching user is found
            if (userEntity is null)
            {
                return null;
            }

            // Map the user entity to a response DTO
            return new UserResponseDTO
            {
                Id = userEntity.Id,
                FirstName = userEntity.FirstName,
                MiddleName = userEntity.MiddleName,
                LastName = userEntity.LastName,
                Username = userEntity.Username,
                Role = userEntity.Role
            };
        }
    }
}