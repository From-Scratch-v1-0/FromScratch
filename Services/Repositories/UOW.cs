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
        private IProjectTypeRepositry projectTypeRepositry;
        private ISphereRepositry sphereRepositry;
        private IProjectSphereRepository projectSphereRepository;
        private IDiscussionRepository discussionRepository;
        private IPersonRepository personRepository;
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

        public IPersonRepository Person
        {
            get 
            {
                if (personRepository == null)
                    personRepository = new PersonRepository(_context);
                return personRepository;
            }
        }

        public IProjectTypeRepositry ProjectType
        {
            get
            {
                if (projectTypeRepositry == null)
                    projectTypeRepositry = new ProjectTypeRepositry(_context);
                return projectTypeRepositry;
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

        public ISphereRepositry Sphere 
        {
            get 
            {
                if (sphereRepositry == null)
                    sphereRepositry = new SphereRepositry(_context);
                return sphereRepositry;
            }
        }

        public IProjectSphereRepository ProjectSphere 
        {
            get 
            {
                if (projectSphereRepository == null)
                    projectSphereRepository = new ProjectSphereRepository(_context);
                return projectSphereRepository;
            }
        }

        public IDiscussionRepository Discussion 
        {
            get 
            {
                if (discussionRepository == null)
                    discussionRepository = new DiscussionRepository(_context);
                return discussionRepository;
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
