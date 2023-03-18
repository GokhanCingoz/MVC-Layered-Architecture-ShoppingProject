using BusinessLayer.Managements.Interfaces;
using DataAccessLayer.Repositories.Interfaces;
using EntityLayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Managements
{
    public class CartManagement : ICartManagement
    {
        private readonly ICartRepository cartRepository;

        public CartManagement(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public void AddCart(Cart cart)
        {
            var existingCart = cartRepository.GetCart(cart.ProductId,cart.UserId);
            if ( existingCart != null) 
            {
                existingCart.Quantity++;
                cartRepository.Update(existingCart);
            }
            else
            {
                cartRepository.Add(cart);
            }
           
        }


        public void DecraseCartQuantity(Cart cart)
        {
            var existingCart = cartRepository.GetCart(cart.ProductId,cart.UserId);
            if (existingCart != null)
            {
                existingCart.Quantity--;
                if (existingCart.Quantity==0)
                {
                    DeleteCart(existingCart.Id);
                }
                else
                {
                    cartRepository.Update(existingCart);
                }
                
            }
           
        }

        public void DeleteCart(int id)
        {
            cartRepository.Delete(id);
        }

        public List<Cart> GetAllCartByUserId(int id)
        {
          return cartRepository.GetAllCarts(id);
          
        }

        public void UpdateCart(Cart cart)
        {
            cartRepository.Update(cart);
        }

        public int GetAllCartsQuantity(int userId)
        {
            var quantity = cartRepository.GetAllCarts(userId).Sum(x => x.Quantity);

            return quantity;
        }

        public double TotalPrice(int userId)
        {
            var totalPrice = cartRepository.GetAllCarts(userId).Sum(x => x.Quantity*x.Product.Price);

            return totalPrice;
        }
    }
}
