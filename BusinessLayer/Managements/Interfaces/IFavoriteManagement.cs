using EntityLayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Managements.Interfaces
{
    public interface IFavoriteManagement
    {
        List<Favorite> GetAllFavoritesByUserId(int id);
        int GetAllFavoritesQuantity(int userId);
        void AddFavorite(Favorite favorite);
        void DeleteFavorite(int id);


    }
}
