using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Domain
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}
