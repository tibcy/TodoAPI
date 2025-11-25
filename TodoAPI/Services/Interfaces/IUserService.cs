using TodoAPI.Dtos;

namespace TodoAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserReadDto>> GetAllUsersAsync();
        
    }
}
