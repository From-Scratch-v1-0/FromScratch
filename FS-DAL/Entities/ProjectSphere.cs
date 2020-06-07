using System;
using System.Collections.Generic;
using System.Text;

namespace FS_DAL.Entities
{
    public partial class ProjectSphere
    {
        public int? ProjectKey { get; set; }
        public int? SphereKey { get; set; }

        public virtual ProjectProduct ProjectKeyNavigation { get; set; }
        public virtual Sphere SphereKeyNavigation { get; set; }
    }
}
