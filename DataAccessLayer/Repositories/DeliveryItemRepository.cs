using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Interfaces;
using EntityLayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class DeliveryItemRepository : IDeliveryItemRepository
    {
        private readonly ContextDb _contextDb;

        public DeliveryItemRepository(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }
        public void AddDeliveryItem(DeliveryItem deliveryItem)
        {
            _contextDb.DeliveryDetails.Add(deliveryItem);
            _contextDb.SaveChanges();
        }

        public void GetDeliveryItemByDeliveryId(int deliveryId)
        {
            _contextDb.DeliveryDetails.FirstOrDefault(x => x.DeliveryId == deliveryId);
            _contextDb.SaveChanges();
        }
    }
}
