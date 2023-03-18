namespace Shopping.Web.Models
{
    public class FavoriteModel
    {
        public int Id { get; set; }
   
        public int ProductId { get; set; }
        public virtual ProductModel Product { get; set; }

        public int UserId { get; set; }
        public virtual UserModel User { get; set; }
    }
}
