using BusinessLayer.Managements.Interfaces;
using DataAccessLayer.Repositories.Interfaces;
using EntityLayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Managements
{
    public class DeliveryManagement : IDeliveryManagement
    {
        private readonly IDeliveryRepository _deliveryRepository;
       
        public DeliveryManagement(IDeliveryRepository deliveryRepository)
        {
          _deliveryRepository= deliveryRepository;
        }
        public List<Delivery> GetDeliveryByUserId(int userId)
        {
          return _deliveryRepository.GetDeliveryByUserId(userId);
        }
    }
}
