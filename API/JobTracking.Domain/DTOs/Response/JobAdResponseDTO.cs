namespace JobTracking.Domain.DTOs.Response
{
    /// <summary>
    /// Data Transfer Object for returning job advertisement details.
    /// </summary>
    public class JobAdResponseDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier of the job ad.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the job title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the company name offering the job.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the job description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the date when the job ad was published.
        /// </summary>
        public DateTime PublishedOn { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the job ad is currently open.
        /// </summary>
        public bool IsOpen { get; set; }
    }
}