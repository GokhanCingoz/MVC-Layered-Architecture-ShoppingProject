using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Interfaces;
using EntityLayer.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly ContextDb _contextDb;

        public DeliveryRepository(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }
        public int AddToDelivery(Delivery delivery)
        {
            delivery.Date = DateTime.Now;
            _contextDb.Deliveries.Add(delivery);
            _contextDb.SaveChanges();
            return delivery.Id;
        }

        public List<Delivery> GetDeliveryByUserId(int userId)
        {
            return _contextDb.Deliveries.Include(x => x.DeliveryDetail).ThenInclude(x => x.Product).Where(x => x.UserId == userId && x.IsDraft ==false).ToList();

        }

        public void ApproveDelivery(int deliveryId)
        {
            var delivery = _contextDb.Deliveries.FirstOrDefault(x => x.Id == deliveryId);

            if (delivery != null)
            {
                delivery.IsDraft = false;
                _contextDb.SaveChanges();
            }
        }


    }
}
