using JobTracking.Domain.Enums;

namespace JobTracking.Domain.DTOs.Response
{
    /// <summary>
    /// Data Transfer Object for returning job application details.
    /// </summary>
    public class JobApplicationResponseDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier of the job application.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the user ID who submitted the application.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the job advertisement ID related to this application.
        /// </summary>
        public int JobAdId { get; set; }

        /// <summary>
        /// Gets or sets the current status of the application.
        /// </summary>
        public ApplicationStatusEnum Status { get; set; }

        /// <summary>
        /// Gets or sets the user details associated with this application.
        /// </summary>
        public UserResponseDTO User { get; set; }

        /// <summary>
        /// Gets or sets the job advertisement details for this application.
        /// </summary>
        public JobAdResponseDTO JobAd { get; set; }
    }
}