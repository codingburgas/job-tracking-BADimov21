using JobTracking.DataAccess.Data.Models;
using JobTracking.Domain.DTOs.Request.Create;
using JobTracking.Domain.DTOs.Request.Update;
using JobTracking.Domain.DTOs.Response;
using JobTracking.Domain.Filters;
using JobTracking.Domain.Filters.Base;

namespace JobTracking.Application.Contracts.Base
{
    /// <summary>
    /// Defines service methods for managing users.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Retrieves all users with pagination.
        /// </summary>
        Task<List<User>> GetAllUsers(int page, int pageCount);

        /// <summary>
        /// Retrieves a specific user by ID.
        /// </summary>
        Task<UserResponseDTO?> GetUser(int userId);

        /// <summary>
        /// Creates a new user.
        /// </summary>
        Task<UserResponseDTO> CreateUser(UserCreateRequestDTO dto);

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        Task<bool> UpdateUser(UserUpdateRequestDTO dto);

        /// <summary>
        /// Deletes a user by ID.
        /// </summary>
        Task<bool> DeleteUser(int id);

        /// <summary>
        /// Retrieves filtered and paginated users based on specified criteria.
        /// </summary>
        Task<IQueryable<UserResponseDTO>> GetFilteredUsers(BaseFilter<UserFilter> filter);
    }
}