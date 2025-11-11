using System.ComponentModel.DataAnnotations.Schema;

namespace TodoAPI.Models
{
    public class UserRole
    {
        public int Id { get; set; }

        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }

        public int? RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role? Role { get; set; }
    }
}
