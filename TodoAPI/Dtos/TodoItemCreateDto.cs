using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TodoAPI.Models;

namespace TodoAPI.Dtos
{
    public class TodoItemCreateDto
    {
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
        public int? PriorityId { get; set; }
        public int? CategoryId { get; set; }
       
    }
}
