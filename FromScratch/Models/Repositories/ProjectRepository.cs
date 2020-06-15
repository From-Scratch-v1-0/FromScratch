using FS_DAL.Context;
using FS_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FromScratch.Models.Repositories
{
    public interface IProjectRepository
    {
        void AddProject(ProjectProduct Proj);
        bool ExistProject(string ProjProd);
        IEnumerable<ProjectProduct> GetAllProjects();
    }
    public class ProjectRepository:IProjectRepository
    {
        private readonly FSContext _fscontext;
        public ProjectRepository(FSContext fscontext)
        {
            _fscontext = fscontext;
        }
        public void AddProject(ProjectProduct Proj)
        {
            _fscontext.ProjectProduct.Add(Proj);
            _fscontext.SaveChanges();
        }
        public bool ExistProject(string ProjProd)
        {
            var prpr = _fscontext.ProjectProduct.Any(e => e.ProjectName == ProjProd);
            if (prpr)
                return true;
            return false;
        }
        public IEnumerable<ProjectProduct> GetAllProjects()
        {
            return _fscontext.ProjectProduct.ToList();
        }
    }
}
