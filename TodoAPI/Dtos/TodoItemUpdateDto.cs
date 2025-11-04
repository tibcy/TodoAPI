namespace TodoAPI.Dtos
{
    public class TodoItemUpdateDto
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
        public int? PriorityId { get; set; }
        public int? CategoryId { get; set; }
    }
}
