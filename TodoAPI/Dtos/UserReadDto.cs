using TodoAPI.Models;

namespace TodoAPI.Dtos
{
    public class UserReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? PasswordHash { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public bool Active { get; set; }

        public List<Role>? Roles { get; set; }
    }
}
