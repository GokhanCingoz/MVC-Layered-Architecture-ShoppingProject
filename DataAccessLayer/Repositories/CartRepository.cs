using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Interfaces;
using EntityLayer.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CartRepository : ICartRepository
    {   
        private readonly ContextDb _contextDb;

        public CartRepository(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }
        public void Add(Cart cart)
        {
            _contextDb.Carts.Add(cart);
            _contextDb.SaveChanges();
        }

        public void Delete(int id)
        {
            _contextDb.Carts.Remove(_contextDb.Carts.FirstOrDefault(c => c.Id == id));
            _contextDb.SaveChanges();
        }

        public List<Cart> GetAllCarts(int userId)
        {
           return _contextDb.Carts.Include(u=>u.Product).ThenInclude(u => u.Category).Where(x => x.UserId == userId).ToList();
        }
        public void Update(Cart cart)
        {
            var existingCart = _contextDb.Carts.FirstOrDefault(x => x.Id == cart.Id);
            if (existingCart != null)
            {
                existingCart.Quantity = cart.Quantity;
            }
            _contextDb.SaveChanges();
        }

        public Cart GetCart(int productId,int userId)
        {
            return _contextDb.Carts.FirstOrDefault(x=>x.ProductId==productId&& x.UserId==userId);
        }

        public void RemoveAllCartsByUserId(int userId)
        {
           var cartsByUserId= GetAllCarts(userId);

            _contextDb.Carts.RemoveRange(cartsByUserId);
            _contextDb.SaveChanges();
        }
    }
}
