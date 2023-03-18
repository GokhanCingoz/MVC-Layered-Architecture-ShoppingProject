using BusinessLayer.Managements.Interfaces;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.Interfaces;
using EntityLayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Managements
{
    public class FavoriteManagement : IFavoriteManagement
    {

        private readonly IFavoriteRepository favoriteRepository;

        public FavoriteManagement(IFavoriteRepository favoriteRepository)
        {
            this.favoriteRepository = favoriteRepository;
        }

        public void AddFavorite(Favorite favorite)
        { 
            favoriteRepository.AddToFavoriteProducts(favorite);
        }

        public void DeleteFavorite(int id)
        {
            favoriteRepository.DeleteFromFavoriteProducts(id);
        }

        public List<Favorite> GetAllFavoritesByUserId(int id)
        {
           return favoriteRepository.GetAllFavoriteProducts(id);
        }

        public int GetAllFavoritesQuantity(int userId)
        {

            var quantity = favoriteRepository.GetAllFavoriteProducts(userId).Count();

            return quantity;
        }
    }
}
