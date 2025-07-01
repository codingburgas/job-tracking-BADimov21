using System.ComponentModel.DataAnnotations;
using JobTracking.Domain.Enums;

namespace JobTracking.Domain.DTOs.Request.Update
{
    /// <summary>
    /// DTO for updating an existing user.
    /// </summary>
    public class UserUpdateRequestDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier of the user.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the user's first name.
        /// </summary>
        [Required, StringLength(64)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the user's middle name.
        /// </summary>
        [Required, StringLength(64)]
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the user's last name.
        /// </summary>
        [Required, StringLength(64)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the user's username.
        /// </summary>
        [Required, StringLength(32)]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the user's password.
        /// Optional; if null or empty, password remains unchanged.
        /// </summary>
        [StringLength(128)]
        public string? Password { get; set; }

        /// <summary>
        /// Gets or sets the user's role.
        /// </summary>
        [Required]
        public UserRoleEnum Role { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user is active.
        /// </summary>
        public bool IsActive { get; set; }
    }
}