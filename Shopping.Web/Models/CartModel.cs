using EntityLayer.Domain;

namespace Shopping.Web.Models
{
    public class CartModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public virtual ProductModel Product { get; set; }

        public int UserId { get; set; }
        public virtual UserModel User { get; set; }
    }
}
