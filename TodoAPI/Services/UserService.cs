using Microsoft.EntityFrameworkCore;
using TodoAPI.Dtos;
using TodoAPI.Models;
using TodoAPI.Services.Interfaces;

namespace TodoAPI.Services
{
    public class UserService : IUserService
    {
        private readonly TodoContext _context;

        public UserService(TodoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserReadDto>> GetAllUsersAsync()
        {
            return await _context.Users.Include(r => r.Roles)
                .Select(u => new UserReadDto 
                { 
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    PasswordHash = u.PasswordHash,
                    LastLogin = u.LastLogin,
                    Created = u.Created,
                    Modified = u.Modified,
                    Active = u.Active,
                    Roles = u.Roles
                }).ToListAsync();
        }
    }
}
