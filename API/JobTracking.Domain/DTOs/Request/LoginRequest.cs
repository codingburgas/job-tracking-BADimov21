namespace JobTracking.Domain.DTOs.Request
{
    /// <summary>
    /// DTO representing a login request with username and password.
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// Gets or sets the username for login.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password for login.
        /// </summary>
        public string Password { get; set; }
    }
}