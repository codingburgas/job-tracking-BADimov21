using JobTracking.DataAccess.Data.Models;
using JobTracking.Domain.DTOs.Response;

namespace JobTracking.Application.Contracts.Base
{
    /// <summary>
    /// Defines authentication functionality for verifying user credentials.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Authenticates a user by username and password.
        /// </summary>
        /// <param name="username">The username to authenticate.</param>
        /// <param name="password">The password to verify.</param>
        /// <returns>The authenticated user's response DTO, or null if authentication fails.</returns>
        Task<UserResponseDTO?> AuthenticateAsync(string username, string password);
    }
}