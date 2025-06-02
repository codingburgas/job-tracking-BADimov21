using System.ComponentModel.Design;
using System.Net.Mime;
using JobTracking.Application.Contracts.Base;
using JobTracking.DataAccess.Data.Models;
using JobTracking.Domain.DTOs.Request.Create;
using JobTracking.Domain.DTOs.Request.Update;
using JobTracking.Domain.DTOs.Response;
using JobTracking.Domain.Filters;
using JobTracking.Domain.Filters.Base;
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
            .Skip((page - 1) * pageCount)
            .Take(pageCount)
            .ToListAsync();
    }

    public Task<UserResponseDTO?> GetUser(int userId)
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
                Role = u.Role
            })
            .FirstOrDefaultAsync();
    }

    public async Task<UserResponseDTO> CreateUser(UserCreateRequestDTO dto)
    {
        if (await Provider.Db.Users.AnyAsync(u => u.Username == dto.Username))
        {
            throw new InvalidOperationException("Username already exists.");
        }

        var entity = new User
        {
            FirstName = dto.FirstName,
            MiddleName = dto.MiddleName,
            LastName = dto.LastName,
            Username = dto.Username,
            Password = dto.Password,
            Role = dto.Role,
            CreatedOn = DateTime.UtcNow,
            CreatedBy = "system",
            IsActive = true
        };

        Provider.Db.Users.Add(entity);
        await Provider.Db.SaveChangesAsync();

        return new UserResponseDTO
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            MiddleName = entity.MiddleName,
            LastName = entity.LastName,
            Username = entity.Username,
            Role = entity.Role
        };
    }

    public async Task<bool> UpdateUser(UserUpdateRequestDTO dto)
    {
        var entity = await Provider.Db.Users.FindAsync(dto.Id);

        if (entity is null)
        {
            return false;
        }

        entity.FirstName = dto.FirstName;
        entity.MiddleName = dto.MiddleName;
        entity.LastName = dto.LastName;
        entity.Username = dto.Username;
        entity.Password = dto.Password;
        entity.Role = dto.Role;
        entity.UpdatedOn = DateTime.UtcNow;
        entity.UpdatedBy = "system";
        entity.IsActive = dto.IsActive;

        await Provider.Db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteUser(int userId)
    {
        var entity = await Provider.Db.Users.FindAsync(userId);

        if (entity is null)
        {
            return false;
        }

        Provider.Db.Users.Remove(entity);
        await Provider.Db.SaveChangesAsync();
        return true;
    }

    public async Task<List<UserResponseDTO>> GetFilteredUsers(string? username)
    {
        var query = Provider.Db.Users.AsQueryable();

        if (!string.IsNullOrWhiteSpace(username))
        {
            query = query.Where(u => u.Username.Contains(username));
        }

        var result = await query
            .Select(u => new UserResponseDTO
            {
                Id = u.Id,
                FirstName = u.FirstName,
                MiddleName = u.MiddleName,
                LastName = u.LastName,
                Username = u.Username,
                Role = u.Role
            })
            .ToListAsync();

        return result;
    }

    public async Task<IQueryable<UserResponseDTO>> GetUsers(BaseFilter<UserFilter> filter)
    {
        IQueryable<User> query = Provider.Db.Users;

        UserFilter? userFilter = filter.Filters;

        if (userFilter is not null)
        {
            if (!string.IsNullOrEmpty(userFilter.FirstName))
            {
                query = query.Where(u => u.FirstName.Contains(userFilter.FirstName));
            }

            if (!string.IsNullOrEmpty(userFilter.MiddleName))
            {
                query = query.Where(u => u.MiddleName.Contains(userFilter.MiddleName));
            }

            if (!string.IsNullOrEmpty(userFilter.LastName))
            {
                query = query.Where(u => u.LastName.Contains(userFilter.LastName));
            }

            if (!string.IsNullOrEmpty(userFilter.Username))
            {
                query = query.Where(u => u.Username.Contains(userFilter.Username));
            }

            if (userFilter.Role is not null)
            {
                query = query.Where(u => u.Role == userFilter.Role);
            }
        }

        query = query.Skip(filter.PageSize * (filter.Page - 1)).Take(filter.PageSize);

        return query.Select(x => new UserResponseDTO()
        {
            Id = x.Id,
            FirstName = x.FirstName,
            MiddleName = x.MiddleName,
            LastName = x.LastName,
            Username = x.Username,
            Role = x.Role
        });
    }
}