using FS_DAL.Context;
using FS_DAL.Entities;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Repositories
{
    public class SkillsRepository : BaseRepository<Skills>, ISkillsRepository
    {
        public SkillsRepository(FSContext context) : base(context)
        {
        }
    }
}
