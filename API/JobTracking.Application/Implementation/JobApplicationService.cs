using JobTracking.Application.Contracts.Base;
using JobTracking.DataAccess.Data.Models;
using JobTracking.Domain.DTOs.Response;
using Microsoft.EntityFrameworkCore;

namespace JobTracking.Application.Implementation;

public class JobApplicationService
{
    protected DependencyProvider Provider { get; set; }
    
    public JobApplicationService(DependencyProvider provider)
    {
        Provider = provider;
    }

    public async Task<List<JobApplication>> GetAllJobApplcation(int page, int pageCount)
    {
        return await Provider.Db.JobApplications
            .Skip(page - 1 * pageCount)
            .Take(pageCount)
            .ToListAsync();
    }
    
    public Task<JobApplicationResponseDTO> GetJobApplication(int jobApplicationId)
    {
        return Provider.Db.JobApplications
            .Where(j => j.Id == jobApplicationId)
            .Select(j => new JobApplicationResponseDTO
            {
                Id = j.Id,
                UserId = j.UserId,
                JobAdId = j.JobAdId,
                Status = j.Status
            })
            .FirstAsync();
    }
}