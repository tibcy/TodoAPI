using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoAPI.Models
{
    public class TodoItem
    {
        [Key]
        public long Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
        public string? Secret { get; set; }
        public int? PriorityId { get; set; }

        [ForeignKey("PriorityId")]
        public Priority? Priority { get; set; }

        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
    }
}
