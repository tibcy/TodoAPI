using System.ComponentModel.DataAnnotations.Schema;

namespace TodoAPI.Models
{
    public class TodoItemTag
    {
        public int Id { get; set; }
        public long TodoItemId { get; set; }
        [ForeignKey("TodoItemId")]
        public TodoItem? TodoItem { get; set; }

        public int TagId { get; set; }
        [ForeignKey("TagId")]
        public Tag? Tag { get; set; }
    }
}
