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
        void AddToDelivery(Delivery delivery);
        void GetDeliveryByUserId(int userId);

    }
}
