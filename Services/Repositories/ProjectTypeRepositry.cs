using FS_DAL.Context;
using FS_DAL.Entities;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Repositories
{
    public class ProjectTypeRepositry : BaseRepository<ProjectType>, IProjectTypeRepositry
    {
        public ProjectTypeRepositry(FSContext context) : base(context)
        {
        }
    }
}
