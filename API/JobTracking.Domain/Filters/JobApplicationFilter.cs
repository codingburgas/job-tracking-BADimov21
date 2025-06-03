using JobTracking.Domain.Enums;

namespace JobTracking.Domain.Filters.Base;

public class JobApplicationFilter : IFilter
{
    public ApplicationStatusEnum? Status { get; set; }
}