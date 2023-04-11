using EntityLayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Managements.Interfaces
{
    public interface ILoginManagement 
    {
        public Task<bool> LoginControlAsync(string username, string password);
        public User LoginControl(string username, string password);
        void SignUpUser(User user);
        bool UserNameControl(string username);
        //Admin section
        Task<User?> GetAsync(int id);
        Task<User?> AddAsync(User user);
        User UpdateAsync(User user);
        public bool IsAdmin(int userId);
        bool UserAdminControl(int userId);
    }
}
