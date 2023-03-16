using Azure;
using EntityLayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        IEnumerable<User> GetAllUsers();
        void Add(User user);
        //Task<User?> GetAsync(Guid id);
        //Task<User?> AddAsync(Tag tag);
        //Task<User?> UpdateAsync(Tag tag);
        //Task<User?> DeleteAsync(Guid id);
    }
}
