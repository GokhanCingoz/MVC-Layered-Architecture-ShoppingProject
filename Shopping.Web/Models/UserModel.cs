using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Shopping.Web.Models
{
    public class UserModel
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
        [Required]
        public bool IsDeleted { get; set; }
    }
}
