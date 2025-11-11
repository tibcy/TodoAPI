using System.ComponentModel.DataAnnotations.Schema;

namespace TodoAPI.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<User>? Users { get; set; }
        [InverseProperty("Role")]
        public List<UserRole>? UserRoles { get; set; }
    }
}
