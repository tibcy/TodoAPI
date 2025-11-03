namespace TodoAPI.Dtos
{
    public class TodoItemDTO
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
        public string? Priority { get; set; }
        public string? Category { get; set; }
    }
}
