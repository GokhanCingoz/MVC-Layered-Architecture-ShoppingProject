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
    public class LoginManagement : ILoginManagement
    {
        private readonly IUserRepository _userRepository;

        public LoginManagement(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User LoginControl(string username, string password)
        {
            var users = _userRepository.GetAllUsers();

            return users.FirstOrDefault(x => x.Username == username && x.Password == password);

        }

        public async Task<bool> LoginControlAsync(string username, string password)
        {
            var users = await _userRepository.GetAllUsersAsync();

            return users.Any(x => x.Username == username && x.Password == password);
        }

        public void SignUpUser(User user)
        {
            _userRepository.Add(user);
        }

        public bool UserNameControl(string username)
        {
            var user = _userRepository.GetAllUsers();

            return user.Any(x => x.Username == username );
        }
    }
}
