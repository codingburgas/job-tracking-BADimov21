using JobTracking.DataAccess.Data.Models;
using JobTracking.Domain.DTOs.Response;

namespace JobTracking.Application.Contracts.Base;

public interface IJobApplicationService
{
    public Task<List<JobApplication>> GetAllJobApplications(int page, int pageCount);
    public Task<JobApplicationResponseDTO> GetJobApplication(int userId);
}