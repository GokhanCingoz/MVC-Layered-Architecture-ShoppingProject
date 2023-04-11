namespace Shopping.Web.Models
{
    public class DeleteUserRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsDeleted { get; set; }

    }
}
