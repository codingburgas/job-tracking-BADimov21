using JobTracking.Application.Contracts.Base;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _jobAdService.GetJobAd(id));
    }
}