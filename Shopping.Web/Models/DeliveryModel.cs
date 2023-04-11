using EntityLayer.Domain;
using System.ComponentModel.DataAnnotations;

namespace Shopping.Web.Models
{
    public class DeliveryModel
    {
        [Key]
        public int Id { get; set; }
        public double TotalPrice { get; set; } // Bir gönderideki toplam tutarı gösterir. Ama ürün bazında değil.
        public int TotalQuantity { get; set; } // Bir gönderideki toplam ürün sayısını gösterir. Ama ürün bazında değil.
        public string Adress { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int PhoneNum { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public bool IsDraft { get; set; }
        public virtual User User { get; set; }
        public ICollection<DeliveryItem> DeliveryDetails { get; }
    }
}
