using JobTracking.Domain.Enums;

namespace JobTracking.Domain.DTOs.Response
{
    /// <summary>
    /// Data Transfer Object representing user details in responses.
    /// </summary>
    public class UserResponseDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier of the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the user's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the user's middle name.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the user's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the role assigned to the user.
        /// </summary>
        public UserRoleEnum Role { get; set; }
    }
}