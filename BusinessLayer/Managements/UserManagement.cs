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
    public class UserManagement : IUserManagement
    {

        private readonly IUserRepository _userRepository;

        public UserManagement(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User GetUserById(int id)
        {
           return _userRepository.GetUserById(id);
        }
    }
}
