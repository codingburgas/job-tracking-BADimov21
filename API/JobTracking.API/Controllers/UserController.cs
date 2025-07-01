using JobTracking.Application.Contracts.Base;
using JobTracking.Domain.DTOs.Request.Create;
using JobTracking.Domain.DTOs.Request.Update;
using JobTracking.Domain.DTOs.Request;
using JobTracking.Domain.DTOs.Response;
using JobTracking.Domain.Filters;
using JobTracking.Domain.Filters.Base;
using Microsoft.AspNetCore.Mvc;
using LoginRequest = JobTracking.Domain.DTOs.Request.LoginRequest;

namespace JobTracking.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserController : Controller
{
    private readonly IUserService _userService;
    private readonly IAuthService _authService;

    public UserController(IUserService userService, IAuthService authService)
    {
        _userService = userService;
        _authService = authService;
    }

    /// <summary>
    /// Gets a user by their ID.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _userService.GetUser(id));
    }

    /// <summary>
    /// Returns a paginated list of all users.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageCount = 10)
    {
        var users = await _userService.GetAllUsers(page, pageCount);

        var response = users.Select(u => new UserResponseDTO
        {
            Id = u.Id,
            FirstName = u.FirstName,
            MiddleName = u.MiddleName,
            LastName = u.LastName,
            Username = u.Username,
            Role = u.Role
        });

        return Ok(response);
    }

    /// <summary>
    /// Gets filtered list of users based on given criteria.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> GetFiltered([FromBody] BaseFilter<UserFilter> userFilter)
    {
        return Ok(await _userService.GetFilteredUsers(userFilter));
    }

    /// <summary>
    /// Authenticates a user and returns their details if valid.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var user = await _authService.AuthenticateAsync(request.Username, request.Password);

        if (user is null)
        {
            return Unauthorized("Invalid credentials");
        }

        return Ok(user);
    }

    /// <summary>
    /// Adds a new user to the system.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] UserCreateRequestDTO dto)
    {
        var user = await _userService.CreateUser(dto);
        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }

    /// <summary>
    /// Updates an existing user's information.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UserUpdateRequestDTO dto)
    {
        if (id != dto.Id)
        {
            return BadRequest("ID mismatch.");
        }

        var success = await _userService.UpdateUser(dto);
        return success ? NoContent() : NotFound();
    }

    /// <summary>
    /// Deletes a user by their ID.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _userService.DeleteUser(id);
        return success ? NoContent() : NotFound();
    }
}