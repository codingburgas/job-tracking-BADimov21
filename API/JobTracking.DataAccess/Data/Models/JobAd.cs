using System.ComponentModel.DataAnnotations;
using JobTracking.DataAccess.Data.Base;

namespace JobTracking.DataAccess.Data.Models
{
    /// <summary>
    /// Represents a job advertisement posted by a company.
    /// </summary>
    public class JobAd : IEntity
    {
        /// <summary>
        /// Unique identifier for the JobAd.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Title of the job position.
        /// </summary>
        [Required, StringLength(128)]
        public string Title { get; set; }

        /// <summary>
        /// Name of the company offering the job.
        /// </summary>
        [Required, StringLength(128)]
        public string CompanyName { get; set; }

        /// <summary>
        /// Detailed description of the job.
        /// </summary>
        [Required, StringLength(1024)]
        public string Description { get; set; }

        /// <summary>
        /// Date when the job ad was published.
        /// </summary>
        public DateTime PublishedOn { get; set; }

        /// <summary>
        /// Indicates whether the job position is currently open.
        /// </summary>
        public bool IsOpen { get; set; }

        /// <summary>
        /// Indicates if the job ad is active (not deleted or archived).
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Date and time when the job ad was created.
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Identifier for the user or system that created the job ad.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Date and time when the job ad was last updated.
        /// </summary>
        public DateTime? UpdatedOn { get; set; }

        /// <summary>
        /// Identifier for the user or system that last updated the job ad.
        /// </summary>
        public string? UpdatedBy { get; set; }

        /// <summary>
        /// Collection of job applications related to this job ad.
        /// </summary>
        public virtual ICollection<JobApplication> Applications { get; set; } = new List<JobApplication>();
    }
}