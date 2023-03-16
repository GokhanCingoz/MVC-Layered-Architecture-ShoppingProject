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
    public class UserRepository : IUserRepository
    {
        private readonly ContextDb _contextDb;

        public UserRepository(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _contextDb.Users.ToList();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _contextDb.Users.ToListAsync();
           
        }

        public void Add(User user)
        {
            _contextDb.Users.Add(user);
            _contextDb.SaveChanges();
        }

    }
}
