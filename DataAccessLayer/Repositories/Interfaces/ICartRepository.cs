using EntityLayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface ICartRepository
    {
        List<Cart> GetAllCarts(int userId);
        void Add(Cart cart);
        void Delete (int id);
        void Update(Cart cart);
        Cart GetCart(int productId,int userId);
    }
}
