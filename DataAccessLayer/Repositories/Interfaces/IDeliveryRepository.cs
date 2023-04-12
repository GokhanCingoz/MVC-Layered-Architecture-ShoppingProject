using EntityLayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IDeliveryRepository
    {
        int AddToDelivery(Delivery delivery);
        public List<Delivery> GetDeliveryByUserId(int userId);
        void ApproveDelivery(int deliveryId);

    }
}
