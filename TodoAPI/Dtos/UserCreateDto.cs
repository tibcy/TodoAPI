namespace TodoAPI.Dtos
{
    public class UserCreateDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public bool Active { get; set; }
        public List<int>? Roles { get; set; }
    }
}
