using JobTracking.Application.Contracts.Base;
using JobTracking.DataAccess.Data.Models;
using JobTracking.Domain.DTOs.Response;
using Microsoft.EntityFrameworkCore;

namespace JobTracking.Application.Implementation;

public class UserService : IUserService
{
    protected DependencyProvider Provider { get; set; }
    
    public UserService(DependencyProvider provider)
    {
        Provider = provider;
    }

    public async Task<List<User>> GetAllUsers(int page, int pageCount)
    {
        return await Provider.Db.Users
            .Skip(page - 1 * pageCount)
            .Take(pageCount)
            .ToListAsync();
    }
    
    public Task<UserResponseDTO> GetUser(int userId)
    {
        return Provider.Db.Users
            .Where(u => u.Id == userId)
            .Select(u => new UserResponseDTO
            {
                Id = u.Id,
                FirstName = u.FirstName,
                MiddleName = u.MiddleName,
                LastName = u.LastName,
                Username = u.Username,
                Password = u.Password,
                Role = u.Role
            })
            .FirstAsync();
    }
}