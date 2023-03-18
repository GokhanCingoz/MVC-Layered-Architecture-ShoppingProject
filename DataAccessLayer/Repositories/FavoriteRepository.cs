using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Interfaces;
using EntityLayer.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class FavoriteRepository : IFavoriteRepository
    {

        private readonly ContextDb _contextDb;

        public FavoriteRepository(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }
        public void AddToFavoriteProducts(Favorite favorite)
        {
            if (!_contextDb.Favorites.Any(x=>x.ProductId == favorite.ProductId))
            {
                _contextDb.Favorites.Add(favorite);
                _contextDb.SaveChanges();
            }
          
        }

        public void DeleteFromFavoriteProducts(int id)
        {
            _contextDb.Favorites.Remove(_contextDb.Favorites.FirstOrDefault(c => c.ProductId == id));
            _contextDb.SaveChanges();
        }

        public List<Favorite> GetAllFavoriteProducts(int userId)
        {
            return _contextDb.Favorites.Include(u => u.Product).ThenInclude(u => u.Category).Where(x => x.UserId == userId).ToList();
        }
    }
}
