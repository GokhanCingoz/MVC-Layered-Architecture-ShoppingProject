using Microsoft.Build.Framework;

namespace Shopping.Web.Models
{
    public class EditUserRequest
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]

        public string Surname { get; set; }
        [Required]

        public string Password { get; set; }
        [Required]

        public string Username { get; set; }
        [Required]

        public bool IsAdmin { get; set; }
    }
}
