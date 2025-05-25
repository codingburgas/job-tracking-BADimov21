using JobTracking.Application.Contracts.Base;
using JobTracking.DataAccess.Data.Models;
using JobTracking.Domain.DTOs.Response;
using Microsoft.EntityFrameworkCore;

namespace JobTracking.Application.Implementation;

public class JobAdService : IJobAdService
{
    protected DependencyProvider Provider { get; set; }
    
    public JobAdService(DependencyProvider provider)
    {
        Provider = provider;
    }

    public async Task<List<JobAd>> GetAllJobAds(int page, int pageCount)
    {
        return await Provider.Db.JobAds
            .Skip(page - 1 * pageCount)
            .Take(pageCount)
            .ToListAsync();
    }
    
    public Task<JobAdResponseDTO> GetJobAd(int jobAdId)
    {
        return Provider.Db.JobAds
            .Where(j => j.Id == jobAdId)
            .Select(j => new JobAdResponseDTO
            {
                Id = j.Id,
                Title = j.Title,
                CompanyName = j.CompanyName,
                Description = j.Description,
                PublishedOn = j.PublishedOn,
                IsOpen = j.IsOpen
            })
            .FirstAsync();
    }
}