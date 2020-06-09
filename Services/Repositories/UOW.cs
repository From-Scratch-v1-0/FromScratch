using FS_DAL.Context;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Repositories
{
    public class UOW : IUOW
    {
        private readonly FSContext _context;
        private IUserRepository _userRepository;

        public UOW(FSContext context)
        {
            _context = context;
        }

        public IUserRepository User
        {
            get 
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_context);
                return _userRepository;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
