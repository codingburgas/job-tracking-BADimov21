using JobTracking.Domain.Enums;
using JobTracking.Domain.Filters.Base;

namespace JobTracking.Domain.Filters;

public class UserFilter : IFilter
{
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public string? Username { get; set; }
    public UserRoleEnum? Role { get; set; }
}