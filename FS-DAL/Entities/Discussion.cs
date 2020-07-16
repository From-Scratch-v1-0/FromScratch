using System;
using System.Collections.Generic;
using System.Text;

namespace FS_DAL.Entities
{
    public partial class Discussion
    {
        public int DiscussionKey { get; set; }
        public string UserKey { get; set; }
        public int ProjectProductKey { get; set; }
        public string Comment { get; set; }

        public virtual User UserKeyNavigation { get; set; }
        public virtual ProjectProduct ProjectProductKeyNavigation { get; set; }
    }
}
