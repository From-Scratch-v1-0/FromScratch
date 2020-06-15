using FS_DAL.Context;
using FS_DAL.Entities;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Repositories
{
    public class ProjectProductRepository : BaseRepository<ProjectProduct>, IProjectProductRepository
    {
        public ProjectProductRepository(FSContext context) : base(context)
        {
        }
    }
}
