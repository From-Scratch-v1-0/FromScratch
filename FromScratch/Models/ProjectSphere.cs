using System;
using System.Collections.Generic;

namespace FromScratch.Models
{
    public partial class ProjectSphere
    {
        public int? ProjectKey { get; set; }
        public short? SphereKey { get; set; }

        public virtual ProjectProduct ProjectKeyNavigation { get; set; }
        public virtual Sphere SphereKeyNavigation { get; set; }
    }
}
