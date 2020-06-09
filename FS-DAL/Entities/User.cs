using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FS_DAL.Entities
{
    public partial class User : IdentityUser
    {
        public DateTime? CreateDate { get; set; }
        public int? UserTypeKey { get; set; }
        public bool? IsActive { get; set; }
        public int? Rating { get; set; }

        public virtual UserType UserTypeKeyNavigation { get; set; }
    }
}
