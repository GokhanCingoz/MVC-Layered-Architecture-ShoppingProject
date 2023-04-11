using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs
{
    public class PaymentDto
    {   
        public int UserId { get; set; }
        public string Adress { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int PhoneNum { get; set; }
        public string Email { get; set; }
        public double TotalPrice { get; set; } // Bir gönderideki toplam tutarı gösterir. Ama ürün bazında değil.
        public int TotalQuantity { get; set; } // Bir gönderideki toplam ürün sayısını gösterir. Ama ürün bazında değil.
    }
}
