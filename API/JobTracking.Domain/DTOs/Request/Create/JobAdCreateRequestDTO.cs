using System.ComponentModel.DataAnnotations;

namespace JobTracking.Domain.DTOs.Request.Create
{
    /// <summary>
    /// Data Transfer Object for creating a new JobAd.
    /// Contains required fields and properties for JobAd creation.
    /// </summary>
    public class JobAdCreateRequestDTO
    {
        /// <summary>
        /// Title of the JobAd (max length 128).
        /// </summary>
        [Required, StringLength(128)]
        public string Title { get; set; }

        /// <summary>
        /// Company name posting the JobAd (max length 128).
        /// </summary>
        [Required, StringLength(128)]
        public string CompanyName { get; set; }

        /// <summary>
        /// Description of the JobAd (max length 1024).
        /// </summary>
        [Required, StringLength(1024)]
        public string Description { get; set; }

        /// <summary>
        /// Date when the JobAd is published.
        /// </summary>
        public DateTime PublishedOn { get; set; }

        /// <summary>
        /// Indicates whether the JobAd is open for applications.
        /// </summary>
        public bool IsOpen { get; set; }
    }
}