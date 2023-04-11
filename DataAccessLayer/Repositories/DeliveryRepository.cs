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
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly ContextDb _contextDb;

        public DeliveryRepository(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }
        public void AddToDelivery(Delivery delivery)
        {
            _contextDb.Deliveries.Add(delivery);
            _contextDb.SaveChanges();
        }

        public void GetDeliveryByUserId(int userId)
        {
            _contextDb.Deliveries.FirstOrDefault(x => x.UserId == userId);
            _contextDb.SaveChanges();
        }
    }
}
