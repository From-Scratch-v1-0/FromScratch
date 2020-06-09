using System;
using System.Collections.Generic;
using System.Text;

namespace FS_DAL.Entities
{
    public partial class Project
    {
        public int? ProjectKey { get; set; }
        public string? UserKey { get; set; }
        public int? StartDateKey { get; set; }
        public int? StatusKey { get; set; }

        public virtual ProjectProduct ProjectKeyNavigation { get; set; }
        public virtual Status StatusKeyNavigation { get; set; }
        public virtual User UserKeyNavigation { get; set; }
    }
}
