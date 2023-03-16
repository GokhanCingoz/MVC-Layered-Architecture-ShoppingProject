using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Domain
{
    public class DeliveryDetail
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; } // Bir gönderideki toplam ödenen tutarı ürün bazında gösterir. Ürünlere tek tek ulaşarak hangi üründen kaç paralık alışveriş yapıldığını gösterir.
        public int Quantity { get; set; } // Bir gönderideki toplam ürün sayısını ürün bazında gösterir. Ürünlere tek tek ulaşarak hangi üründen kaç tane alışveriş yapıldığını gösterir.

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int DeliveryId { get; set; }
        public virtual Delivery Delivery { get; set; }
    }
}
