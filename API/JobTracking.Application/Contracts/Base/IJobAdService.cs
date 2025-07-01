using JobTracking.DataAccess.Data.Models;
using JobTracking.Domain.DTOs.Request.Create;
using JobTracking.Domain.DTOs.Request.Update;
using JobTracking.Domain.DTOs.Response;
using JobTracking.Domain.Filters;
using JobTracking.Domain.Filters.Base;

namespace JobTracking.Application.Contracts.Base
{
    /// <summary>
    /// Defines service methods for managing job advertisements.
    /// </summary>
    public interface IJobAdService
    {
        /// <summary>
        /// Retrieves all job ads with pagination.
        /// </summary>
        Task<List<JobAd>> GetAllJobAds(int page, int pageCount);

        /// <summary>
        /// Retrieves a specific job ad by its ID.
        /// </summary>
        Task<JobAdResponseDTO?> GetJobAd(int userId);

        /// <summary>
        /// Creates a new job ad.
        /// </summary>
        Task<JobAdResponseDTO> CreateJobAd(JobAdCreateRequestDTO dto);

        /// <summary>
        /// Updates an existing job ad.
        /// </summary>
        Task<bool> UpdateJobAd(JobAdUpdateRequestDTO dto);

        /// <summary>
        /// Deletes a job ad by ID.
        /// </summary>
        Task<bool> DeleteJobAd(int id);

        /// <summary>
        /// Retrieves filtered job ads based on given criteria.
        /// </summary>
        Task<IQueryable<JobAdResponseDTO>> GetFilteredJobAds(BaseFilter<JobAdFilter> filter);
    }
}