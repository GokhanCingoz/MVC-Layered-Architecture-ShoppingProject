using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Domain
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
