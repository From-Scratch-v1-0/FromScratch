using FS_DAL.Context;
using FS_DAL.Entities;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Repositories
{
    public class ProjectSphereRepository : BaseRepository<ProjectSphere>, IProjectSphereRepository
    {
        public ProjectSphereRepository(FSContext context) : base(context)
        {
        }
    }
}
