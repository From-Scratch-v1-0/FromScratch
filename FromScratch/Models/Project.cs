using System;
using System.Collections.Generic;

namespace FromScratch.Models
{
    public partial class Project
    {
        public int? ProjectKey { get; set; }
        public int? UserKey { get; set; }
        public int? StartDateKey { get; set; }
        public short? StatusKey { get; set; }

        public virtual ProjectProduct ProjectKeyNavigation { get; set; }
        public virtual Status StatusKeyNavigation { get; set; }
        public virtual User UserKeyNavigation { get; set; }
    }
}
