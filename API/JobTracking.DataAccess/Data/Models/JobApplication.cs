using System.ComponentModel.DataAnnotations;
using JobTracking.DataAccess.Data.Base;
using JobTracking.Domain.Enums;

namespace JobTracking.DataAccess.Data.Models
{
    /// <summary>
    /// Represents a job application submitted by a user for a specific job advertisement.
    /// </summary>
    public class JobApplication : IEntity
    {
        /// <summary>
        /// Unique identifier for the job application.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Identifier of the user who submitted the application.
        /// </summary>
        [Required]
        public int UserId { get; set; }

        /// <summary>
        /// Identifier of the job advertisement to which the user applied.
        /// </summary>
        [Required]
        public int JobAdId { get; set; }

        /// <summary>
        /// Current status of the job application.
        /// </summary>
        [Required]
        public ApplicationStatusEnum Status { get; set; }

        /// <summary>
        /// Indicates whether the job application is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Date and time when the application was created.
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Identifier of the user or system who created the application.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Date and time when the application was last updated.
        /// </summary>
        public DateTime? UpdatedOn { get; set; }

        /// <summary>
        /// Identifier of the user or system who last updated the application.
        /// </summary>
        public string? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property to the related user entity.
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// Navigation property to the related job advertisement entity.
        /// </summary>
        public virtual JobAd JobAd { get; set; }
    }
}