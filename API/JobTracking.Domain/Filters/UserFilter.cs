using JobTracking.Domain.Enums;
using JobTracking.Domain.Filters.Base;

namespace JobTracking.Domain.Filters
{
    /// <summary>
    /// Filter criteria for querying users.
    /// </summary>
    public class UserFilter : IFilter
    {
        /// <summary>
        /// Filters users by their first name.
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Filters users by their middle name.
        /// </summary>
        public string? MiddleName { get; set; }

        /// <summary>
        /// Filters users by their last name.
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Filters users by their username.
        /// </summary>
        public string? Username { get; set; }

        /// <summary>
        /// Filters users by their role (User or Admin).
        /// </summary>
        public UserRoleEnum? Role { get; set; }
    }
}