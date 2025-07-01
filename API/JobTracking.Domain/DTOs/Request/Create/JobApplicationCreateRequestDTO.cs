using System.ComponentModel.DataAnnotations;
using JobTracking.Domain.Enums;

namespace JobTracking.Domain.DTOs.Request.Create
{
    /// <summary>
    /// Data Transfer Object for creating a new JobApplication.
    /// Contains user, job ad reference, and application status.
    /// </summary>
    public class JobApplicationCreateRequestDTO
    {
        /// <summary>
        /// Identifier of the user applying for the job.
        /// </summary>
        [Required]
        public int UserId { get; set; }

        /// <summary>
        /// Identifier of the job advertisement.
        /// </summary>
        [Required]
        public int JobAdId { get; set; }

        /// <summary>
        /// Current status of the job application.
        /// </summary>
        [Required]
        public ApplicationStatusEnum Status { get; set; }
    }
}