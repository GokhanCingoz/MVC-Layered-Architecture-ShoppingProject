using EntityLayer.Domain;

namespace Shopping.Web.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public double Rating { get; set; }
        public int Stock { get; set; }
        public string ImgLink { get; set; }
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }

        public bool IsFavorite { get; set; }
    }
}
