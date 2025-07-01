namespace JobTracking.Domain.DTOs
{
    /// <summary>
    /// Represents a paginated result set for any data type.
    /// </summary>
    /// <typeparam name="T">The type of items in the result set.</typeparam>
    public class PagedResult<T>
    {
        /// <summary>
        /// Gets or sets the total count of pages available.
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Gets or sets the total number of items across all pages.
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// Gets or sets the collection of items on the current page.
        /// </summary>
        public List<T> Items { get; set; }
    }
}