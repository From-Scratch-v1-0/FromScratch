using System;
using System.Collections.Generic;
using System.Text;

namespace FS_DAL.Entities
{
    public partial class ProjectProduct
    {
        public int ProjectKey { get; set; }
        public string ProjectName { get; set; }
        public int? ProjectTypeKey { get; set; }
        public string Description { get; set; }
        public int? Rating { get; set; }

        public virtual ProjectType ProjectTypeKeyNavigation { get; set; }
    }
}
