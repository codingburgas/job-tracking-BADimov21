using JobTracking.DataAccess.Data.Models;
using JobTracking.Domain.DTOs.Response;

namespace JobTracking.Application.Contracts.Base;

public interface IJobAdService
{
    public Task<List<JobAd>> GetAllJobAds(int page, int pageCount);
    public Task<JobAdResponseDTO> GetJobAd(int userId);
}