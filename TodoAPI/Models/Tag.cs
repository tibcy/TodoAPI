using System.ComponentModel.DataAnnotations.Schema;

namespace TodoAPI.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<TodoItem>? TodoItems { get; set; }

        [InverseProperty("Tag")]
        public List<TodoItemTag>? TodoItemTags { get; set; }
    }
}
