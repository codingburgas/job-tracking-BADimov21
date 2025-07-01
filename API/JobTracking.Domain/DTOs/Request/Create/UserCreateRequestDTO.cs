using System.ComponentModel.DataAnnotations;
using JobTracking.Domain.Enums;

namespace JobTracking.Domain.DTOs.Request.Create
{
    /// <summary>
    /// Data Transfer Object for creating a new user.
    /// Contains personal details, login credentials, and role.
    /// </summary>
    public class UserCreateRequestDTO
    {
        /// <summary>
        /// User's first name.
        /// </summary>
        [Required, StringLength(64)]
        public string FirstName { get; set; }

        /// <summary>
        /// User's middle name.
        /// </summary>
        [Required, StringLength(64)]
        public string MiddleName { get; set; }

        /// <summary>
        /// User's last name.
        /// </summary>
        [Required, StringLength(64)]
        public string LastName { get; set; }

        /// <summary>
        /// Username for login.
        /// </summary>
        [Required, StringLength(32)]
        public string Username { get; set; }

        /// <summary>
        /// Password for authentication.
        /// </summary>
        [Required, StringLength(128)]
        public string Password { get; set; }

        /// <summary>
        /// Role assigned to the user.
        /// </summary>
        [Required]
        public UserRoleEnum Role { get; set; }
    }
}