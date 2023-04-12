using EntityLayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Managements.Interfaces
{
    public interface IDeliveryManagement
    {
         List<Delivery> GetDeliveryByUserId(int userId);
    }
}
