using JobTracking.Application.Contracts.Base;
using JobTracking.DataAccess.Data.Models;
using JobTracking.Domain.DTOs.Request.Create;
using JobTracking.Domain.DTOs.Request.Update;
using JobTracking.Domain.DTOs.Response;
using JobTracking.Domain.Filters;
using JobTracking.Domain.Filters.Base;
using Microsoft.EntityFrameworkCore;

namespace JobTracking.Application.Implementation;

/// <summary>
/// Service for managing Job Ads.
/// </summary>
public class JobAdService : IJobAdService
{
    protected DependencyProvider Provider { get; set; }
    
    /// <summary>
    /// Constructor accepting dependency provider.
    /// </summary>
    /// <param name="provider">Dependency provider instance</param>
    public JobAdService(DependencyProvider provider)
    {
        Provider = provider;
    }

    /// <summary>
    /// Retrieves paginated list of Job Ads.
    /// </summary>
    /// <param name="page">Page number (1-based)</param>
    /// <param name="pageCount">Number of items per page</param>
    /// <returns>List of JobAd entities</returns>
    public async Task<List<JobAd>> GetAllJobAds(int page, int pageCount)
    {
        return await Provider.Db.JobAds
            .Skip((page - 1) * pageCount)
            .Take(pageCount)
            .ToListAsync();
    }
    
    /// <summary>
    /// Gets a Job Ad by its ID.
    /// </summary>
    /// <param name="jobAdId">JobAd identifier</param>
    /// <returns>JobAdResponseDTO or null if not found</returns>
    public async Task<JobAdResponseDTO?> GetJobAd(int jobAdId)
    {
        return await Provider.Db.JobAds
            .Where(j => j.Id == jobAdId)
            .Select(j => new JobAdResponseDTO
            {
                Id = j.Id,
                Title = j.Title,
                Description = j.Description,
                CompanyName = j.CompanyName,
                PublishedOn = j.PublishedOn,
                IsOpen = j.IsOpen
            })
            .FirstOrDefaultAsync();
    }
    
    /// <summary>
    /// Creates a new Job Ad.
    /// </summary>
    /// <param name="dto">Create request DTO</param>
    /// <returns>Created JobAdResponseDTO</returns>
    public async Task<JobAdResponseDTO> CreateJobAd(JobAdCreateRequestDTO dto)
    {
        var entity = new JobAd
        {
            Title = dto.Title,
            CompanyName = dto.CompanyName,
            Description = dto.Description,
            PublishedOn = dto.PublishedOn,
            IsOpen = dto.IsOpen,
            CreatedOn = DateTime.UtcNow,
            CreatedBy = "system",
            IsActive = true
        };

        Provider.Db.JobAds.Add(entity);
        await Provider.Db.SaveChangesAsync();

        return new JobAdResponseDTO
        {
            Id = entity.Id,
            Title = entity.Title,
            CompanyName = entity.CompanyName,
            Description = entity.Description,
            PublishedOn = entity.PublishedOn,
            IsOpen = entity.IsOpen
        };
    }
    
    /// <summary>
    /// Updates an existing Job Ad.
    /// </summary>
    /// <param name="dto">Update request DTO</param>
    /// <returns>True if updated, false if not found</returns>
    public async Task<bool> UpdateJobAd(JobAdUpdateRequestDTO dto)
    {
        var entity = await Provider.Db.JobAds.FindAsync(dto.Id);

        if (entity is null)
        {
            return false;
        }

        if (!string.IsNullOrWhiteSpace(dto.Title))
        {
            entity.Title = dto.Title;
        }

        if (!string.IsNullOrWhiteSpace(dto.CompanyName))
        {
            entity.CompanyName = dto.CompanyName;
        }

        if (!string.IsNullOrWhiteSpace(dto.Description))
        {
            entity.Description = dto.Description;
        }

        if (dto.PublishedOn.HasValue)
        {
            entity.PublishedOn = dto.PublishedOn.Value;
        }

        if (dto.IsOpen.HasValue)
        {
            entity.IsOpen = dto.IsOpen.Value;
        }

        if (dto.IsActive.HasValue)
        {
            entity.IsActive = dto.IsActive.Value;
        }

        entity.UpdatedOn = DateTime.UtcNow;
        entity.UpdatedBy = "system";

        await Provider.Db.SaveChangesAsync();
        return true;
    }
    
    /// <summary>
    /// Deletes a Job Ad by ID.
    /// </summary>
    /// <param name="id">JobAd identifier</param>
    /// <returns>True if deleted, false if not found</returns>
    public async Task<bool> DeleteJobAd(int id)
    {
        var entity = await Provider.Db.JobAds.FindAsync(id);
        if (entity is null)
        {
            return false;
        }

        Provider.Db.JobAds.Remove(entity);
        await Provider.Db.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Retrieves filtered Job Ads based on filter criteria.
    /// </summary>
    /// <param name="filter">Filter criteria</param>
    /// <returns>IQueryable of filtered JobAdResponseDTO</returns>
    public async Task<IQueryable<JobAdResponseDTO>> GetFilteredJobAds(BaseFilter<JobAdFilter> filter)
    {
        IQueryable<JobAd> query = Provider.Db.JobAds;
        var jobAdFilter = filter.Filters;

        if (jobAdFilter is not null)
        {
            var hasTitle = !string.IsNullOrWhiteSpace(jobAdFilter.Title);
            var hasCompany = !string.IsNullOrWhiteSpace(jobAdFilter.CompanyName);
            var hasPublishedOn = jobAdFilter.PublishedOn.HasValue;
            var hasIsOpen = jobAdFilter.IsOpen.HasValue;

            if (hasTitle || hasCompany || hasPublishedOn || hasIsOpen)
            {
                query = query.Where(j =>
                    (hasTitle && j.Title.Contains(jobAdFilter.Title)) ||
                    (hasCompany && j.CompanyName.Contains(jobAdFilter.CompanyName)) ||
                    (hasPublishedOn && j.PublishedOn.Date == jobAdFilter.PublishedOn.Value.Date) ||
                    (hasIsOpen && j.IsOpen == jobAdFilter.IsOpen)
                );
            }
        }
        
        return query.Select(x => new JobAdResponseDTO
        {
            Id = x.Id,
            Title = x.Title,
            CompanyName = x.CompanyName,
            Description = x.Description,
            PublishedOn = x.PublishedOn,
            IsOpen = x.IsOpen
        });
    }
}