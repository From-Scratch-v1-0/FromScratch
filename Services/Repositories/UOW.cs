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
        private IProjectProductRepository _projprodRepository;
        private IProjectRepository _projRepository;

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
        public IProjectProductRepository ProjectProduct
        {
            get
            {
                if (_projprodRepository == null)
                    _projprodRepository = new ProjectProductRepository(_context);
                return _projprodRepository;
            }
        }
        public IProjectRepository Project
        {
            get
            {
                if (_projRepository == null)
                    _projRepository = new ProjectRepository(_context);
                return _projRepository;
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
