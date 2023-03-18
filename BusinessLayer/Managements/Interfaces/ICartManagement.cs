using EntityLayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Managements.Interfaces
{
    public interface ICartManagement
    {
        List<Cart> GetAllCartByUserId(int id);
        void AddCart(Cart cart);
        void Delete(int id);
        void Update(Cart cart);
        int GetCartQuantity(int userId);
        void DecraseCartQuantity(Cart cart);
    }
}
