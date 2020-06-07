using System;
using System.Collections.Generic;
using System.Text;

namespace FS_DAL.Entities
{
    public partial  class ProjectType
    {
        public ProjectType()
        {
            ProjectProduct = new HashSet<ProjectProduct>();
        }

        public int ProjectTypeKey { get; set; }
        public string ProjectTypeName { get; set; }

        public virtual ICollection<ProjectProduct> ProjectProduct { get; set; }
    }
}
