namespace Shopping.Web.Models
{
    public class PaymentModel
    {
        public string Adress { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public double TotalPrice { get; set; } // Bir gönderideki toplam tutarı gösterir. Ama ürün bazında değil.
        public int TotalQuantity { get; set; } // Bir gönderideki toplam ürün sayısını gösterir. Ama ürün bazında değil.

    }
}
