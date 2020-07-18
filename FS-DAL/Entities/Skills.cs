using System;
using System.Collections.Generic;
using System.Text;

namespace FS_DAL.Entities
{
    public partial class Skills
    {
        public int SkillKey { get; set; }
        public string SkillName { get; set; }
        public string UserFKey { get; set; }
        public virtual User UserKeyNavigation { get; set; }
    }
}
