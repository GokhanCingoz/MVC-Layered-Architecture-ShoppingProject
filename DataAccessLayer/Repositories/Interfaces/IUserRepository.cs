﻿using Azure;
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
        //Admin section
        Task<User?> GetAsync(int id);
        Task<User?> AddAsync(User user);
        User UpdateAsync(User user);
        User Delete(User user);
        public bool IsAdmin(int userId);
        User GetUserById(int id);
        
    }
}
