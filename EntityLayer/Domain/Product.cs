using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Domain
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public double Rating { get; set; }
        public int Stock { get; set; }
        public string ImgLink { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public ICollection<DeliveryDetail> DeliveryDetails { get; }
        public bool IsDeleted { get; set; }
    }
}
