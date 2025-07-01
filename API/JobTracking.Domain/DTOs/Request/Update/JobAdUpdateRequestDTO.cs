using System.ComponentModel.DataAnnotations;

namespace JobTracking.Domain.DTOs.Request.Update
{
    /// <summary>
    /// Data Transfer Object for updating an existing job advertisement.
    /// Allows partial updates where properties can be null to indicate no change.
    /// </summary>
    public class JobAdUpdateRequestDTO
    {
        /// <summary>
        /// Identifier of the job advertisement to update.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// New title of the job ad (optional).
        /// </summary>
        [Required, StringLength(128)]
        public string? Title { get; set; }

        /// <summary>
        /// New company name for the job ad (optional).
        /// </summary>
        [Required, StringLength(128)]
        public string? CompanyName { get; set; }

        /// <summary>
        /// New description for the job ad (optional).
        /// </summary>
        [Required, StringLength(1024)]
        public string? Description { get; set; }

        /// <summary>
        /// Date the job ad was published (optional).
        /// </summary>
        public DateTime? PublishedOn { get; set; }

        /// <summary>
        /// Whether the job ad is open (optional).
        /// </summary>
        public bool? IsOpen { get; set; }

        /// <summary>
        /// Whether the job ad is active (optional).
        /// </summary>
        public bool? IsActive { get; set; }
    }
}