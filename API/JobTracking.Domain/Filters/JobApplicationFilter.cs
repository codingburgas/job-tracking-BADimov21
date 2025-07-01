using JobTracking.Domain.Enums;

namespace JobTracking.Domain.Filters.Base
{
    /// <summary>
    /// Filter criteria for querying Job Applications.
    /// </summary>
    public class JobApplicationFilter : IFilter
    {
        /// <summary>
        /// Filters job applications by the user ID of the applicant.
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// Filters job applications by the associated job advertisement ID.
        /// </summary>
        public int? JobAdId { get; set; }

        /// <summary>
        /// Filters job applications by their status (e.g., submitted, approved, rejected).
        /// </summary>
        public ApplicationStatusEnum? Status { get; set; }
    }
}