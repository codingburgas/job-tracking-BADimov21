using JobTracking.Application.Contracts.Base;
using JobTracking.DataAccess.Data.Models;
using JobTracking.Domain.DTOs.Request.Create;
using JobTracking.Domain.DTOs.Request.Update;
using JobTracking.Domain.DTOs.Response;
using JobTracking.Domain.Enums;
using JobTracking.Domain.Filters.Base;
using Microsoft.AspNetCore.Mvc;

namespace JobTracking.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class JobApplicationController : Controller
{
    private readonly IJobApplicationService _jobApplicationService;

    public JobApplicationController(IJobApplicationService jobApplicationService)
    {
        _jobApplicationService = jobApplicationService;
    }

    /// <summary>
    /// Gets a job application by ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _jobApplicationService.GetJobApplication(id));
    }

    /// <summary>
    /// Gets all job applications (paged).
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageCount = 10)
    {
        var result = await _jobApplicationService.GetAllJobApplications(page, pageCount);
        return Ok(result);
    }

    /// <summary>
    /// Returns filtered job applications based on filters and pagination.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> GetFiltered([FromBody] BaseFilter<JobApplicationFilter> jobApplicationFilter)
    {
        var result = await _jobApplicationService.GetFilteredJobApplications(jobApplicationFilter);
        return Ok(result);
    }

    /// <summary>
    /// Creates a new job application. Rejects duplicate applications from same user to same job.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] JobApplicationCreateRequestDTO dto)
    {
        if (await _jobApplicationService.HasUserAlreadyApplied(dto.JobAdId, dto.UserId))
        {
            return BadRequest(new { message = "User has already applied to this job." });
        }

        var created = await _jobApplicationService.CreateJobApplication(dto);
        return Ok(created);
    }

    /// <summary>
    /// Updates an existing job application.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] JobApplicationUpdateRequestDTO dto)
    {
        if (id != dto.Id)
        {
            return BadRequest("ID mismatch.");
        }

        var success = await _jobApplicationService.UpdateJobApplication(dto);
        return success ? NoContent() : NotFound();
    }

    /// <summary>
    /// Deletes a job application by ID.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _jobApplicationService.DeleteJobApplication(id);
        return success ? NoContent() : NotFound();
    }
}