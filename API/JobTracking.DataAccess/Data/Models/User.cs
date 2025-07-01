using System.ComponentModel.DataAnnotations;
using JobTracking.DataAccess.Data.Base;
using JobTracking.Domain.Enums;

namespace JobTracking.DataAccess.Data.Models
{
    /// <summary>
    /// Represents a user in the job tracking system.
    /// </summary>
    public class User : IEntity
    {
        /// <summary>
        /// Unique identifier for the user.
        /// </summary>
        [Key]
        public int Id { get; set; }

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
        /// Username used for login.
        /// </summary>
        [Required, StringLength(32)]
        public string Username { get; set; }

        /// <summary>
        /// Hashed password for user authentication.
        /// </summary>
        [Required, StringLength(128)]
        public string Password { get; set; }

        /// <summary>
        /// Role assigned to the user (e.g., Admin, RegularUser).
        /// </summary>
        [Required]
        public UserRoleEnum Role { get; set; }

        /// <summary>
        /// Indicates whether the user account is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Timestamp when the user was created.
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Identifier of who created the user record.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Timestamp when the user was last updated.
        /// </summary>
        public DateTime? UpdatedOn { get; set; }

        /// <summary>
        /// Identifier of who last updated the user record.
        /// </summary>
        public string? UpdatedBy { get; set; }

        /// <summary>
        /// Collection of job applications submitted by the user.
        /// </summary>
        public virtual ICollection<JobApplication> Applications { get; set; } = new List<JobApplication>();
    }
}