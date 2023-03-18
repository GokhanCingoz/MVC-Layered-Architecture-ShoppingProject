using EntityLayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IFavoriteRepository
    {
        List<Favorite> GetAllFavoriteProducts(int userId);
        void AddToFavoriteProducts(Favorite favorite);
        void DeleteFromFavoriteProducts(int id);
    }
}
