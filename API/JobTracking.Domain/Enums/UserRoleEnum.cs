namespace JobTracking.Domain.Enums
{
    /// <summary>
    /// Defines the roles that a user can have within the system.
    /// </summary>
    public enum UserRoleEnum
    {
        /// <summary>
        /// Regular user with limited permissions.
        /// </summary>
        USER,

        /// <summary>
        /// Administrator with elevated permissions.
        /// </summary>
        ADMIN
    }
}