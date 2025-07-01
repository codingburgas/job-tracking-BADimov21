using JobTracking.DataAccess.Data.Models;
using JobTracking.Domain.DTOs;
using JobTracking.Domain.DTOs.Request.Create;
using JobTracking.Domain.DTOs.Request.Update;
using JobTracking.Domain.DTOs.Response;
using JobTracking.Domain.Enums;
using JobTracking.Domain.Filters.Base;

namespace JobTracking.Application.Contracts.Base
{
    /// <summary>
    /// Defines service methods for managing job applications.
    /// </summary>
    public interface IJobApplicationService
    {
        /// <summary>
        /// Retrieves all job applications with pagination.
        /// </summary>
        Task<List<JobApplication>> GetAllJobApplications(int page, int pageCount);

        /// <summary>
        /// Retrieves a specific job application by its ID.
        /// </summary>
        Task<JobApplicationResponseDTO?> GetJobApplication(int jobApplicationId);

        /// <summary>
        /// Checks if a user has already applied to a specific job.
        /// </summary>
        Task<bool> HasUserAlreadyApplied(int jobId, int userId);

        /// <summary>
        /// Creates a new job application.
        /// </summary>
        Task<JobApplicationResponseDTO> CreateJobApplication(JobApplicationCreateRequestDTO dto);

        /// <summary>
        /// Updates an existing job application.
        /// </summary>
        Task<bool> UpdateJobApplication(JobApplicationUpdateRequestDTO dto);

        /// <summary>
        /// Deletes a job application by ID.
        /// </summary>
        Task<bool> DeleteJobApplication(int id);

        /// <summary>
        /// Retrieves job applications based on filtering and pagination criteria.
        /// </summary>
        Task<PagedResult<JobApplicationResponseDTO>> GetFilteredJobApplications(
            BaseFilter<JobApplicationFilter> filter);
    }
}