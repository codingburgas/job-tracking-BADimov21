using JobTracking.Application.Contracts.Base;
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

    [HttpGet]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _jobApplicationService.GetJobApplication(id));
    }
}