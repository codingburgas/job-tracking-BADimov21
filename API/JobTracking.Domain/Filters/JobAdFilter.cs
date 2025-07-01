using JobTracking.Domain.Filters.Base;

namespace JobTracking.Domain.Filters
{
    /// <summary>
    /// Filter criteria for querying Job Ads.
    /// </summary>
    public class JobAdFilter : IFilter
    {
        /// <summary>
        /// Filters job ads by title containing this value.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Filters job ads by company name containing this value.
        /// </summary>
        public string? CompanyName { get; set; }

        /// <summary>
        /// Filters job ads published on this date.
        /// </summary>
        public DateTime? PublishedOn { get; set; }

        /// <summary>
        /// Filters job ads based on whether they are open.
        /// </summary>
        public bool? IsOpen { get; set; }
    }
}