using BusinessLayer.DTOs;
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
        void DeleteCart(int id);
        void UpdateCart(Cart cart);
        int GetAllCartsQuantity(int userId);
        void DecraseCartQuantity(Cart cart);
        double TotalPrice(int userId);
        void CreateDelivery(PaymentDto paymentDto);

    }
}
