using FS_DAL.Context;
using FS_DAL.Entities;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Repositories
{
    public class ProjectRepository : BaseRepository<ProjectProduct>, IProjectRepository
    {
        public ProjectRepository(FSContext context) : base(context)
        {
        }
    }
}
