using System.ComponentModel.DataAnnotations;
using JobTracking.Domain.Enums;

namespace JobTracking.Domain.DTOs.Request.Update
{
    /// <summary>
    /// DTO for updating an existing job application.
    /// </summary>
    public class JobApplicationUpdateRequestDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier of the job application.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the status of the job application.
        /// </summary>
        [Required]
        public ApplicationStatusEnum Status { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the job application is active.
        /// Optional; if not provided, the existing value remains unchanged.
        /// </summary>
        public bool? IsActive { get; set; }
    }
}