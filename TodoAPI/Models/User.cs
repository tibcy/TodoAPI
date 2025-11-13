using System.ComponentModel.DataAnnotations.Schema;

namespace TodoAPI.Models
{
    public class User: Base
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public string? PasswordHash { get; set; }
        public DateTime LastLogin { get; set; }

        public bool Active { get; set; }
        public List<TodoItem>? TodoItems { get; set; }

        public List<Role>? Roles { get; set; }
        [InverseProperty("User")]
        public List<UserRole>? UserRoles { get; set; }
    }
}
