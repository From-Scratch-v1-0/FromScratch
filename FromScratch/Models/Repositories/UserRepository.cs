using FS_DAL.Context;
using FS_DAL.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FromScratch.Models.Repositories
{
    public interface IUserRepository 
    {
        void AddUser(User user);
        IEnumerable<User> GetAllUsers();
        bool ExistUsername(string username);
        bool ExistEmail(string email);

        bool PasswordVerification(string username,string password);
    }

    public class UserRepository : IUserRepository
    {
        private readonly FSContext _context;

        public UserRepository(FSContext context)
        {
            _context = context;
        }
        public void AddUser(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
        }

        public bool ExistEmail(string email)
        {
            var em = _context.User.Any(e => e.Email == email);
            if (em)
                return true;
            return false;
        }

        public bool ExistUsername(string username)
        {
            var us = _context.User.Any(u => u.UserName == username);
            if (us)
                return true;
            return false;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.User.ToList();
        }

        public bool PasswordVerification(string username, string password)
        {
            var pass = _context.User.Where(u => u.UserName == username).Any(p => p.PasswordHash == password);
            return pass;
        }
    }
}
