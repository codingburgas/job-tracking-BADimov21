namespace JobTracking.Domain.Enums
{
    /// <summary>
    /// Represents the various statuses a job application can have.
    /// </summary>
    public enum ApplicationStatusEnum
    {
        /// <summary>
        /// The application has been submitted and is pending review.
        /// </summary>
        SUBMITTED,

        /// <summary>
        /// The application has been approved.
        /// </summary>
        APPROVED,

        /// <summary>
        /// The application has been rejected.
        /// </summary>
        REJECTED
    }
}