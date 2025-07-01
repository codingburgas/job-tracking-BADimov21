using JobTracking.Application.Contracts.Base;
using JobTracking.Domain.DTOs;
using JobTracking.Domain.DTOs.Request.Create;
using JobTracking.Domain.DTOs.Request.Update;
using JobTracking.Domain.DTOs.Response;
using JobTracking.Domain.Filters;
using JobTracking.Domain.Filters.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobTracking.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class JobAdController : Controller
{
    private readonly IJobAdService _jobAdService;

    public JobAdController(IJobAdService jobAdService)
    {
        _jobAdService = jobAdService;
    }

    /// <summary>
    /// Returns a job ad by its ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _jobAdService.GetJobAd(id);

        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    /// <summary>
    /// Returns all job ads (paged).
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageCount = 10)
    {
        var result = await _jobAdService.GetAllJobAds(page, pageCount);

        var response = result.Select(j => new JobAdResponseDTO
        {
            Id = j.Id,
            Title = j.Title,
            CompanyName = j.CompanyName,
            Description = j.Description,
            PublishedOn = j.PublishedOn,
            IsOpen = j.IsOpen
        });

        return Ok(response);
    }

    /// <summary>
    /// Returns filtered job ads based on filter and pagination.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> GetFiltered([FromBody] BaseFilter<JobAdFilter> jobAdFilter)
    {
        var query = await _jobAdService.GetFilteredJobAds(jobAdFilter);
        var totalCount = await query.CountAsync();

        var items = await query
            .Skip(jobAdFilter.PageSize * (jobAdFilter.Page - 1))
            .Take(jobAdFilter.PageSize)
            .ToListAsync();

        var response = new PagedResult<JobAdResponseDTO>
        {
            TotalCount = totalCount,
            Items = items
        };

        return Ok(response);
    }

    /// <summary>
    /// Creates a new job ad.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] JobAdCreateRequestDTO dto)
    {
        var created = await _jobAdService.CreateJobAd(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    /// <summary>
    /// Updates an existing job ad.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] JobAdUpdateRequestDTO dto)
    {
        if (id != dto.Id)
        {
            return BadRequest("ID mismatch.");
        }

        var success = await _jobAdService.UpdateJobAd(dto);
        return success ? NoContent() : NotFound();
    }

    /// <summary>
    /// Deletes a job ad by its ID.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _jobAdService.DeleteJobAd(id);
        return success ? NoContent() : NotFound();
    }
}